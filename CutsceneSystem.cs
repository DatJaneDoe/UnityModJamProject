using UsesBossHandlerNamespace;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;


namespace CrystalBoss
{
    public class CutsceneSystem : BloonsTD6Mod
    {
        public static bool click = false;
        public static bool clickTicket = false;
        public static int clickCooldown = 0;
        public static int cutsceneIdCounter = 0;
        public static ModHelperPanel cutscenePlayer;

        public static ModHelperImage dialogueBubble;
        public static int gifTimer = 0;
        public static bool updateScene = false;
        public static ModHelperImage characterSlot;
        public static ModHelperImage altCharacterSlot;
        public static ModHelperImage imageSlot;
        public static ModHelperImage sillyGif;
        public static ModHelperText dialogueBubbleText;
        public static string scene = "";
        public static Dictionary<string, Cutscene> cutscenes = new Dictionary<string, Cutscene>();
        public static Dictionary<string, string> characterColor = new Dictionary<string, string>();
        public static void ProcessCutscenes()
        {
          
            bool cursor = InGame.instance.inputManager.cursorDown;

            if (cursor && !click)
            {
                click = true;

            }
            if (!cursor && click && clickCooldown <= 0)
            {
                click = false;
                clickTicket = true;
                updateScene = true;
            }

            if (cutscenes.ContainsKey(scene))
            {
                ToggleBloons(false);
                if (InGame.instance.GetInGameUI().GetComponentInChildrenByName<LayoutGroup>("LayoutGroup") != null)
                {
                    InGame.instance.GetInGameUI().GetComponentInChildrenByName<LayoutGroup>("LayoutGroup").Hide();
                }
                
               

            }
            else
            {
                ToggleBloons(true);
                if (InGame.instance.GetInGameUI().GetComponentInChildrenByName<LayoutGroup>("LayoutGroup") != null)
                {
                    InGame.instance.GetInGameUI().GetComponentInChildrenByName<LayoutGroup>("LayoutGroup").Show();
                }
                scene = "None";
                UnblockTowers();
                if (cutscenePlayer != null)
                {
                    cutscenePlayer.Hide();

                }

            }

            if (cutscenePlayer != null)
            {
                if (sillyGif.isActiveAndEnabled)
                {
                    int index = (int)(1 + ((gifTimer / 4f) % 8));
                    sillyGif.Image.sprite = ModContent.GetSprite<IdkWhatToNameThisMod>("frame (" + index + ")");
                    gifTimer++;
                }
                if (clickCooldown > 0)
                {
                    click = false;
                    clickTicket = false;
                    clickCooldown--;
                }
                if (clickTicket && clickCooldown <= 0)
                {



                    if (cutscenes.ContainsKey(scene))
                    {

                        if (cutscenes[scene].action != null)
                        {

                            cutscenes[scene].action.Invoke();
                        }
                        else if (cutscenes[scene].function != null)
                        {

                            cutscenes[scene].function.Invoke();

                        }
                        scene = cutscenes[scene].next;
                        updateScene = true;
                        clickCooldown = 5;
                    }


                }
            }
            if (updateScene)
            {
                if (cutscenes.ContainsKey(scene))
                {
                    cutscenes[scene].ShowScene();
                    cutscenePlayer.Show();
                }
                updateScene = false;
            }
            clickTicket = false;

        }


        public static void ToggleBloons(bool enable)
        {
            foreach (BloonToSimulation bloonSim in InGame.instance.bridge.GetAllBloons().ToList())
            {
                var bloon = bloonSim.GetBloon();
                if (enable)
                {
                    bloon.IsInvulnerable = false;
                    bloon.trackSpeedMultiplier = 1;
                }
                else
                {
                    bloon.IsInvulnerable = true;
                    bloon.trackSpeedMultiplier = 0;
                }
            }
        }

        public static void CutsceneSequence(string id, string[] scenes, Function exit)
        {

            scenes.AddItem("");

            for (int i = 0; i < scenes.Count(); i++)
            {
                cutsceneIdCounter++;
                if (i == 0)
                {
                    cutscenes[id] = new Cutscene(scenes[i], ((cutsceneIdCounter + 1)) + "CutsceneIncrement");
                }
                else if (i == scenes.Count() - 1)
                {

                    cutscenes[cutsceneIdCounter + "CutsceneIncrement"] = new Cutscene(scenes[i], exit);
                }
                else
                {
                    cutscenes[cutsceneIdCounter + "CutsceneIncrement"] = new Cutscene(scenes[i], ((cutsceneIdCounter + 1)) + "CutsceneIncrement");
                }

            }

            cutsceneIdCounter += 5;
        }

        public static void CutsceneSequence(string id, string[] scenes, string exit = "")
        {

            scenes.AddItem("");

            for (int i = 0; i < scenes.Count(); i++)
            {
                cutsceneIdCounter++;
                if (i == 0)
                {
                    cutscenes[id] = new Cutscene(scenes[i], ((cutsceneIdCounter + 1)) + "CutsceneIncrement");
                }
                else if (i == scenes.Count() - 1)
                {
                    cutscenes[cutsceneIdCounter + "CutsceneIncrement"] = new Cutscene(scenes[i], exit);
                }
                else
                {
                    cutscenes[cutsceneIdCounter + "CutsceneIncrement"] = new Cutscene(scenes[i], ((cutsceneIdCounter + 1)) + "CutsceneIncrement");
                }

            }

            cutsceneIdCounter += 5;
        }

