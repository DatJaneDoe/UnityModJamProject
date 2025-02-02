
using MelonLoader;




using System.Linq;

using System;

using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using System.Collections.Generic;

using BTD_Mod_Helper.Api.Display;

using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Unity;
using UnityEngine;
using Il2CppAssets.Scripts.Models.Effects;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Models.Map;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2Cpp;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors.Actions;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.Towers.TowerFilters;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles;
using Il2CppAssets.Scripts.Utils;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;

using static UsesBossHandlerNamespace.Bosses;

using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.Stats;
using Il2CppAssets.Scripts.Simulation.Map.Triggers;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;
using Il2CppAssets.Scripts.Unity.Map.Triggers;
using MapEvent = Il2CppAssets.Scripts.Simulation.Map.Triggers.MapEvent;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Simulation.SMath;

using CreateEffectOnExpireModel = Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.CreateEffectOnExpireModel;
using Random = System.Random;
using static Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors.MorphTowerModel;
using CreateEffectOnExpire = Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Behaviors.CreateEffectOnExpire;
using Il2CppAssets.Scripts.Simulation.SimulationBehaviors;
using UnityEngine.Windows;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Simulation.Objects;
using static Il2CppAssets.Scripts.Models.Towers.Behaviors.ParagonTowerModel;
using Il2CppAssets.Scripts;
using static Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.AddBehaviorToBloonModel;

using Quaternion = Il2CppAssets.Scripts.Simulation.SMath.Quaternion;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Math = Il2CppAssets.Scripts.Simulation.SMath.Math;

using UnityEngine.Assertions;
using Il2CppAssets.Scripts.Unity.Scenes;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Behaviors;
using NinjaKiwi.Common.ResourceUtils;
using BTD_Mod_Helper.Api.Components;
using Il2CppAssets.Scripts.Unity.UI_New.Utils;
using static MelonLoader.MelonLogger;
using Il2CppAssets.Scripts.Unity.Towers;
using Tower = Il2CppAssets.Scripts.Simulation.Towers.Tower;
using TowerBehavior = Il2CppAssets.Scripts.Simulation.Towers.TowerBehavior;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons.Behaviors;

using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Abilities.Behaviors;
using static UsesBossHandlerNamespace.IdkWhatToNameThisMod;
using Il2CppAssets.Scripts.Data.Boss;
using Il2CppAssets.Scripts.SimulationTests;
using BTD_Mod_Helper.Api.ModOptions;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Unity.Achievements.List;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using UnityEngine.Rendering;
using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppAssets.Scripts.Models.Towers.Mods;

using Il2CppAssets.Scripts.Unity.UI_New.Feats;
using BTD_Mod_Helper.Api.Enums;
using static UsesBossHandlerNamespace.IdkWhatToNameThisMod.BossPanel;

using Il2CppGeom;
using CommandLine;
using Il2CppSystem;
using Il2CppTMPro;
using Vector3 = Il2CppAssets.Scripts.Simulation.SMath.Vector3;
using Vector2 = UnityEngine.Vector2;
using Il2CppAssets.Scripts.Utils.Leaderboards;
using Color = UnityEngine.Color;
using UnityEngine.Playables;
using Il2CppAssets.Scripts.Unity.Display.Animation;
using static Il2CppAssets.Scripts.Models.Profile.ProfileModel;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using PrefabReference = Il2CppNinjaKiwi.Common.ResourceUtils.PrefabReference;
using NAudio.Wave;
using Il2CppAssets.Scripts.Data.Behaviors;
using System.Diagnostics.Eventing.Reader;
using UnityEngine.U2D;
using Il2CppNinjaKiwi.Common;
using static Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.SlowModel;
using Il2CppAssets.Scripts.Unity.Effects;
using UnityEngine.PlayerLoop;
using System.IO;
using System.Security.Cryptography;
using NinjaKiwi.Common.Linq;
using CrystalBoss;



namespace UsesBossHandlerNamespace
{
    internal class CrystalBossScript
    {







        [RegisterTypeInIl2Cpp]
        public class CrystalController : MonoBehaviour
        {
            public Dictionary<ObjectId, CrystalFragment> empowerCrystalsById = new Dictionary<ObjectId, CrystalFragment>() { };
            public List<CrystalFragment> empowerCrystals = new List<CrystalFragment>() { };
            public Dictionary<ObjectId, CrystalFragment> stunCrystalsById = new Dictionary<ObjectId, CrystalFragment>() { };
            public List<CrystalFragment> stunCrystals = new List<CrystalFragment>() { };
            public Dictionary<ObjectId, CrystalFragment> halvesById = new Dictionary<ObjectId, CrystalFragment>() { };
            public List<CrystalFragment> halfCrystals = new List<CrystalFragment>() { };
            public Dictionary<ObjectId, CrystalFragment> shieldsById = new Dictionary<ObjectId, CrystalFragment>() { };
            public List<CrystalFragment> shieldsCrystals = new List<CrystalFragment>() { };
            public Dictionary<ObjectId, CrystalFragment> fragmentsById = new Dictionary<ObjectId, CrystalFragment>() { };
            public List<CrystalFragment> fragmentsCrystals = new List<CrystalFragment>() { };
          
            public static Dictionary<string, AnimationState> animState = new Dictionary<string, AnimationState>() { };
            public static Dictionary<string, Entity> bossEffects = new Dictionary<string, Entity>() { };

            public List<string> inertCrystals = new List<string>{ };
            public int timeMult = 1;
            public string activeAnimation = "";
            public int animTimer = 0;
            public bool started = false;
            public int startTimer = 0;
            public int finishTimer = 0;
            public int endVelocity = 100;
            public int stunCrystalsQuened = 0;
            public bool active = true;
            public int deathCounter = 0;
            public ObjectId bossId;
            public CrystalState state = CrystalState.Idle;
            public int counter = 10;
            public Random random = new Random();
            public long timeExisted = 0;
            public int deployIndex = 0;
            public BossRegistration registration;
            public bool showPanel = false;
            public bool inertedCrystals = false;
            public int splitProgress = -1;
            public List<int> queneCrystal = new List<int>() { };
            public Vector3 lastPosition = new Vector3(0, 0, 0);
            public float lastRotation = 0;
            public string[] fragmentNames = new string[] { "Primary", "Military", "Magic", "Support", "Stun", "Rock", "Resonant", "Fracture" };
            public string[] toFix = new string[] { "Defeat", "Defeat2", "Launch", "StartUp", "Charge" };
            public int blackListProgress = 0;
            public int fractureProgress = 0;
            public int finalCount = 0;
            public float finalResistance = 0;
            public List<string> blacklistFragments = new List<string>{};
            public int rockBloonHealth = -1;
            public long rockBloonLastSpawn = 0;
            public List<float> validEmpowerPositioning = new List<float>() {};
            public List<int> crystalOffset = new List<int>() { -30, 30, -30, 30, -15, 15, 10, 10 };
            public double shieldTimer = 0;
            public List<string> fragmentDescriptions = new List<string>() {
            "Primary Fragment \n <> \n\n Immune to Primary towers",
            "Military Fragment \n <> \n\n Immune to Military towers",
            "Magic Fragment \n <> \n\n Immune to Magic towers",
            "Support Fragment \n <> \n\n Immune to Support towers",
            "Stunning Fragment \n <> \n\n Every 50th hit taken, stuns the attacker",
            "Rock Fragment \n <> \n\n Reduced damage from projectiles under 10 pierce",
            "Shield Fragment \n <> \n\n Takes 25% less damage from projectiles\n and 25% more damage from DoT effects",
            "Fracture Fragment \n <> \n\n Takes 10% less damage \nper other fragment active"
            };
            public List<int> empowerment = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 };
            public List<float> resistanceMultiplier = new List<float> { 1, 1, 1, 1 };

            public CrystalController() : base()
            {

            }
            public void Start()
            {
                for (int i = 0; i < 18; i++)
                {
                    validEmpowerPositioning.Add(i * 0.05f);
                }
                InGame.instance.SpawnBloons("CrystalFrag", 8, 0);
                InGame.instance.SpawnBloons("SplitCrystal", 2, 0);

               

                
                if (registration.tier >= 2)
                {
                    InGame.instance.SpawnBloons("StunCrystal", registration.tier -1, 0);

                }
                if(registration.tier >= 4)
                {
                    InGame.instance.SpawnBloons("ShieldCrystal", 4, 0);
                }
            }

