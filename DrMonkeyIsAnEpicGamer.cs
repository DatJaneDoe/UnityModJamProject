using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.ServerEvents;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Unity.Display;
using UnityEngine;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using BTD_Mod_Helper.Api;
using UsesBossHandlerNamespace;
using MelonLoader;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using static UsesBossHandlerNamespace.Bosses;
using HarmonyLib;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models;

namespace CrystalBoss
{
    public class DrMonkeyIsAnEpicGamer
    {
        public static bool hasSeenDrMonkeysEpicGamingStream = false;
        public class DrMonkey : ModDisplay
        {
            public override string BaseDisplay => "62a150bef76d299459ce17edae589d65";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
             
            }
        }
        public class DrMonkeyPC : ModDisplay
        {
            public override string BaseDisplay => "bdbeaa256e6c63b45829535831843376";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {

                Set2DTexture(node, "pc");
                foreach (Renderer rend in node.genericRenderers)
                {
                    rend.gameObject.transform.localPosition = new Vector3(0, 50, -20);
                }
                
            }
        }
        

        public class MiningLamp : ModTower
        {
            // public override string Portrait => "Don't need to override this, using the default of Name-Portrait";
            // public override string Icon => "Don't need to override this, using the defaPizza-Portraitult of Name-Icon";

            public override TowerSet TowerSet => TowerSet.Support;
            public override string BaseTower => "MonkeyVillage";
            public override int Cost => 2000;

            //  public override ParagonMode ParagonMode => ParagonMode.Base000;
            public override bool DontAddToShop => false;

            public override string DisplayName => "Lamp";
            public override int TopPathUpgrades => 0;
            public override int MiddlePathUpgrades => 0;
            public override int BottomPathUpgrades => 0;
            public override string Description => "The darkness of the underground reduces all tower range by 50% unless its in range of this lamp";


            public override void ModifyBaseTowerModel(TowerModel towerModel)
            {
                towerModel.radius = 3;
                towerModel.range *= 2f ;

                towerModel.display = towerModel.GetBehavior<DisplayModel>().display = new Il2CppNinjaKiwi.Common.ResourceUtils.PrefabReference("389e9b25c6a07fe4abca2ef2b20367cf");
                
               
                towerModel.icon = towerModel.portrait =  new Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference("2776d70c4ba2fa747a355e7edce017db");

             
                towerModel.dontDisplayUpgrades = true;
               
                var range = towerModel.GetBehavior<RangeSupportModel>();
                range.multiplier = 1f;
                var rangeP = range.Duplicate();
                rangeP.onlyAffectParagon = true;
                rangeP.mutatorId += "P";
                towerModel.AddBehavior(rangeP);
                range.mutatorId = "LightSource";
                range.buffIconName = range.buffLocsName = "";
            }

            public override int GetTowerIndex(System.Collections.Generic.List<TowerDetailsModel> towerSet)
            {

                return towerSet.First(model => model.towerId == TowerType.BananaFarm).towerIndex + 1;
            }


        }
        public class DrMonkeyGaming : ModTower
        {
  

            public override TowerSet TowerSet => TowerSet.Support;
            public override string BaseTower => "MonkeyVillage";
            public override int Cost => 0;

           
            public override bool DontAddToShop => false;

            public override string DisplayName => "Dr Monkey Gaming";
            public override int TopPathUpgrades => 0;
            public override int MiddlePathUpgrades => 0;
            public override int BottomPathUpgrades => 0;
            public override string Description => "Optional bonus cash due to this mods difficulty.\n Generates $100 cash per round from stream donations, increasing by 10% per round";


            public override void ModifyBaseTowerModel(TowerModel towerModel)
            {
                towerModel.radius = 1;
                towerModel.range = 0;
       
                towerModel.ApplyDisplay<DrMonkey>();
                DisplayModel copy = Game.instance.model.GetTower("DartMonkey").GetBehavior<DisplayModel>().Duplicate();
             
                copy.scale = 0.5f;
                copy.ApplyDisplay<DrMonkeyPC>();
                towerModel.AddBehavior(copy);
                towerModel.icon = towerModel.portrait = ModContent.GetSpriteReference<IdkWhatToNameThisMod>("drG");
                towerModel.RemoveBehavior<RangeSupportModel>();
                towerModel.AddBehavior(new PerRoundCashBonusTowerModel("Donations", 100, 0, 2, new Il2CppNinjaKiwi.Common.ResourceUtils.PrefabReference("77503c27ee86922409f6383b5b264982"), true));
                
                towerModel.dontDisplayUpgrades = true;
                towerModel.displayScale = 0.5f;
              
            }