        public static void StartCutscene(string id, int overrideClickCD = 10)
        {
            updateScene = true;
            foreach (TowerToSimulation sim in InGame.instance.bridge.GetAllTowers().ToList())
            {
                sim.tower.SetSelectionBlocked(true);
                

            }
            ToggleBloons(false);
            clickCooldown = overrideClickCD;
            scene = id;
        }
        public static void UnblockTowers()
        {
            foreach (TowerToSimulation sim in InGame.instance.bridge.GetAllTowers().ToList())
            {
              
                sim.tower.SetSelectionBlocked(false);

            }
        }
        public class Cutscene
        {

            public string name = "";
            public string frame = "";
            public string next = "";
            public string dialogue = "";
            
            public Action action = null;
            public Function function = null;
            public Cutscene(string frame, string next, string dialogue = "")
            {

                this.frame = frame;
                this.next = next;
                this.dialogue = dialogue;

            }
            public Cutscene(string frame, Action action)
            {

                this.frame = frame;

                this.action = action;
            }
            public Cutscene(Function function)
            {



                this.function = function;
            }
            public Cutscene(string frame, Function function, string dialogue = "")
            {

                this.frame = frame;

                this.dialogue = dialogue;
                this.function = function;
            }
            public Cutscene(string frame, Action action, string dialogue = "")
            {

                this.frame = frame;

                this.dialogue = dialogue;
                this.action = action;
            }
            public void ShowScene()
            {
                
                if (cutscenePlayer == null)
                {

                    cutscenePlayer = InGame.instance.mapRect.gameObject.AddModHelperPanel(new Info("CutscenePanel",
0, 3, 0, 0, new UnityEngine.Vector2(0.5f, .5f), new UnityEngine.Vector2(.5f, .5f)), frame);

                    imageSlot = cutscenePlayer.AddImage(new Info("ImageSlot", 0, 3, 4000, 2700), ModContent.GetSprite<IdkWhatToNameThisMod>("speech"));


                    dialogueBubble = cutscenePlayer.AddImage(new Info("DialogueBubble", 0, -800, 1700, 800), ModContent.GetSprite<IdkWhatToNameThisMod>("speech"));
         
                    characterSlot = cutscenePlayer.AddImage(new Info("CharacterSlot", 1300, -850, 1200, 1200), ModContent.GetSprite<IdkWhatToNameThisMod>("speech"));
                    altCharacterSlot = cutscenePlayer.AddImage(new Info("AltCharacterSlot", -1300, -850, 1200, 1200), ModContent.GetSprite<IdkWhatToNameThisMod>("adora"));


                    sillyGif = cutscenePlayer.AddImage(new Info("GifSlot", -1400, 900, 750, 750), ModContent.GetSprite<IdkWhatToNameThisMod>("frame (1)"));


                    dialogueBubbleText = dialogueBubble.AddText(new Info("DialogueText", 0, 0, 1200, 700), "", 80);
                    dialogueBubbleText.Text.lineSpacing = 10;
                    dialogueBubbleText.Text.AutoLocalize = false;
                }


                sillyGif.SetActive(false);

                string[] info = frame.Split('|');
                string modifiers = "";
                bool isImg = false;
                if(info.Count() == 1 || ((info.Count() == 3 && info[1] == "")))
                {
                   
                    if(info.Count() >= 3)
                    {
                        modifiers = info[2];
                    }
                    isImg = true;
                }
               
                else
                {
                    
                    if(info.Count() > 2)
                    {
                        modifiers = info[2];
                    }

                    imageSlot.Hide();
                    if (modifiers.Contains("L"))
                    {
                        altCharacterSlot.Image.sprite = ModContent.GetSprite<IdkWhatToNameThisMod>(info[0]);
                        altCharacterSlot.Show();
                        characterSlot.Hide();
                        altCharacterSlot.gameObject.transform.localScale = dialogueBubbleText.gameObject.transform.localScale = dialogueBubble.gameObject.transform.localScale = new UnityEngine.Vector3(-1, 1, 1);
                    
                    }
                    else
                    {
                        characterSlot.Image.sprite = ModContent.GetSprite<IdkWhatToNameThisMod>(info[0]);
                        characterSlot.Show();
                        altCharacterSlot.Hide();
                        dialogueBubble.Show();
                        dialogueBubbleText.Show();
                    }
                    if (modifiers.Contains("{") && modifiers.Contains("}"))
                    {
                        string img = modifiers.Split('{')[1].Split('}')[0];
                        imageSlot.Image.sprite = ModContent.GetSprite<IdkWhatToNameThisMod>(img);
                        imageSlot.Show();
                    }
                    if (characterColor.ContainsKey(info[0]))
                    {
                        info[1] = characterColor[info[0]] + info[1];
                    }
                    dialogueBubbleText.SetText(info[1]);
                    
                }

                if (isImg)
                {
                    imageSlot.Image.sprite = ModContent.GetSprite<IdkWhatToNameThisMod>(info[0]);
                    dialogueBubble.Hide();
                    characterSlot.Hide();
                    altCharacterSlot.Hide();
                    imageSlot.Show();
                    if (modifiers.Contains("gif"))
                    {
                        
                        sillyGif.SetActive( true);
                    }
                    
                }
               
                cutscenePlayer.Show();
               
            }


        }
    }
}