            public void Update()
            {
                if (TimeManager.FastForwardActive)
                {


                    timeMult = 3;
                }
                else
                {
                    timeMult = 1;


                }
                
                if (active)
                {
                    Bloon boss = InGame.instance.bridge.GetBloonFromId(bossId);

                    

                    if (boss != null)
                    {
                        StartUpFunctions(boss);
                        if (!inertedCrystals && registration.tier < 5)
                        {
                            if(boss.GetUnityDisplayNode() != null && bossEffects.ContainsKey("Defeat") && bossEffects.ContainsKey("Launch"))
                            {
                                SetHiddenCrystals(boss);
                               
                                foreach (string name in toFix)
                                {
                                    HideInertCrystals(bossEffects[ name]);
                                }
                                inertedCrystals = true;
                            }
                        }
                        boss.baseScale = 10;

                        lastPosition = boss.Position;
                        lastRotation = boss.Rotation;
                        if (!bossEffects.ContainsKey("Core"))
                        {

                            ApplyEffects(boss);
                            for (int i = 0; i < 8; i++)
                            {
                                
                                 
                                UpdateExtraInfo(i);
                                
                            }
                        }
                        else
                        {
        

                            Entity bossCoreEntity = bossEffects["Core"];
                            bossCoreEntity.GetDisplayNode().rotation.value = boss.Rotation;

                            float rotation = boss.Rotation;

                            var bossPos = boss.Position;


                            if (activeAnimation == "")
                            {
                                boss.baseScale = 10;
                            }
                            else
                            {
                                boss.baseScale = 0;
                                if (state != CrystalState.Fractured)
                                {
                                    AnimationState animation = animState[activeAnimation];
                                    Entity effect = bossEffects[animation.effectId];
                                    effect.GetDisplayNode().rotation.value = boss.Rotation;
                                    effect.GetDisplayNode().position.Set(bossPos);

                                    if (activeAnimation == "Launch")
                                    {

                                        var pos = bossPos;
                                    
                                        int delay = 50;
                     

                                        float difference = 75 - Math.Abs(animTimer - 75);



                                        float p = Math.Sqrt(difference) * 3;


                                        if (animTimer > 75 && queneCrystal.Count > 0)
                                        {

                                            foreach (int i in queneCrystal)
                                            {
                                                EmitCrystal(i, boss);

                                            }
                                            queneCrystal.Clear();
                                        }

                                        pos.Y -= p;
                                        pos.Z += p;
                                        float scale = 4 - (difference / 50f);
                                    
                                        bossCoreEntity.GetUnityDisplayNode().Scale = new UnityEngine.Vector3(scale, scale, scale);

                                        bossCoreEntity.GetUnityDisplayNode().gameObject.transform.position.Set(pos.X, pos.Y, pos.Z);



                                        if (animTimer > animation.cancel)
                                        {



                                            Hide(effect);
                                            bossCoreEntity.GetUnityDisplayNode().Scale = new UnityEngine.Vector3(4, 4, 4f);
                                            activeAnimation = "";

                                        }

                                    }
                                    if (activeAnimation == "StartUp")
                                    {

                                        if (animTimer > 75 && queneCrystal.Count > 0)
                                        {

                                            foreach (int i in queneCrystal)
                                            {
                                                EmitCrystal(i, boss);

                                            }
                                            queneCrystal.Clear();
                                        }


                                        var pos = bossPos;
                                        int height = Math.Min(75, animTimer);


                                        float p = Math.Sqrt(height);
                                        pos.Y -= p;
                                        pos.Z += p;


                                        //  entity.GetUnityDisplayNode().Scale = new UnityEngine.Vector3(scale, scale, scale);

                                        bossCoreEntity.GetUnityDisplayNode().gameObject.transform.position.Set(pos.X, pos.Y, pos.Z);

                                        if (animTimer > animation.cancel)
                                        {


                                            Hide(effect);
                                            bossCoreEntity.GetUnityDisplayNode().Scale = new UnityEngine.Vector3(4, 4, 4f);

                                            if (CrystalState.Idle == state)
                                            {


                                                activeAnimation = "";
                                            }
                                            else
                                            {

                                                bossScript.PlayAnimation("Charge");

                                            }
                                            // entity.GetUnityDisplayNode().GetRenderer<MeshRenderer>().gameObject.transform.localScale = new UnityEngine.Vector3();
                                        }

                                    }
                                    if (activeAnimation == "Charge")
                                    {

                                        int height = Math.Min(75, animTimer);

                                        var pos = boss.Position;
                                        float p = Math.Sqrt(75);
                                        pos.Y -= p;
                                        pos.Z += p;


                                        var scale = 3 + (Math.Sin(animTimer / 10f) * 0.5f);
                                        bossCoreEntity.GetUnityDisplayNode().Scale = new UnityEngine.Vector3(scale, scale, scale);

                                        bossCoreEntity.GetUnityDisplayNode().gameObject.transform.position.Set(pos.X, pos.Y, pos.Z);

                                        boss.Rotation = boss.prevRot = (animTimer + boss.Rotation) / 3f;
                                        if (state != CrystalState.Active && state != CrystalState.Emitting)
                                        {
                                            Hide(effect);
                                            bossCoreEntity.GetUnityDisplayNode().Scale = new UnityEngine.Vector3(4, 4, 4f);



                                            bossScript.PlayAnimation("StartUp");


                                        }
                                    }

                                }
                            }
                            if (state != CrystalState.Split && state != CrystalState.Fractured)
                            {
                                bossCoreEntity.GetDisplayNode().position.Set(bossPos);

                            }
                            if (registration.tier >= 3)
                            {
                                if (rockBloonHealth == -1)
                                {
                                    SetCrystalRockBloonHP(boss);
                                }
                                if (state == CrystalState.Active)
                                {
                                    long difference = timeExisted - rockBloonLastSpawn;
                                    if (difference > 500)
                                    {
                                        boss.GetBloonBehavior<SpawnBloonsAction>().PerformAction();
                                        rockBloonLastSpawn = timeExisted;
                                    }
                                }



                            }

                        }
                        showPanel = false;
                        

                        timeExisted += timeMult;
                        boss.IsInvulnerable = state != CrystalState.Idle || activeAnimation != "";
                       
                        
                        if (registration.tier >= 5 && CrystalState.Fractured == state)
                        {
                            ProcessFinal(boss);
                        }
                        animTimer += timeMult;
                        if (empowerCrystals.Count != 8)
                        {
                            boss.IsInvulnerable = true;

                        }
                        else if (state != CrystalState.Split && state != CrystalState.Fractured)
                        {
                            ProcessEmpowerFragments(boss);


                        }
                        if (state == CrystalState.Idle || state == CrystalState.Fractured)
                        {
                            boss.trackSpeedMultiplier = 1;


                        }
                        else
                        {
                            boss.trackSpeedMultiplier = 0;
                        }
                        if (stunCrystals.Count > 0)
                        {
                            ProcessShockShards(boss);
                        }
                        if (registration.tier >= 4)
                        {
                            ProcessShields(boss, (state == CrystalState.Idle || state == CrystalState.Fractured) && active);
                        }


                        if (state == CrystalState.Split)
                        {
                            ProcessHalves(boss);



                        }
                        else
                        {
                            if (InGame.instance.bridge.GetBloonFromId(halfCrystals[1].crystalId )!= null){
                                PositionCrystal(InGame.instance.bridge.GetBloonFromId(halfCrystals[1].crystalId), boss.PercThroughMap());
                            }
                            if (InGame.instance.bridge.GetBloonFromId(halfCrystals[0].crystalId) != null)
                            {
                                PositionCrystal(InGame.instance.bridge.GetBloonFromId(halfCrystals[0].crystalId), boss.PercThroughMap());
                            }
                        }



                        if (showPanel)
                        {
                            infoPanel.Show();

                        }
                        else
                        {
                            infoPanel.Hide();
                        }
                        if(startTimer < 300)
                        {
                            boss.baseScale = 0;
                            boss.trackSpeedMultiplier = 0;
                            if (bossEffects["Core"] != null)
                            {
                                Hide(bossEffects["Core"]);
                     
                            }
                            boss.IsInvulnerable = true;
                            boss.health = boss.bloonModel.maxHealth;
                        }
                        else
                        {
                            if (bossEffects.ContainsKey("StartDark"))
                            {
                                bossEffects["StartDark"].Destroy();
                                bossEffects.Remove("StartDark");
                            }
                           
                        }
                     
                    }
                    else
                    {
                        if (finishTimer == 0)
                        {
                            foreach (BloonToSimulation bloon in InGame.instance.bridge.GetAllBloons().ToList())
                            {
                                bloon.GetBloon().Destroy();
                            }
                            

                            foreach (var item in bossEffects)
                            {
                                if (item.Value != null)
                                {
                                    if (item.Key != "Core")
                                    {
                                        item.Value.Destroy();
                                        bossEffects.Remove(item.Key);
                                    }
                                    else
                                    {
                                        item.Value.GetDisplayNode().rotation.value = 0;
                                    }
                                }
                            }
                            bossEffects["DefeatAll"] = InGame.instance.bridge.simulation.SpawnEffect(ModContent.CreatePrefabReference<BossDisplayDefeatAll>(), lastPosition, 0, 10, -1); ;
                          finishTimer = 1;
                        }
                        else
                        {
                            bool wipe = false;
                            if (started)
                            {
                                if (finishTimer == 1)
                                {
                                    InGame.instance.bridge.simulation.SpawnEffect(new PrefabReference("b1324f2f4c3809643b7ef1d8c112442a"), lastPosition, 0, 3, 2);

                                    Entity defeat = bossEffects["DefeatAll"];
                                    defeat.GetDisplayNode().position.Set(lastPosition);


                                    defeat.GetUnityDisplayNode().gameObject.GetComponent<Animator>().SetTrigger("Start");
                                    defeat.GetUnityDisplayNode().gameObject.GetComponent<Animator>().Play("Scene", 0, 0);
                                    finishTimer = 2;

                                }
                                else
                                {
                                    if (finishTimer > 20)
                                    {
                                        var pos = bossEffects["Core"].GetDisplayNode().position;

                                        pos.Y += endVelocity / 50f;
                                        endVelocity-=3;
                                        bossEffects["Core"].GetDisplayNode().position.Set(pos);
                                    }
                                    
                                }
                                finishTimer += 2;

                                if (finishTimer > 300)
                                {
                                    wipe = true;
                                    infoPanel.Hide();

                                    if (InGame.instance.bridge.GetCurrentRound() > registration.roundSpawned)
                                    {
                                        CutsceneSystem.StartCutscene("godend" + registration.tier);
                                    }
                                    else
                                    {
                                        state = CrystalState.Idle;
                                        

                                    }
                                }
                            }
                            else
                            {
                                wipe = true;
                            }

                            if (wipe)
                            {
                                active = false;

                                foreach (var item in bossEffects)
                                {
                                    if (item.Value != null)
                                    {

                                        item.Value.Destroy();
                                        bossEffects.Remove(item.Key);
                                    }
                                }
                                bossPanelController.destroyTicket = 10;
                            }
                        }
                        
                    }
                   
               


                }
                else
                {
                   
                }
            }
            public void StartUpFunctions(Bloon boss)
            {
                int scale = 10;
                int stop = 360;
                if (startTimer <= stop)
                {
                 //   boss.health = boss.bloonModel.maxHealth;
                    boss.IsInvulnerable = true;
                    boss.trackSpeedMultiplier = 0;
                    scale = 0;
                    var pos = boss.Position;
                  
                    if (!bossEffects.ContainsKey("Defeat"))
                    {

                        bossEffects["Defeat"] = InGame.instance.bridge.simulation.SpawnEffect(ModContent.CreatePrefabReference<BossDisplayDefeat>(), new Il2CppAssets.Scripts.Simulation.SMath.Vector3(0, 0, 0), -1, 10, -1);
                        bossEffects["Defeat2"] = InGame.instance.bridge.simulation.SpawnEffect(ModContent.CreatePrefabReference<BossDisplayDefeat2>(), new Il2CppAssets.Scripts.Simulation.SMath.Vector3(0, 0, 0), -1, 10, -1);
                        bossEffects["StartDark"] = InGame.instance.bridge.simulation.SpawnEffect(ModContent.CreatePrefabReference<Darkness>(), boss.Position, -1, 10, -1);

                    }
                    else
                    {
                       
                        
                        Spin(boss, bossEffects["Defeat"], stop, true);
                        Spin(boss, bossEffects["Defeat2"], stop, false);
                    }

                }
                if (started)
                {
                    if (startTimer < stop)
                    {

                        startTimer += timeMult;
                        bossPanelController.startButton.Hide();
                        Vector3 bossPos = boss.Position;
                        Vector3 effectPos = bossEffects["Defeat"].GetDisplayNode().position;

                        float offsetX = bossPos.x - effectPos.x;
                        offsetX *= 0.99f;


                        float offsetY = bossPos.y - effectPos.y;
                        offsetY *= 0.99f;


                        if (startTimer >= stop)
                        {
                            bossEffects["Defeat"].GetDisplayNode().position.Set(500, 500, 0);

                            bossEffects["Defeat2"].GetDisplayNode().position.Set(500, 500, 0);
                            scale = 10;
                        }
                        else
                        {
                            bossEffects["Defeat"].GetDisplayNode().position.Set(bossPos.x - offsetX, bossPos.y - offsetY, 0);

                            bossEffects["Defeat2"].GetDisplayNode().position.Set(bossPos.x - offsetX, bossPos.y - offsetY, 0);

                        }

                        //   float rotDiff = boss.Rotation - bossEffects["Defeat"].GetDisplayNode().rotation.value;
                        //   bossEffects["Defeat"].GetDisplayNode().rotation.value += rotDiff * 0.005f;
                    }
                }
                else
                {
                    bossPanelController.startButton.Show();


                }
               

                boss.baseScale = scale;
            }
            public void Spin(Bloon boss, Entity defeat,int stop, bool invert)
            {
                var pos = boss.Position;
                if (defeat != null)
                {
                    if (defeat.GetDisplayNode() != null)
                    {
                        if (defeat.GetDisplayNode().rotation.value == -1)
                        {

                            defeat.GetDisplayNode().rotation.value = boss.Rotation + stop;


                            defeat.GetUnityDisplayNode().gameObject.GetComponent<Animator>().SetTrigger("End");
                            defeat.GetDisplayNode().position.Set(pos);

                        }


                        if (startTimer == 0)
                        {
                            defeat.GetUnityDisplayNode().AnimationSpeed = 0;
                        }
                        else
                        {
                            defeat.GetUnityDisplayNode().AnimationSpeed = 0.5f;

                            float invertTimer = (int)Math.Abs(startTimer - stop);
                            invertTimer = Math.Max(0, invertTimer - 70);

                            if ((invert))
                            {
                                invertTimer *= -1;
                            }
                            defeat.GetDisplayNode().rotation.value = boss.Rotation + (invertTimer);

                        }
                    }
                }
            }
            public void ProcessShields(Bloon boss, bool enable)
            {
                
              
                
                if (enable)
                {
                    int count = 0;
                   
                    float extra = 1 + (empowerment[6] * 0.05f);
                    shieldTimer += timeMult * extra;

                    foreach (CrystalFragment shield in shieldsCrystals)
                    {

                        float rotation = timeExisted / 10f;
                        float angle = (rotation) + count * 90;
                        float offsetX = Math.Sin(angle * 0.01745329f) * 50;
                        float offsetY = Math.Cos(angle * 0.01745329f) * 50;

                        shield.bloonPlacement = new Vector3(boss.Position.X + offsetX, boss.Position.Y + offsetY, 0);
                        Bloon crystal = InGame.instance.bridge.GetBloonFromId(shield.crystalId);
                        crystal.baseScale = 10;
                        crystal.Position.Set(shield.bloonPlacement);
                        shield.entity.GetDisplayNode().position.Set(shield.bloonPlacement);
                        shield.entity.GetDisplayNode().rotation.value = angle + 180;

                        if (!active)
                        {
                            crystal.IsInvulnerable = true;
                           
                        }
                        else
                        {
                            if (crystal.health < crystal.bloonModel.maxHealth)
                            {
                                shield.health -= (crystal.bloonModel.maxHealth - crystal.health);
                                crystal.health = crystal.bloonModel.maxHealth;

                                if (shield.health <= 0 && !crystal.IsInvulnerable)
                                {
                                    crystal.IsInvulnerable = true;

                                    shield.health = 0;
                                    foreach (var item in shield.entity.GetUnityDisplayNode().genericRenderers)
                                    {
                                        item.material.mainTexture = ModContent.GetTexture<IdkWhatToNameThisMod>("InertCrystal");
                                    }
                                }


                            }
                            if (shield.health == 0 && shieldTimer > 2000)
                            {
                                crystal.IsInvulnerable = false;

                                shield.health = (int)((boss.bloonModel.maxHealth * 0.05f) * extra);
                                foreach (var item in shield.entity.GetUnityDisplayNode().genericRenderers)
                                {
                                    item.material.mainTexture = ModContent.GetTexture<IdkWhatToNameThisMod>("RedCrystal");
                                }
                                shieldTimer = 0;
                            }
                        }
                        count++;
                    }
                }
                else
                {
                    foreach (CrystalFragment shield in shieldsCrystals)
                    {

                      
                       Bloon crystal = InGame.instance.bridge.GetBloonFromId(shield.crystalId);
                        if (crystal != null)
                        {
                            crystal.IsInvulnerable = true;
                            crystal.baseScale = 0;
                            Hide(shield.entity);
                        }

                      
                    }
                }
            }
           public void ProcessFinal(Bloon boss)
            {

               
                Entity bossCoreEntity = bossEffects["Core"];
                bossCoreEntity.GetDisplayNode().rotation.value = boss.Rotation;
               Vector3 pos = boss.Position;
                if (animTimer > 20 && blackListProgress < 500)
                {
                    bool finished = true;
                    if (blackListProgress < fragmentBones.Count())
                    {
                        boss.GetUnityDisplayNode().RemoveBone(fragmentBones[blackListProgress]);


                        InGame.instance.bridge.simulation.SpawnEffect(new PrefabReference("b1324f2f4c3809643b7ef1d8c112442a"), lastPosition, 0, 3, 2);
                        blackListProgress++;
                        finished = false;
                    }
                   

                    for (int i = 0; i < 10; i++)
                    {
                        if (fractureProgress < crystalBones.Count)
                        {
                            if (boss.GetUnityDisplayNode().GetBone(crystalBones[fractureProgress]) != null)
                            {
                                boss.GetUnityDisplayNode().RemoveBone(crystalBones[fractureProgress]);
                              
                            }

                            finished = false;
                        }
                        fractureProgress++;
                    }
                    
                    if (!finished)
                    {
                        boss.GetBloonBehaviors<SpawnBloonsAction>()[1].PerformAction();
                    }
                    else
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            empowerment[i] = 0;
                            UpdateExtraInfo(i);
                        }
                        blackListProgress += 1000;
                    }
                    animTimer = 0;
                }

