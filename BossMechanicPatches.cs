using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UsesBossHandlerNamespace.Bosses;
using Il2CppAssets.Scripts.Simulation.Towers;
using HarmonyLib;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles;
using Il2CppAssets.Scripts.Simulation.SMath;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity.Bridge;
using MelonLoader;
using BTD_Mod_Helper.Api;
using Il2CppInterop.Runtime.Injection;
using UnityEngine;
using Il2CppSystem;
using Color = UnityEngine.Color;
using DateTimeOffset = Il2CppSystem.DateTimeOffset;
using IntPtr = Il2CppSystem.IntPtr;
using static UsesBossHandlerNamespace.IdkWhatToNameThisMod;
using Vector3 = Il2CppAssets.Scripts.Simulation.SMath.Vector3;
using UsesBossHandlerNamespace;


namespace CrystalBoss
{
    internal class BossMechanicPatches
    {
      
                [HarmonyPatch(typeof(Bloon), nameof(Bloon.Damage))]
        public class TitleScreenInits
        {
            [HarmonyPrefix]

            public static void Prefix(Tower tower, Bloon __instance, ref float totalAmount, Projectile projectile)
            {


              
                if (bossScript != null)
                {
                    if (bossScript.started)
                    {
                        if (__instance.bloonModel.id.Contains("CrystalBoss") && tower != null)
                        {
                            if (bossScript.state == CrystalState.Fractured)
                            {
                           
                                totalAmount *= (1 - bossScript.finalResistance);
                            }
                            else
                            {
                                switch (tower.towerModel.towerSet)
                                {
                                    case TowerSet.Primary:
                                        totalAmount *= bossScript.resistanceMultiplier[0];
                                        break;

                                    case TowerSet.Military:
                                        totalAmount *= bossScript.resistanceMultiplier[1];
                                        break;
                                    case TowerSet.Magic:
                                        totalAmount *= bossScript.resistanceMultiplier[2];
                                        break;
                                    case TowerSet.Support:
                                        totalAmount *= bossScript.resistanceMultiplier[3];
                                        break;
                                }
                            }
                        }
                        else if (__instance.Id == bossScript.empowerCrystals[5].crystalId)
                        {
                            if (projectile != null)
                            {
                                if (projectile.pierce < 10)
                                {
                                   
                                    totalAmount *= 0.5f;
                                }
                            }
                        }
                        else if (__instance.Id == bossScript.empowerCrystals[6].crystalId)
                        {
                            if (projectile != null)
                            {
                                totalAmount *= 0.75f;
                            }
                            else
                            {
                                totalAmount *= 1.25f;
                            }
                        }
                        else if (__instance.bloonModel.id.Contains("Shield"))
                        {
                            if (projectile != null)
                            {
                                projectile.pierce = 0;
                            }
                        }
                        else if (__instance.Id == bossScript.empowerCrystals[4].crystalId)
                        {
                            if (projectile != null)
                            {
                                bossScript.empowerCrystals[4].hits++;
                                if (bossScript.empowerCrystals[4].hits % 50 == 0)
                                {
                                    tower.AddMutator(stun, 60);
                                }
                            }
                        }
                        else if (__instance.Id == bossScript.empowerCrystals[7].crystalId)
                        {
                            
                                
                               totalAmount /= 1 + (bossScript.empowerCrystals[7].hits/10f);

                        }
                        else if (__instance.bloonModel.id.Contains("CrystalBloon"))
                        {

                            if (__instance.health > bossScript.rockBloonHealth)
                            {
                                __instance.health = (int)(bossScript.rockBloonHealth - totalAmount);


                            }
                            if (projectile != null)
                            {
                                projectile.pierce -= 9 + (bossScript.empowerment[5] / 2f);
                            }
                        }
                        else if (__instance.bloonModel.id.Contains("FinalFragment"))
                        {
                            if (projectile != null)
                            {
                                projectile.pierce -= 9 + (bossScript.empowerment[7] / 2f);
                            }
                        
                        }
                    }
                    else
                    {
                        totalAmount = 0;
                    }
                }
            }

        }
     
        
        [HarmonyPatch(typeof(InGame), nameof(InGame.RoundStart))]
        public class SegmentDetach
        {
            [HarmonyPostfix]

            public static void Postfix()
            {

             if(InGame.instance.currentRoundId == 29)
                {
                    if(fog != null)
                    {
                        fog.Destroy();
                    }
                    CutsceneSystem.StartCutscene("temple");

                    GameObject game = GameObject.Find("CubismTerrain");

                    if (game != null)
                    {

                        game.GetComponent<MeshRenderer>().material.mainTexture = ModContent.GetTexture<IdkWhatToNameThisMod>("templeMap");


                    }
                }

                if (InGame.instance.currentRoundId == 39)
                {
                    CutsceneSystem.StartCutscene("god1");
                }
            }

        }
        