            public override int GetTowerIndex(System.Collections.Generic.List<TowerDetailsModel> towerSet)
            {

                return towerSet.First(model => model.towerId == TowerType.BananaFarm).towerIndex + 1;
            }


        }
        public class BananaFarmer : ModTower
        {

            public override TowerSet TowerSet => TowerSet.Support;
            public override string BaseTower => "BananaFarmer";
            public override int Cost => 500;


            public override string Icon => VanillaSprites.BananaFarmerIcon;
            public override string Portrait => VanillaSprites.BananaFarmerPortrait;
            public override string DisplayName => "Banana Farmer";
            public override int TopPathUpgrades => 0;
            public override int MiddlePathUpgrades => 0;
            public override int BottomPathUpgrades => 0;
            public override string Description => "Collects nearby Bananas";

            public override void ModifyBaseTowerModel(TowerModel towerModel)
            {

        
                towerModel.dontDisplayUpgrades = true;
               
            }

            public override int GetTowerIndex(System.Collections.Generic.List<TowerDetailsModel> towerSet)
            {

                return towerSet.First(model => model.towerId == TowerType.MonkeyVillage).towerIndex + 1;
            }


        }
        public class TechBot : ModTower
        {
            // public override string Portrait => "Don't need to override this, using the default of Name-Portrait";
            // public override string Icon => "Don't need to override this, using the defaPizza-Portraitult of Name-Icon";

            public override TowerSet TowerSet => TowerSet.Support;
            public override string BaseTower => "TechBot";
            public override int Cost => 500;
            public override string Icon => VanillaSprites.TechbotIcon;
            public override string Portrait => VanillaSprites.TechbotPortrait;
            public override string DisplayName => "Tech Bot";
            public override int TopPathUpgrades => 0;
            public override int MiddlePathUpgrades => 0;
            public override int BottomPathUpgrades => 0;
            public override string Description => "Automatically activates abilities";

            public override void ModifyBaseTowerModel(TowerModel towerModel)
            {
                   towerModel.dontDisplayUpgrades = true;
              
            }

            public override int GetTowerIndex(System.Collections.Generic.List<TowerDetailsModel> towerSet)
            {

                return towerSet.First(model => model.towerId == TowerType.SpikeFactory).towerIndex + 1;
            }


        }
        [HarmonyPatch(typeof(Tower), nameof(Tower.Initialise))]
        public class DrMonkeyGamingStart
        {
            [HarmonyPostfix]

            public static void Postfix(Tower __instance)
            {
                if (__instance.towerModel.name.Contains("DrMonkeyGaming"))
                {
                    if (CutsceneSystem.scene != "None")
                    {
                        __instance.SellTower();
                    }
                    else
                    {
                        if (InGame.instance.bridge.GetCurrentRound() < 25 && !hasSeenDrMonkeysEpicGamingStream)
                        {
                            CutsceneSystem.StartCutscene("gaming");
                            hasSeenDrMonkeysEpicGamingStream = true;
                        }
                        __instance.Rotation = 180;
                        __instance.Scale = new Il2CppAssets.Scripts.Simulation.SMath.Vector3Boxed(-0.5f, 0.5f, 0.5f);
                    }
                }
            }

        }
      
        [HarmonyPatch(typeof(PerRoundCashBonusTower), nameof(PerRoundCashBonusTower.OnRoundComplete))]
        public class DrMonkeyGamingDonationMoney
        {
            [HarmonyPrefix]

            public static void Prefix(PerRoundCashBonusTower __instance, int roundArrayIndex)
            {
                if (__instance.perRoundCashBonusTowerModel.name.Contains("Donations"))
                {
                    __instance.perRoundCashBonusTowerModel.cashPerRound = 100 + (10 * roundArrayIndex);
                }
            }

        }
       
    }
}