                float baseHP = boss.bloonModel.maxHealth * 0.02f;
                float bonus = empowerment[7] * 0.05f;
                baseHP *= (1 + bonus);
                foreach (BloonToSimulation bloonSim in InGame.instance.bridge.GetAllBloons().ToList())
                {
                    Bloon crystal = bloonSim.GetBloon();
                    if (crystal.bloonModel.id.Contains("FinalFragment"))
                    {

                        
                            
                        if (crystal.health > baseHP)
                        {
                            crystal.health = (int)(baseHP);
                        }
                        
                            crystal.trackSpeedMultiplier = 1f;


                            
                                    finalCount++;

                        
                            if(crystal.PercThroughMap() > 0.98f)
                        {
                            crystal.Move(-crystal.path.Length);
                        }
                        
                    }
                }
                
                finalResistance = Math.Min(finalCount * 0.05f, 1);
                bossPanelController.extraHPText = " (" + (int)(finalResistance * 100f) + "%)";


                if (fractureProgress > 20)
                {
                    bossPanelController.fakeHealth = boss.health;
                    bossPanelController.fakeMaxHealth =(int)( boss.bloonModel.maxHealth * 0.125f);
                   bossCoreEntity.GetDisplayNode().position.Set(boss.Position);
                    boss.GetDisplayNode().position.Set(pos);
                    boss.IsInvulnerable = false;
                    boss.trackSpeedMultiplier = 1;

                    finalCount = 0;
                   
                }
                else
                {
                    float offsetX = Math.Sin(animTimer / 10f) * 5;
                    pos.x += offsetX;
                    boss.GetDisplayNode().position.Set(pos);
                    bossCoreEntity.GetDisplayNode().position.Set(pos);
                    boss.trackSpeedMultiplier = 0;
                    boss.IsInvulnerable = true;

                    boss.health = (int)(boss.bloonModel.maxHealth * 0.125f);
                }
            }
       
            public void ProcessHalves(Bloon boss)
            {

                boss.IsInvulnerable = true;
                if(splitProgress == 0)
                {
                    
                }

                if (TimeManager.FastForwardActive)
                {
                    splitProgress += 3;

                }
                else
                {
                    splitProgress++;
                }
                

                boss.baseScale = 0;
                if (halfCrystals[0].health <= 0 && halfCrystals[1].health <= 0)
                {

                    if (bossEffects.ContainsKey("RightBreak"))
                    {
                        Hide(bossEffects["RightBreak"]);
                    }
                    if (bossEffects.ContainsKey("LeftBreak"))
                    {
                        Hide(bossEffects["LeftBreak"]);
                    }

                    Bloon left = InGame.instance.bridge.GetBloonFromId(halfCrystals[1].crystalId);
                    left.trackSpeedMultiplier =20;
                    halfCrystals[1].entity.GetDisplayNode().position.Set(left.Position);
                    halfCrystals[1].entity.GetDisplayNode().rotation.value = left.Rotation;
                    

                    Entity entity = bossEffects["Core"];
                    entity.GetDisplayNode().position.Set(left.Position);

                   

                    Bloon right= InGame.instance.bridge.GetBloonFromId(halfCrystals[0].crystalId);
                    right.trackSpeedMultiplier = 0;
                    halfCrystals[0].entity.GetDisplayNode().position.Set(right.Position);
                    halfCrystals[0].entity.GetDisplayNode().rotation.value = right.Rotation;
               

                    Entity entity2 = bossEffects["Core2"];
                    entity2.GetDisplayNode().position.Set(right.Position);


                    
                    entity.GetUnityDisplayNode().Scale = new UnityEngine.Vector3(2,2,2);
                    entity2.GetUnityDisplayNode().Scale = new UnityEngine.Vector3(2, 2, 2);

                    if (boss.PercThroughMap() < right.PercThroughMap())
                    {
                        boss.trackSpeedMultiplier = 200;

                    }
                    else
                    {
                        boss.trackSpeedMultiplier = 0;
                    }
                    if (left.PercThroughMap() > right.PercThroughMap())
                    {
                        state = CrystalState.Active;
                        left.baseScale = 0;
                        right.baseScale = 0;
                        Hide(bossEffects["Core2"]);
                       Hide( entity);
                        Hide(halfCrystals[0].entity);
                        Hide(halfCrystals[1].entity);
                    }

                }
                else
                {
                    bool a = AnimateHalf(boss, halfCrystals[0]);
                    bool b = AnimateHalf(boss, halfCrystals[1]);
                    if (a || b)
                    {
                        showPanel = true;

                    }
                }
                
            }
            public bool AnimateHalf(Bloon boss, CrystalFragment half)
            {
                bool show = false;
                Bloon bloon = InGame.instance.bridge.GetBloonFromId(half.crystalId);


                float timeMult = 1;
                var scale = 2 + (Math.Sin(splitProgress / 20f));
               
                if (TimeManager.FastForwardActive)
                {
                    timeMult = 3;
                }
                if (splitProgress == 0)
                {
                  
                }
                else if (splitProgress < 125)
                {
                    boss.trackSpeedMultiplier = 0;
                    boss.baseScale = 0;

                    half.percThroughTrack = boss.PercThroughMap();
                    if (splitProgress < 50)
                    {
                       
                        float offset = Math.Sin(splitProgress);
                        var pos = new Vector3(boss.Position.X + offset, boss.Position.Y, 0);
                        half.renderPosition = pos;

                    }
                    else if (splitProgress < 100)
                    {
                        float offset = (splitProgress - 50);

                        if (half.bossPart == "Left")
                        {
                          
                            half.renderPosition = new Vector3(boss.Position.X - offset, boss.Position.Y, 0);
                        }
                        else
                        {
                           
                            half.renderPosition = new Vector3(boss.Position.X + offset, boss.Position.Y, 0); 
                        }
                    }
                }
                else if (splitProgress < 250)
                {
     
                    float diffX = half.renderPosition.x - bloon.Position.X;
                    float diffY = half.renderPosition.y - bloon.Position.Y;

                    half.renderPosition.x -= diffX * 0.05f * timeMult;
                    half.renderPosition.y -= diffY * 0.05f;

                    float rotDiff = bloon.Rotation - half.entity.GetDisplayNode().rotation.value;
                    half.entity.GetDisplayNode().rotation.value += rotDiff * 0.005f;
                }
                if(splitProgress > 150)
                {

                    
                    
                    if (splitProgress >= 250)
                    {
                       
                        
                        
                        
                        half.renderPosition = bloon.Position;
                        if (half.bossPart == "Left")
                        {
                            

                            half.time += timeMult;
                            if(half.time > 30)
                            {
                                bloon.trackSpeedMultiplier = 0.4f;
                                half.time = 0;
                            }
                            else
                            {
                                bloon.trackSpeedMultiplier = -0.4f;
                            }
                            
                        }
                        else
                        {

                            bloon.trackSpeedMultiplier = 0.3f;

                        }
                        UnityEngine.Vector2 mouse = InGame.instance.inputManager.cursorPositionWorld;
                        float dist = Vector2.Distance(mouse, bloon.Position.ToVector2().ToUnity());
                        bloon.IsInvulnerable = false;
                        if (dist < 30)
                        {

                            string text = "<> \n When destroyed, empowers all attached \n fragments until both halves are destroyed";
                            if(half.bossPart == "Left")
                            {
                                text = "Right Half \n" + text;
                            }
                            else
                            {
                                text = "Left Half \n" + text;
                            }
                            text = text.Replace("<>", half.health + "/" + half.maxHealth);
                            bossInfoText.Text.text = text;

                            mouse.y -= 30;
                            infoPanel.gameObject.transform.position = ToUnityPos(mouse);

                            //  bossInfoText.Text.autoSizeTextContainer = true;

                            bossInfoText.Text.rectTransform.sizeDelta = infoPanel.RectTransform.sizeDelta = new Vector2(bossInfoText.Text.GetPreferredValues().x + 20, bossInfoText.Text.GetPreferredValues().y + 20);
                         
                            //, bossInfoText.Text.GetPreferredHeight());
                           show = true;

                        }

                        if (bloon.health < bloon.bloonModel.maxHealth)
                        {
                            int amount = bloon.bloonModel.maxHealth - bloon.health;
                            half.health -= amount;
                           
                        }
                        if (half.health <= 0)
                        {
                            bloon.IsInvulnerable = true;
                            half.health = 0;

                        }
                        half.entity.GetDisplayNode().rotation.value = bloon.Rotation;

                    }
                }
                else
                {
                    half.maxHealth = half.health = (int) (boss.bloonModel.maxHealth * 0.5f);
                    
                    if (half.bossPart == "Left")
                    {
                        PositionCrystal(InGame.instance.bridge.GetBloonFromId(half.crystalId), boss.PercThroughMap() - 0.3f);
                        

                    }
                    else
                    {

                        PositionCrystal(InGame.instance.bridge.GetBloonFromId(half.crystalId), boss.PercThroughMap() + 0.3f);
                    }
                    
                }
                bloon.health = bloon.bloonModel.maxHealth;
                bloon.baseScale = 0;
                half.entity.GetDisplayNode().position.Set(half.renderPosition);
                half.entity.GetDisplayNode().rotation.value = bloon.Rotation;


                if (half.bossPart == "Left")
                {
                    Entity entity = bossEffects["Core"];

                    entity.GetDisplayNode().position.Set(half.renderPosition);
                    
                    entity.GetUnityDisplayNode().Scale = new UnityEngine.Vector3(scale, scale, scale);
                    entity.GetUnityDisplayNode().rotation = bloon.Rotation;
                    if (halfCrystals[0].health <= 0)
                    {
                        if (half.charge)
                        {
                            half.charge = false;
                            for (int i = 0; i < 8; i++)
                            {
                                if (i % 2 == 1)
                                {
                                    empowerment[i]++;
                                    UpdateExtraInfo(i);
                                }
                            }
                        }

                        var pos = halfCrystals[0].renderPosition;
                        if (half.hits == 0)
                        {
                        
                            bossEffects["LeftBreak"] = InGame.instance.bridge.simulation.SpawnEffect(ModContent.CreatePrefabReference<BossDisplayRightBreak>(),pos, 0, 10, -1);
                            half.hits++;
                        }
                        else if (half.hits == 1)
                        {
                            HideInertCrystals(bossEffects["LeftBreak"]);
                            half.hits++;
                        }
                        else
                        {
                            bossEffects["LeftBreak"].GetDisplayNode().position.Set(pos);
                            bossEffects["LeftBreak"].GetDisplayNode().rotation.value = timeExisted;
                        }
                        Hide(halfCrystals[0].entity);
                        
                        bloon.trackSpeedMultiplier = 0;
                        bloon.baseScale = 0;
                       
                       
                    }
                }
                else
                {
                    Entity entity = bossEffects["Core2"];

                    entity.GetDisplayNode().position.Set(half.renderPosition);
                    entity.GetUnityDisplayNode().Scale = new UnityEngine.Vector3(scale, scale, scale);
                    entity.GetUnityDisplayNode().rotation = bloon.Rotation;
                    if (halfCrystals[1].health <= 0)
                    {
                        if (half.charge)
                        {
                            half.charge = false;
                            for (int i = 0; i < 8; i++)
                            {
                                if (i % 2 == 0)
                                {
                                    empowerment[i]++;
                                    UpdateExtraInfo(i);
                                }
                            }
                        }
                        
                      

                        var pos = halfCrystals[1].renderPosition;
                        if (half.hits == 0)
                        {
                            bossEffects["RightBreak"] = InGame.instance.bridge.simulation.SpawnEffect(ModContent.CreatePrefabReference<BossDisplayLeftBreak>(),pos, 0, 10, -1);

                            half.hits++;
                        }
                        else if(half.hits == 1)
                        {
                            HideInertCrystals(bossEffects["RightBreak"]);
                            half.hits++;
                        }
                        else
                        {
                            bossEffects["RightBreak"].GetDisplayNode().rotation.value = timeExisted;
                            bossEffects["RightBreak"].GetDisplayNode().position.Set(pos);
                        }
                        Hide(halfCrystals[1].entity);
                        
                        bloon.trackSpeedMultiplier = 0;
                        bloon.baseScale = 0;
                     
                       
               
                    }
                }
                if (!active)
                {
                   bloon.baseScale = 0;
                }
                return show;
            }
            

            public void UpdateExtraInfo(int index)
            {
                string text = "";
                if (index <= 3)
                {
                    float percentage = 1f / (1f + (empowerment[index] * 0.02f));

                    resistanceMultiplier[index] = percentage;



                    text = ((int)((1f - percentage) * 100)) + "%";

                }
               else
                { 
                    text = (int)(empowerment[index]*5) + "%";
                }
                bossPanelController.ChangeExtraInfoText(index, text, true);
            }
            public bool CrystalTransit(Projectile emission, CrystalFragment fragment, Bloon destination)
            {
                bool landed = false;
                if (emission != null)
                {


                    fragment.renderPosition = emission.Position.ToVector3();
                    ArriveAtTarget arrive = emission.GetProjectileBehavior<ArriveAtTarget>();
                    var scale = emission.Scale.ToUnity();
                    fragment.entity.GetUnityDisplayNode().Scale = new UnityEngine.Vector3(scale.x * 10, scale.y * 10, scale.z * 10);
                    if (arrive != null)
                    {
                        if (arrive.perc > 0.95f)
                        {

                            landed = true;

                        }
                        else if(!fragment.fixedColor)
                        {
                            if(fragment.entity.GetUnityDisplayNode() != null)
                            {
                                if (fragment.type == CrystalType.Empower)
                                {

                                    fragment.entity.GetUnityDisplayNode().genericRenderers.ForEach(x => x.material.mainTexture = ModContent.GetTexture<IdkWhatToNameThisMod>(fragment.bossPart.Replace("Fragment", "Crystal")));
                                }
                                else if(fragment.type == CrystalType.Stunning)
                                {
                                    fragment.entity.GetUnityDisplayNode().genericRenderers.ForEach(x => x.material.mainTexture = ModContent.GetTexture<IdkWhatToNameThisMod>("ShockShard"));

                                }
                                fragment.fixedColor = true;
                            }
                        }
                    }
                    else
                    {
                        landed = true;

                    }
                }
                else
                {
                    landed = true;
                }
                if (landed)
                {

                    fragment.fixedColor = false;
                }
                return landed;
            }
            public void RegisterEmpower(ObjectId id)
            {
                Entity e = null;
               if (empowerCrystals.Count < 4)
                {
                     e = InGame.instance.bridge.simulation.SpawnEffect(ModContent.CreatePrefabReference<ResistanceFragment>(), new Vector3(0, 0, 0), 0, 10, -1);

                }
                else
                {
                     e = InGame.instance.bridge.simulation.SpawnEffect(ModContent.CreatePrefabReference<MechanicFragment>(), new Vector3(0, 0, 0), 0, 10, -1);

                }
               
                var c = new CrystalFragment(e, id, new Vector3(0, 0, 0), CrystalType.Empower, fragmentNames[empowerCrystals.Count] + "Fragment");

                int index = random.Next(0, validEmpowerPositioning.Count - 1);
                c.percThroughTrack = validEmpowerPositioning[index];
                validEmpowerPositioning.RemoveAt(index);
                empowerCrystalsById[id] = c;
                empowerCrystals.Add(c);
                bossEffects["CrystalEffect" + bossEffects.Count] = e;
            }
            public void RegisterShield(ObjectId id)
            {

                Entity e = InGame.instance.bridge.simulation.SpawnEffect(ModContent.CreatePrefabReference<BloontoniumShardShield>(), new Vector3(200, 0, 0), 0, 10, -1);

                var c = new CrystalFragment(e, id, new Vector3(200, 200, 0), CrystalType.Shield, "Shield" + (shieldsCrystals.Count + 1));
                c.percThroughTrack = 0;
               shieldsById[id] = c;
                shieldsCrystals.Add(c);
                bossEffects["CrystalEffect" + bossEffects.Count] = e;
            }
          
            public void RegisterStunning(ObjectId id)
            {

                Entity e = InGame.instance.bridge.simulation.SpawnEffect(ModContent.CreatePrefabReference<ShockShard>(), new Vector3(200, 0, 0), 0, 15, -1);

                var c = new CrystalFragment(e, id, new Vector3(200, 200, 0), CrystalType.Stunning, "Stun" + (stunCrystals.Count + 1));
                c.percThroughTrack = 0;
                stunCrystalsById[id] = c;
                stunCrystals.Add(c);
                bossEffects["CrystalEffect" + bossEffects.Count] = e;
            }
         
            public void RegisterHalves(ObjectId id)
            {
            
                if (halfCrystals.Count > 0)
                {
                    Entity e = InGame.instance.bridge.simulation.SpawnEffect(ModContent.CreatePrefabReference<BossDisplayLeft>(), new Vector3(200, 200, 0), 0, 10, -1);

                    var c = new CrystalFragment(e, id, new Vector3(200, 200, 0), CrystalType.Split, "Left");
                    c.percThroughTrack = 0;
                    halvesById[id] = c;
                    halfCrystals.Add(c);
                    bossEffects["CrystalEffect" + bossEffects.Count] = e;
                }
                else
                {
                    Entity e = InGame.instance.bridge.simulation.SpawnEffect(ModContent.CreatePrefabReference<BossDisplayRight>(), new Vector3(200, 200, 0), 0, 10, -1);

                    var c = new CrystalFragment(e, id, new Vector3(200, 200, 0), CrystalType.Split, "Right");
                    c.percThroughTrack = 0;
                    halvesById[id] = c;
                    halfCrystals.Add(c);
                    bossEffects["CrystalEffect" + bossEffects.Count] = e;
                }
               

             
            }
            public void ApplyCrystalPassiveImmunity()
            {
                InGame.instance.bridge.GetBloonFromId(empowerCrystals[0].crystalId).ApplyTowerSetImmunity(TowerSet.Primary);
                InGame.instance.bridge.GetBloonFromId(empowerCrystals[1].crystalId).ApplyTowerSetImmunity(TowerSet.Military);
                InGame.instance.bridge.GetBloonFromId(empowerCrystals[2].crystalId).ApplyTowerSetImmunity(TowerSet.Magic);
                InGame.instance.bridge.GetBloonFromId(empowerCrystals[3].crystalId).ApplyTowerSetImmunity(TowerSet.Support);
            }
            public void EmitCrystal(int index, Bloon boss, bool invert = false, CrystalType type = CrystalType.Empower, Tower tower = null)
            {
                CrystalFragment fragment = empowerCrystals[index];

                Vector3 target = InGame.instance.bridge.GetBloonFromId(empowerCrystals[index].crystalId).Position;

                if (type == CrystalType.Stunning)
                {
                    fragment = stunCrystals[index];
                    if (invert)
                    {
                        target = fragment.renderPosition;
                    }
                    else
                    {
                        target = tower.Position;
                    }


                }
                if (invert)
                {
                    fragment.state = CrystalState.Retrieving;
                }
                else
                {
                   
                    state = CrystalState.Emitting;
                    fragment.state = CrystalState.Emitting;

                    ToggleBossPart(boss, fragment.bossPart);
                }
                Vector3 poss = boss.Position;

                if (!invert)
                {
                    var offsetx = crystalOffset[index];
                    var offsety = 0;

                    float angle = Math.Atan2(offsetx, offsety) + (boss.Rotation * 0.01745329f);
                    float dist = Math.Sqrt((offsetx * offsetx) + (offsety * offsety));
                    poss.x += Math.Sin(angle) * dist;
                    poss.y += Math.Cos(angle) * dist;
                }

               

                var proj = InGame.instance.GetMainFactory().CreateEntityWithBehavior<Projectile, ProjectileModel>(fireBall);

                proj.pierce = 1000;

                proj.canCollideWithBloons = false;

                proj.emittedBy = null;
                proj.Position.Z = 0;

                fragment.movement = proj;
                if (invert)
                {


                    ArriveAtTarget arrive = proj.GetProjectileBehavior<ArriveAtTarget>();

                
                    proj.Position.Set(target);
                    arrive.startPos = target;

                    proj._target = proj.target = new Target(poss);
                    arrive.targetPos = poss;
                    arrive.SetTarget(proj.target);
                }
                else
                {

                    proj.Position.Set(poss);

                    ArriveAtTarget arrive = proj.GetProjectileBehavior<ArriveAtTarget>();
                    arrive.startPos = proj.Position;
                    
                    proj._target = proj.target = new Target(target);
                    arrive.targetPos = target;
                    arrive.SetTarget(proj.target);
                }
            }
            public void SetCrystalRockBloonHP(Bloon boss)
            {
                // Sets the health of Crystal Rock Bloons. This is run when the boss spawns
                // and after empowerment, as their health maybe increased by empowerment
                float baseHP = boss.bloonModel.maxHealth * 0.005f;
                float bonus = empowerment[5] * 0.05f;
                baseHP *= ( 1 + bonus);
                rockBloonHealth = (int)baseHP;
            }
            public void ApplyEffects(Bloon boss)
            {

                //   linkedEffects.Add(InGame.instance.bridge.simulation.SpawnEffect(ModContent.CreatePrefabReference<Shadows>(), boss.Position, 0, 1f, -1));
                //   linkedEffects.Add(InGame.instance.bridge.simulation.SpawnEffect(ModContent.CreatePrefabReference<Shadows>(), boss.Position, 0, 2, -1));
                //   linkedEffects.Add(InGame.instance.bridge.simulation.SpawnEffect(ModContent.CreatePrefabReference<Shadows>(), boss.Position, 0, 3, -1));
                var pos = boss.Position;
              
               bossEffects["Core"] = InGame.instance.bridge.simulation.SpawnEffect(ModContent.CreatePrefabReference<EffectBall>(), pos, 0, 4, -1);
                new AnimationState("Launch", 150, ModContent.CreatePrefabReference<BossLaunch>(), 10);
                new AnimationState("StartUp", 75, ModContent.CreatePrefabReference<BossStartUp>(), 10);
                new AnimationState("Charge", 999999999, ModContent.CreatePrefabReference<BossCharge>(), 10);


                bossEffects["Core2"] = InGame.instance.bridge.simulation.SpawnEffect(ModContent.CreatePrefabReference<EffectBall>(), new Vector3(200,200,0), 0, 4, -1);

                //   linkedEffects.Add(InGame.instance.bridge.simulation.SpawnEffect(ModContent.CreatePrefabReference<GlowEffectBlack>(), pos, 0, 4, -1));

                //   linkedEffects.Add(InGame.instance.bridge.simulation.SpawnEffect(ModContent.CreatePrefabReference<GlowEffectBlue>(), pos, 180, 4, -1));


            }
            public bool PositionCrystal(Bloon crystal, float percentage)
            {

                float perc = crystal.PercThroughMap();
                percentage = Math.Min(percentage, 0.9f);
                percentage = Math.Max(percentage, 0.05f);
                if (perc > percentage + 0.02f)
                {
                    crystal.trackSpeedMultiplier = -2;
                }
                else if (perc < percentage - 0.02f)
                {
                    crystal.trackSpeedMultiplier = 2;
                }
                else
                {

                    crystal.trackSpeedMultiplier = 0;
                    return true;
                }
               
                
                return false;
            }
            public void ProcessEmpowerFragments(Bloon boss)
            {


                UnityEngine.Vector2 mouse = InGame.instance.inputManager.cursorPositionWorld;

                int empowering = 0;

                for (int index = 0; index < 8; index++)
                {
                    var fragment = empowerCrystals[index];

                    Bloon crystal = InGame.instance.bridge.GetBloonFromId(fragment.crystalId);
                    //  crystal.baseScale = 0;
                    crystal.IsInvulnerable = fragment.state != CrystalState.Active;

                    if (fragment.state == CrystalState.Active || fragment.state == CrystalState.Emitting)
                    {
                        empowering++;
                    }


                    PositionCrystal(crystal, fragment.percThroughTrack);

                    if (crystal.Position.Distance(boss.Position) < 30)
                    {
                        if (boss.PercThroughMap() > 0.5f)
                        {
                            fragment.percThroughTrack -= 0.001f;
                        }
                        else
                        {
                            fragment.percThroughTrack += 0.001f;
                        }
                    }

                    if (fragment.state == CrystalState.Idle)
                    {
                        float rotation = (timeExisted / 200f) + (30 * empowerCrystals.IndexOf(fragment));

                        float posX = (float)Math.Sin(rotation) * 40;
                        float posY = (float)Math.Cos(rotation) * 40;

                        fragment.renderPosition = new Vector3(200, 200, 0);

                        //posX + boss.Position.X, posY + boss.Position.Y, 0);


                        // crystal.entity.GetDisplayNode().position.Set(fragment.renderPosition);
                    }
                    else if (fragment.state == CrystalState.Emitting)
                    {
                        Projectile emission = fragment.movement;

                        crystal.health = crystal.bloonModel.maxHealth;
                        if (CrystalTransit(emission, fragment, crystal))
                        {
                            Vector3 pos = crystal.Position;

                            bossEffects["GlowEmpower"+index] = fragment.glow = InGame.instance.bridge.simulation.SpawnEffect(ModContent.CreatePrefabReference<GlowEffectWhite>(), pos, 0, 1, 0 - 1);
                            fragment.state = state = CrystalState.Active;
                            fragment.health = fragment.maxHealth = (int)(boss.bloonModel.maxHealth * 0.15f);
                            bossScript.PlayAnimation("StartUp");

                        }
                    }
                    else if (fragment.state == CrystalState.Active)
                    {

                        fragment.renderPosition = crystal.Position.ToVector3();

                        crystal.Rotation = timeExisted / 5f;

                        crystal.baseScale = 2;
                        float dist = Vector2.Distance(mouse, crystal.Position.ToVector2().ToUnity());

                        if (dist < 30)
                        {
                            string text = fragmentDescriptions[empowerCrystals.IndexOf(fragment)];
                            text = text.Replace("<>", fragment.health + "/" + fragment.maxHealth);
                            bossInfoText.Text.text = text;

                            mouse.y -= 20;
                            infoPanel.gameObject.transform.position = ToUnityPos(mouse);

                            //  bossInfoText.Text.autoSizeTextContainer = true;

                            bossInfoText.Text.rectTransform.sizeDelta = infoPanel.RectTransform.sizeDelta = new Vector2(bossInfoText.Text.GetPreferredValues().x + 20, bossInfoText.Text.GetPreferredValues().y + 20);

                            //, bossInfoText.Text.GetPreferredHeight());
                            showPanel = true;

                        }

                        if (crystal.health < crystal.bloonModel.maxHealth)
                        {
                            int diff = crystal.bloonModel.maxHealth - crystal.health;
                            fragment.health -= diff;
                            crystal.health = crystal.bloonModel.maxHealth;

                            if (fragment.health <= 0)
                            {
                                crystal.baseScale = 0;
                                fragment.state = CrystalState.Retrieving;
                                EmitCrystal(index, boss, true);
                                fragment.glow.Destroy();
                            }
                        }
                        if (fragment.charge)
                        {
                            fragment.charge = false;
                            bossScript.empowerment[index]++;
                            bossScript.UpdateExtraInfo(index);
                        }

                    }
                    else if (fragment.state == CrystalState.Retrieving)
                    {
                        Projectile emission = fragment.movement;

                        crystal.health = crystal.bloonModel.maxHealth;
                        if (CrystalTransit(emission, fragment, crystal))
                        {
                            ToggleBossPart(boss, fragment.bossPart, true);
                            fragment.state = CrystalState.Idle;

                        }
                    }
                    fragment.entity.GetDisplayNode().position.Set(fragment.renderPosition);

                    if(index == 7)
                    {
                      
                       
                           
                           fragment.hits = empowering;
                        
                    }
                }

                if (CrystalState.Idle != state)
                {
                    if (empowering > 0)
                    {

                        bossPanelController.fakeHealth = empowering;
                        bossPanelController.healthBar = PHAYZEBAR;
                        if (empowering > bossPanelController.fakeMaxHealth)
                        {
                            bossPanelController.fakeMaxHealth = empowering;
                        }

                    }
                    else
                    {
                       
                        SetCrystalRockBloonHP(boss);
                        bossPanelController.healthBar = HEALTHBAR;
                        state = CrystalState.Idle;
                        bossPanelController.fakeMaxHealth = bossPanelController.fakeHealth = -1;
                    }
                }
            
            }
            public void ToggleBossPart(Bloon boss, string bone, bool enable = false)
            {

                    boss.GetUnityDisplayNode().GetBone(bone).gameObject.active = enable;

                    foreach (var state in animState)
                    {
                        bossEffects[state.Value.effectId].GetUnityDisplayNode().GetBone(bone).gameObject.active = enable;
                    }
                
            }
            public void PlayAnimation(string id)
            {
                animTimer = 0;
                activeAnimation = id;
                var animation = animState[id];
                Entity effect = bossEffects[animation.effectId];

               
                effect.GetUnityDisplayNode().gameObject.transform.localScale = new UnityEngine.Vector3(animation.scale, animation.scale, animation.scale);
                if(id == "StartUp")
                {
                    
                    if (CrystalState.Idle != state)
                    {
                        effect.GetUnityDisplayNode().gameObject.GetComponent<Animator>().SetTrigger("Start");
         
                    }
                    else
                    {
                        effect.GetUnityDisplayNode().gameObject.GetComponent<Animator>().SetTrigger("End");
                    }
                   
                }
                
                effect.GetUnityDisplayNode().gameObject.GetComponent<Animator>().Play("Scene", 0, 0);
                
            
            }

            public void SetHiddenCrystals(Bloon boss)
            {
               
                for (int i = 0; i < 4; i++)
                {
                    if (i > registration.tier - 2)
                    {
               
                        inertCrystals.Add(inertFragments[i]);
                    
                    }
                }
                HideInertCrystals(boss.Entity);
            }
            public void HideInertCrystals(Entity entity)
            {

      
                foreach (Renderer renderer in entity.GetUnityDisplayNode().genericRenderers)
                {
                    if (!renderer.name.Contains("Crystal"))
                    {
                        if (inertCrystals.Contains(renderer.name))
                        {
                          
                            renderer.SetMainTexture(ModContent.GetTexture<IdkWhatToNameThisMod>("GreyCrystal"));
                        }
                        else
                        {
                           
                        }
                    }
                }
            }
            public void ProcessShockShards(Bloon boss)
            {


                UnityEngine.Vector2 mouse = InGame.instance.inputManager.cursorPositionWorld;
    
                var towerList = InGame.instance.bridge.GetAllTowers().ToList().OrderByDescending(x => x.damageDealt).ToList();
               

                for (int index = 0; index < stunCrystals.Count; index++)
                {

                   

                    var fragment = stunCrystals[index];

                    Bloon crystal = InGame.instance.bridge.GetBloonFromId(fragment.crystalId);
                    
                    crystal.nonTargetable = fragment.state != CrystalState.Active;

                    if (towerList.Count > index && stunCrystalsQuened > 0)
                    {
                       
                        stunCrystals[index].bloonPlacement = towerList[index].tower.Position;

                        
                    }

                    if (fragment.state == CrystalState.Idle)
                    {

                        crystal.health = crystal.bloonModel.maxHealth;


                    }
                    else if (fragment.state == CrystalState.Emitting)
                    {
                        Projectile emission = fragment.movement;

                        crystal.health = crystal.bloonModel.maxHealth;
                        fragment.time = 100;
                        if (CrystalTransit(emission, fragment, crystal))
                        {
                            crystal.Position.Set(stunCrystals[index].bloonPlacement);

                            fragment.state = state = CrystalState.Active;

                            float bonus = 1 +(empowerment[4] * 0.05f);

                            fragment.health = fragment.maxHealth = (int)(boss.bloonModel.maxHealth * 0.06f * bonus);

                        }
                    }
                    else if (fragment.state == CrystalState.Active)
                    {

                        fragment.renderPosition = crystal.Position.ToVector3();

                        float dist = Vector2.Distance(mouse, crystal.Position.ToVector2().ToUnity());
                     
                        if (TimeManager.FastForwardActive)
                        {
                            fragment.time -= 0.3f;
                        }
                        else
                        {
                            fragment.time -= 0.1f;
                        }
                        if (dist < 30)
                        {
                          
                            string text = "Shock Shard \n<>\n\n Stuns nearby towers and \ntransfers some of its remaining health \nto the boss if not destroyed in time";
                            text = text.Replace("<>", fragment.health + "/" + fragment.maxHealth + " " + (int)(fragment.time/10f) + "s");

                            
                            bossInfoText.Text.text = text;

                            mouse.y -= 20;
                            infoPanel.gameObject.transform.position = ToUnityPos(mouse);

                            //  bossInfoText.Text.autoSizeTextContainer = true;

                            bossInfoText.Text.rectTransform.sizeDelta = infoPanel.RectTransform.sizeDelta = new Vector2(bossInfoText.Text.GetPreferredValues().x + 20, bossInfoText.Text.GetPreferredValues().y + 20);

                            //, bossInfoText.Text.GetPreferredHeight());
                            showPanel = true;

                        }
                        bool retrieve = false;
                        if (crystal.health < crystal.bloonModel.maxHealth)
                        {
                            int diff = crystal.bloonModel.maxHealth - crystal.health;
                            fragment.health -= diff;
                            crystal.health = crystal.bloonModel.maxHealth;

                            if (fragment.health <= 0)
                            {
                                
                                retrieve = true;
                            }
                        }
                        if(fragment.time <= 0)
                        {
                            retrieve=true;
                            boss.health +=(int)( (fragment.health/registration.tier)/ (1f + (empowerment[4] * 0.05f)));

                            int bonus = 10 * empowerment[4];

                            InGame.instance.bridge.simulation.SpawnEffect(new PrefabReference("1cdc6188657f8524bba43fcf988d9149"), crystal.Position, 0, 1);
                            
                            foreach (TowerToSimulation simt in InGame.instance.bridge.GetAllTowers().ToList())
                            {
                                if(simt.tower.Position.Distance(crystal.Position) <40 )
                                {
                                    if (simt.tower.towerModel.isParagon)
                                    {
                                        simt.tower.AddMutator(stun, 200 + bonus, true, true, false, true, false, false, false, -1, true);
                                    }
                                    else
                                    {
                                        simt.tower.AddMutator(stun, 200 + bonus);
                                    }
                                }
                            }
                        }
                        if (retrieve)
                        {
                            fragment.state = CrystalState.Retrieving;
                            EmitCrystal(index, boss, true, CrystalType.Stunning);
                            stunCrystals[index].bloonPlacement = new Vector3(200, 200, 0);
                        }

                    }
                    else if (fragment.state == CrystalState.Retrieving)
                    {
                        Projectile emission = fragment.movement;

                        crystal.health = crystal.bloonModel.maxHealth;
                        if (CrystalTransit(emission, fragment, crystal))
                        {
                            ToggleBossPart(boss, fragment.bossPart, true);
                            fragment.renderPosition = new Vector3(200, 200, 0);
                            fragment.state = CrystalState.Idle;

                        }
                    }
                    fragment.entity.GetDisplayNode().position.Set(fragment.renderPosition);

                    
                }
                if (stunCrystalsQuened > 0 && state == CrystalState.Idle && stunCrystals[0].state == CrystalState.Idle)
                {

                   
                    for (int i = 0; i < stunCrystals.Count; i++)
                    {
                        
                        if (towerList.Count > i)
                        {
                            
                            EmitCrystal(i, boss, false, CrystalType.Stunning, towerList[i].tower);

                        }
                    }
                    stunCrystalsQuened--;
                }

            }


            public class AnimationState
            {
                public string effectId = "";
                public int timeActive = 0;
                public int cancel = 200;
                public float scale = 0;
                public int coreRaise = 0;
             
                public AnimationState(string effectId, int cancel, PrefabReference prefab, int coreRaise = 0)
                {
                    this.effectId = effectId;
                    this.cancel = cancel;
                    animState[effectId] = this;

                    bossEffects[effectId] = InGame.instance.bridge.simulation.SpawnEffect(prefab, new Vector3(200, 200, 0), 0, 10, -1);
               this.coreRaise = coreRaise;

                }

            }

        }
        public static void Hide(Entity entity)
        {
            entity.GetDisplayNode().position.Set(new Vector3(300, 300, 0));
        }
        public static UnityEngine.Vector3 ToUnityPos(UnityEngine.Vector3 vec)
        {

            vec.y *= -1f;

            vec = InGame.instance.GetUIFromWorld(vec, false);

            return vec;
        }

    }



}