        [HarmonyPatch(typeof(TimeTrigger), nameof(TimeTrigger.Trigger))]
        public class TimeTriggerEmpower
        {
            [HarmonyPrefix]

            public static void Prefix(TimeTrigger __instance)
            {
                if (bossScript != null)
                {
                    
                    if (__instance.timeTriggerModel.name.Contains("Empower"))
                    {
                       
                        if (__instance.bloon.bloonModel.name.Contains("SplitCrystal"))
                        {
                            bossScript.halvesById[__instance.bloon.Id].charge = true;
                        }
                        else
                        {

                            bossScript.empowerCrystalsById[__instance.bloon.Id].charge = true;
                            if (bossScript.registration.tier >= 3)
                            {
                                float min = __instance.bloon.PercThroughMap() - 0.03f;
                                float max = min + 0.06f;
                                // If the boss is tier 3 or higher, the empowerment crystals can absorb nearby crystal rock bloons to heal themselves
                                foreach (BloonToSimulation bloon in InGame.instance.bridge.GetAllBloons().ToList())
                                {
                                    float perc = bloon.GetBloon().PercThroughMap();
                                    if (bloon.GetBloon().bloonModel.id.Contains("CrystalBloon") && perc < max && perc > min)
                                    {
                                        InGame.instance.bridge.simulation.SpawnEffect(new Il2CppNinjaKiwi.Common.ResourceUtils.PrefabReference("d1c5c89ced4ad4e42b394ea9630a4d33"), bloon.GetBloon().Position, 0, 2, 3);
                                        bossScript.empowerCrystalsById[__instance.bloon.Id].health += (int)(bossScript.empowerCrystalsById[__instance.bloon.Id].maxHealth * 0.001f);
                                        bloon.GetBloon().Destroy();
                                    }
                                }
                            }
                        }
                    }
                    else if (__instance.timeTriggerModel.name.Contains("StunPosition"))
                    {
                        __instance.bloon.trackSpeedMultiplier = 0;
                        var r = bossScript.stunCrystalsById[__instance.bloon.Id].bloonPlacement;
                        __instance.bloon.Position.Set(r);

                    }
                    else if (__instance.timeTriggerModel.name.Contains("Shield"))
                    {
                        __instance.bloon.trackSpeedMultiplier = 0;
                        var r = bossScript.shieldsById[__instance.bloon.Id].bloonPlacement;
                        __instance.bloon.Position.Set(r);

                    }
                    
                }
            }

        }
        [HarmonyPatch(typeof(SpawnBloonsAction), nameof(SpawnBloonsAction.PerformAction))]
        public class SpawnBloonsActionFinal
        {
            [HarmonyPostfix]

            public static void Postfix(SpawnBloonsAction __instance)
            {
           
                
            }

        }
                [HarmonyPatch(typeof(HealthPercentTrigger), nameof(HealthPercentTrigger.Trigger))]
        public class HealthPercentTriggerEmpower
        {
            [HarmonyPrefix]

            public static void Prefix(HealthPercentTrigger __instance)
            {
                if (bossScript != null)
                {
                    if (__instance.modl.name.Contains("Empower"))
                    {
                        if (__instance.modl.actionIds[bossScript.deployIndex] == "x")
                        {
                            bossScript.state = CrystalState.Split;
                            bossScript.splitProgress = 0;
                          
                                
                               
                        }
                        else if (__instance.modl.actionIds[bossScript.deployIndex] == "o")
                        {
                            bossScript.state = CrystalState.Fractured;
                            bossScript.splitProgress = 0;
                            bossScript.animTimer = 0;
                            __instance.bloon.health = __instance.bloon.bloonModel.maxHealth;
                            bossPanelController.healthBar = "dreadHealth";
                       

                        }
                        else
                        {


                            bossScript.PlayAnimation("Launch");
                            bossScript.state = CrystalState.Emitting;
                            for (int i = 0; i < 8; i++)
                            {
                                if (bossScript.deployIndex == 0)
                                    // If this is the first time deplying crystals, set the tower immunities
                                    bossScript.ApplyCrystalPassiveImmunity();
                                {

                                }
                                if (__instance.modl.actionIds[bossScript.deployIndex].Contains(i + ""))
                                {

                                    bossScript.queneCrystal.Add(i);

                                }

                            } 
                        }


                        bossScript.deployIndex++;
                    }
                    if (__instance.modl.name.Contains("StunCrystal") && InGame.instance.bridge.GetAllTowers().Count() > 0)
                    {
                        bossScript.stunCrystalsQuened++;

                    }
                    else if (__instance.modl.name.Contains("Final") && bossScript.state == CrystalState.Fractured)
                    {
                        __instance.bloon.GetBloonBehaviors<SpawnBloonsAction>().ForEach(x => x.PerformAction());

                    }
                }
            }

        }
        

        

    }
}
