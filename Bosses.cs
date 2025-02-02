using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Unity.Scenes;
using Il2CppAssets.Scripts.Unity;

using static UsesBossHandlerNamespace.IdkWhatToNameThisMod;

using BTD_Mod_Helper.Extensions;
using MelonLoader;
using UnityEngine;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppSystem;
using Il2CppAssets.Scripts.Simulation.Bloons;
using System.Runtime.InteropServices;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Abilities.Behaviors;
using HarmonyLib;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;

using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles;
using static Il2CppAssets.Scripts.Utils.ObjectCache;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using BTD_Mod_Helper.Api.Helpers;
using CommandLine.Text;
using Il2CppAssets.Scripts.Data.Boss;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Behaviors;
using Random = Il2CppSystem.Random;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Simulation.SMath;
using Vector3 = Il2CppAssets.Scripts.Simulation.SMath.Vector3;
using Math = Il2CppSystem.Math;
using UnityEngine.UI;
using BTD_Mod_Helper.Api.Components;
using Vector2 = UnityEngine.Vector2;
using static MelonLoader.MelonLogger;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;
using UnityEngine.Playables;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using static System.Net.Mime.MediaTypeNames;
using Il2CppGeom;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack;
using Il2CppNinjaKiwi.LiNK.Lobbies;
using Il2CppAssets.Scripts.Simulation.Track;
using System.Linq;
using static UsesBossHandlerNamespace.CrystalBossScript;
using Color = UnityEngine.Color;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using BTD_Mod_Helper.Api.ModOptions;
using CrystalBoss;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Harmony;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using HarmonyPostfix = HarmonyLib.HarmonyPostfix;
using HarmonyPatch = HarmonyLib.HarmonyPatch;




namespace UsesBossHandlerNamespace
{


    internal class Bosses
    {
        public static class ModHelperData
        {
            public const string WorksOnVersion = "46.1";


            public const string Name = "Dr Monkey Streams Stuff 2000Ft Underground";

            public const string Description = "Mod Jam project around the theme \'Unity\'";

            public const string Icon = "drG";

            public const string RepoOwner = "DatJaneDoe";

            
        }


        public const string YELLOW = "<color=#ECE63D>";
        public const string RED = "<color=#DE3163>";
        public const string GREEN = "<color=#00BD45>";
        public const string WHITE = "<color=#FFFFFF>";
        public const string ORANGE = "<color=#FFA500>";
        public const string CYAN = "<color=#00FFFF>";
        public const string MAGENTA = "<color=#FF00FF>";
        public const string NAVY = "<color=#FFFF80>";
        public const string GOLD = "<color=#FFD700>";
        public const string GRAY = "<color=#808080>";
        public static ProjectileModel stunningCrystalEffect;

        public static ProjectileModel fireBall;
        public static CrystalController bossScript;

        public static ModHelperPanel infoPanel;
        public static ModHelperText bossInfoText;

        public static ModHelperImage uiImage;

        public static BehaviorMutator stun;
        

        public static string[] leftSide = new string[] {"PrimaryFragment", "MagicFragment", "StunFragment","ResonantFragment", "Stun1", "Stun3"  };
        public static string[] rightSide = new string[] { "MilitaryFragment", "SupportFragment", "RockFragment", "FractureFragment", "Stun2", "Stun4" };
        public static string[] fragmentBones = new string[] { "PrimaryFragment", "MagicFragment","MilitaryFragment", "SupportFragment", "StunFragment", "RockFragment", "ResonantFragment", "FractureFragment", "Stun1", "Stun2", "Stun3", "Stun4"};
        public static string[] inertFragments = new string[] { "StunFragment", "RockFragment", "ResonantFragment", "FractureFragment" };
        public static List<string> crystalBones = new List<string>() { };   
        public enum CrystalState
        {
            Idle,
            Emitting,
            Retrieving,
            Active,
            Split,
            Fractured,
        }
        public enum CrystalType

        {
            Empower,
            Stunning,
            
            Fracture,
            Split,
            Shield,

        }

        class RockEffect : ModDisplay
        {
            public override string BaseDisplay => "4fc255a47196efc4f9c232e65a874339";

 
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {


            }
        }
        public class GlowEffectBlack : ModDisplay
        {
            public override string BaseDisplay => "d574d35c6b0813242ae326676f77ea3b";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                //      node.PrintInfo();
                foreach (Renderer rend in node.genericRenderers)
                {
                    rend.gameObject.transform.localScale = new UnityEngine.Vector3(2f, 2f, 2f);

                    rend.material.renderQueue = 5000;
                    rend.material.color = Color.black;

                    if (rend.IsType<ParticleSystemRenderer>())
                    {
                        var r = rend.Cast<ParticleSystemRenderer>();

                        r.minParticleSize *= 2f;
                        r.maxParticleSize *= 2f;

                        r.normalDirection *= -1;


                    }
                }

            }
        }
        public class GlowEffectRed : ModDisplay
        {
            public override string BaseDisplay => "d574d35c6b0813242ae326676f77ea3b";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                //      node.PrintInfo();
                foreach (Renderer rend in node.genericRenderers)
                {
                    rend.gameObject.transform.localScale = new UnityEngine.Vector3(2f, 2f, 2f);

                    rend.material.renderQueue = 5000;
                    rend.material.color = Color.red;

                    if (rend.IsType<ParticleSystemRenderer>())
                    {
                        var r = rend.Cast<ParticleSystemRenderer>();

                        r.minParticleSize *= 2f;
                        r.maxParticleSize *= 2f;

                        r.normalDirection *= -1;


                    }
                }

            }
        }
        public class GlowEffectWhite: ModDisplay
        {
            public override string BaseDisplay => "d574d35c6b0813242ae326676f77ea3b";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                //    node.PrintInfo();
                foreach (Renderer rend in node.genericRenderers)
                {
                    rend.gameObject.transform.localScale = new UnityEngine.Vector3(2f, 2f, 2f);

                    rend.material.renderQueue = 5000;
                    rend.material.color = Color.white;

                    if (rend.IsType<ParticleSystemRenderer>())
                    {
                        var r = rend.Cast<ParticleSystemRenderer>();

                       // r.minParticleSize *= 2f;
                        // r.maxParticleSize *= 2f;

                        r.normalDirection *= -1;


                    }
                }

            }
        }
        public class EffectBall : ModDisplay
        {
            public override string BaseDisplay => "f0cd31742ad6c7c4eb57e142002067c0";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
               
               
                var particle0 = node.genericRenderers[0].Cast<ParticleSystemRenderer>().gameObject.GetComponent<ParticleSystem>();
                particle0.startColor = Color.red;
                particle0.startSize = 30;

                var mesh = node.genericRenderers[1].Cast<MeshRenderer>();
                mesh.SetOutlineColor(Color.black);
      
                mesh.material.color = Color.red;

                mesh.gameObject.transform.localPosition = new UnityEngine.Vector3(0, 5, 2);

                var particle1 = node.genericRenderers[2].Cast<ParticleSystemRenderer>().gameObject.GetComponent<ParticleSystem>();
                particle1.startColor = Color.red;
                
                
                particle1.startSize = 20;
             
                var particle2 = node.genericRenderers[3].Cast<ParticleSystemRenderer>().gameObject.GetComponent<ParticleSystem>();
                particle2.startColor = Color.red;
                particle2.startSize = 60;
                /*

                ParticleSystemRenderer particle2 = node.genericRenderers[3].Cast<ParticleSystemRenderer>();
                particle2.minParticleSize *= 5;
                particle2.maxParticleSize *= 6;
                */
            }
        }
        

        public class Darkness : ModDisplay
        {
            public override string BaseDisplay => "24e47e3d6dd51f74baa99537277c39e0";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {

               
                 foreach(var  renderer in node.GetRenderers<ParticleSystemRenderer>())
                {
                    renderer.gameObject.GetComponent<ParticleSystem>().startSize *= 2;
                       
                }
                node.genericRenderers[0].gameObject.GetComponent<ParticleSystem>().startSize = 0;
                node.genericRenderers[3].gameObject.GetComponent<ParticleSystem>().startSize = 0;
                node.genericRenderers[4].gameObject.GetComponent<ParticleSystem>().startSize = 0f;
           
            }
        }
        public class DarknessLarge : ModDisplay
        {
            public override string BaseDisplay => "24e47e3d6dd51f74baa99537277c39e0";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {


                foreach (var renderer in node.GetRenderers<ParticleSystemRenderer>())
                {
                    renderer.gameObject.GetComponent<ParticleSystem>().startSize *= 10;

                }
                node.genericRenderers[2].gameObject.GetComponent<ParticleSystem>().startColor = Color.red;
            }
        }
        public class AdoraTrail : ModDisplay
        {
            public override string BaseDisplay => "dfc16ec49f4894148bce0161ebb0bd32";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {

                Set2DTexture(node, "");
                foreach (Renderer rend in node.genericRenderers)
                {

                     rend.SetMainTexture(ModContent.GetTexture<IdkWhatToNameThisMod>(""));

                }
                TrailRenderer trail = node.genericRenderers[2].Cast<TrailRenderer>();
               
                trail.time *= 2f;
                trail.startColor = Color.white;
                    trail.endColor = Color.black;
             //   trail.startWidth = 5;
               // trail.endWidth = 0;
            }
        }
       
        public class CrystalBloon : ModDisplay
        {
            public override string BaseDisplay => "bcfe5ad965c4412428d2e64cd859b69e";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {

                Set2DTexture(node, "crystalBloon");
               
            }
        }

        public class BossDisplay : ModCustomDisplay
        {
            public override string AssetBundleName => "crystal";
            public override string PrefabName => "Idle";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                
                ApplyBossTextures(node);

                
            }

        }
        
        public class BossDisplayDefeat : ModCustomDisplay
        {
            public override string AssetBundleName => "crystal";
            public override string PrefabName => "Defeat";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {


                ApplyBossTextures(node);

                foreach (var item in node.genericRenderers)
                {

                    if (item.name.Contains("Left"))
                    {

                        node.RemoveBone(item.name);
                    }

                    if (!leftSide.Contains(item.name) && !item.name.Contains("Crystal"))
                    {
                        node.RemoveBone(item.name);
                    }
                }
            }

        }
        public class BossDisplayDefeat2 : ModCustomDisplay
        {
            public override string AssetBundleName => "crystal";
            public override string PrefabName => "Defeat";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {


                ApplyBossTextures(node);
                foreach (var item in node.genericRenderers)
                {
                    if (item.name.Contains("Right"))
                    {

                        node.RemoveBone(item.name);
                    }
                    if (leftSide.Contains(item.name))
                    {
                        node.RemoveBone(item.name);
                    }
                }

            }

        }
        public class BossDisplayDefeatAll : ModCustomDisplay
        {
            public override string AssetBundleName => "crystal";
            public override string PrefabName => "Defeat";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {


                ApplyBossTextures(node);
                

            }

        }
        public class BossDisplayLeft : ModCustomDisplay
        {
            public override string AssetBundleName => "crystal";
            public override string PrefabName => "Idle";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {


                ApplyBossTextures(node);

                foreach (var item in node.genericRenderers)
                {
                    
                    if (item.name.Contains("Left"))
                    {
                       
                        node.RemoveBone(item.name);
                    }
                    
                    if (!leftSide.Contains(item.name) && !item.name.Contains("Crystal") )
                    {
                        node.RemoveBone(item.name);
                    }
                }
            }

        }
        public static void ApplyBossTextures(UnityDisplayNode node)
        {
            bool addCrystalBones = crystalBones.Count == 0;

            foreach (var item in node.genericRenderers)
            {
                item.ApplyOutlineShader();

                bool red = true;
                if (item.name.Contains("Low") || item.name.Contains("Middle") || item.name.Contains("High"))
                {
                    item.SetMainTexture(ModContent.GetTexture<IdkWhatToNameThisMod>("RedCrystal"));
                    if (addCrystalBones)
                    {
                        crystalBones.Add(item.name);
                    }
                   
                }
                else if (item.name.Contains("Stun"))
                {
                    item.SetMainTexture(ModContent.GetTexture<IdkWhatToNameThisMod>("ShockShard"));
                }
                else
                {
                    red = false;
                }
                
                item.SetOutlineColor(Color.black);

            }
            
           
            foreach (var item in node.genericRenderers)
            {

                SetRendererTexture(item, "PrimaryFragment", "PrimaryCrystal");
                SetRendererTexture(item, "MilitaryFragment", "MilitaryCrystal");
                SetRendererTexture(item, "MagicFragment", "MagicCrystal");
                SetRendererTexture(item, "SupportFragment", "SupportCrystal");
                SetRendererTexture(item, "StunFragment", "StunCrystal");
                SetRendererTexture(item, "ResonantFragment", "ResonantCrystal");
                SetRendererTexture(item, "RockFragment", "RockCrystal");
                SetRendererTexture(item, "FractureFragment", "FractureCrystal");
            }
            node.RemoveBone("body");
        }
        public class BossDisplayLeftBreak : ModCustomDisplay
        {
            public override string AssetBundleName => "crystal";
            public override string PrefabName => "Charge";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {

                ApplyBossTextures(node);

                foreach (var item in node.genericRenderers)
                {

                    if (item.name.Contains("Left"))
                    {

                        node.RemoveBone(item.name);
                    }

                    if (!leftSide.Contains(item.name) && !item.name.Contains("Crystal"))
                    {
                        node.RemoveBone(item.name);
                    }
                }
            }

        }
        public class BossDisplayRight : ModCustomDisplay
        {
            public override string AssetBundleName => "crystal";
            public override string PrefabName => "Idle";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                ApplyBossTextures(node);

                foreach (var item in node.genericRenderers)
                {
                    if (item.name.Contains("Right"))
                    {
                      
                        node.RemoveBone(item.name);
                    }
                    if (leftSide.Contains(item.name))
                    {
                        node.RemoveBone(item.name);
                    }
                }


            }

        }

        public class BossDisplayRightBreak : ModCustomDisplay
        {
            public override string AssetBundleName => "crystal";
            public override string PrefabName => "Charge";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                ApplyBossTextures(node);

                foreach (var item in node.genericRenderers)
                {
                    if (item.name.Contains("Right"))
                    {

                        node.RemoveBone(item.name);
                    }
                    if (leftSide.Contains(item.name))
                    {
                        node.RemoveBone(item.name);
                    }
                }


            }

        }
        public class BloontoniumShardShield : ModCustomDisplay
        {
            public override string AssetBundleName => "crystal";
            public override string PrefabName => "MechanicFragment";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                foreach (var item in node.genericRenderers)
                {
                    item.ApplyOutlineShader();
                    item.SetMainTexture(ModContent.GetTexture<IdkWhatToNameThisMod>("RedCrystal"));
                    item.gameObject.transform.RotateAroundLocal(new UnityEngine.Vector3(0, 0, 1), 30f);
                }
            }
        }
        public class BloontoniumShard : ModCustomDisplay
        {
            public override string AssetBundleName => "crystal";
            public override string PrefabName => "ShockShard";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                foreach (var item in node.genericRenderers)
                {
                    item.gameObject.transform.localScale = new UnityEngine.Vector3(10,10,10);
                    item.ApplyOutlineShader();
                    item.SetMainTexture(ModContent.GetTexture<IdkWhatToNameThisMod>("RedCrystal"));
                   
                }
            }
        }
        public class ResistanceFragment : ModCustomDisplay
        {
            public override string AssetBundleName => "crystal";
            public override string PrefabName => "ResistanceFragment";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                foreach (var item in node.genericRenderers)
                {
                    item.ApplyOutlineShader();

                }
            }
        }
        public class MechanicFragment : ModCustomDisplay
        {
            public override string AssetBundleName => "crystal";
            public override string PrefabName => "MechanicFragment";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {

                foreach (var item in node.genericRenderers)
                {
                    item.ApplyOutlineShader();

                }

            }

        }
        public class ShockShard : ModCustomDisplay
        {
            public override string AssetBundleName => "crystal";
            public override string PrefabName => "ShockShard";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                foreach (var item in node.genericRenderers)
                {
                    item.ApplyOutlineShader();

                }


            }

        }

        public class BossLaunch : ModCustomDisplay
        {
            public override string AssetBundleName => "crystal";
            public override string PrefabName => "Launch";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
             

                foreach (var item in node.genericRenderers)
                {
                    item.ApplyOutlineShader();

                  
                    if (item.name.Contains("Low"))
                    {
                        item.SetMainTexture(ModContent.GetTexture<IdkWhatToNameThisMod>("RedCrystal"));
                    }
                    else if (item.name.Contains("Middle"))
                    {
                        item.SetMainTexture(ModContent.GetTexture<IdkWhatToNameThisMod>("RedCrystal"));
                    }
                    else if (item.name.Contains("High"))
                    {
                        item.SetMainTexture(ModContent.GetTexture<IdkWhatToNameThisMod>("RedCrystal"));
                    }
                    else if (item.name.Contains("Stun"))
                    {
                        item.SetMainTexture(ModContent.GetTexture<IdkWhatToNameThisMod>("ShockShard"));
                    }
                  

                    item.SetOutlineColor(Color.black);

                }
                foreach (var item in node.genericRenderers)
                {

                    SetRendererTexture(item, "PrimaryFragment", "PrimaryCrystal");
                    SetRendererTexture(item, "MilitaryFragment", "MilitaryCrystal");
                    SetRendererTexture(item, "MagicFragment", "MagicCrystal");
                    SetRendererTexture(item, "SupportFragment", "SupportCrystal");
                    SetRendererTexture(item, "StunFragment", "StunCrystal");
                    SetRendererTexture(item, "ResonantFragment", "ResonantCrystal");
                    SetRendererTexture(item, "RockFragment", "RockCrystal");
                    SetRendererTexture(item, "FractureFragment", "FractureCrystal");
                }
            


            }

        }
        public class BossStartUp: ModCustomDisplay
        {
            public override string AssetBundleName => "crystal";
            public override string PrefabName => "StartUp";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                

                foreach (var item in node.genericRenderers)
                {
                    item.ApplyOutlineShader();

                    bool red = true;
                    if (item.name.Contains("Low"))
                    {
                        item.SetMainTexture(ModContent.GetTexture<IdkWhatToNameThisMod>("RedCrystal"));
                    }
                    else if (item.name.Contains("Middle"))
                    {
                        item.SetMainTexture(ModContent.GetTexture<IdkWhatToNameThisMod>("RedCrystal"));
                    }
                    else if (item.name.Contains("High"))
                    {
                        item.SetMainTexture(ModContent.GetTexture<IdkWhatToNameThisMod>("RedCrystal"));
                    }
                    else if (item.name.Contains("Stun"))
                    {
                        item.SetMainTexture(ModContent.GetTexture<IdkWhatToNameThisMod>("ShockShard"));
                    }
                    else
                    {
                        red = false;
                    }

                    item.SetOutlineColor(Color.black);

                }
                foreach (var item in node.genericRenderers)
                {

                    SetRendererTexture(item, "PrimaryFragment", "PrimaryCrystal");
                    SetRendererTexture(item, "MilitaryFragment", "MilitaryCrystal");
                    SetRendererTexture(item, "MagicFragment", "MagicCrystal");
                    SetRendererTexture(item, "SupportFragment", "SupportCrystal");
                    SetRendererTexture(item, "StunFragment", "StunCrystal");
                    SetRendererTexture(item, "ResonantFragment", "ResonantCrystal");
                    SetRendererTexture(item, "RockFragment", "RockCrystal");
                    SetRendererTexture(item, "FractureFragment", "FractureCrystal");
                }
                node.RemoveBone("body");


            }

        }
        public class BossCharge : ModCustomDisplay
        {
            public override string AssetBundleName => "crystal";
            public override string PrefabName => "Charge";


            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
               

                foreach (var item in node.genericRenderers)
                {
                    item.ApplyOutlineShader();

            
                    if (item.name.Contains("Low"))
                    {
                        item.SetMainTexture(ModContent.GetTexture<IdkWhatToNameThisMod>("RedCrystal"));
                    }
                    else if (item.name.Contains("Middle"))
                    {
                        item.SetMainTexture(ModContent.GetTexture<IdkWhatToNameThisMod>("RedCrystal"));
                    }
                    else if (item.name.Contains("High"))
                    {
                        item.SetMainTexture(ModContent.GetTexture<IdkWhatToNameThisMod>("RedCrystal"));
                    }
                    else if (item.name.Contains("Stun"))
                    {
                        item.SetMainTexture(ModContent.GetTexture<IdkWhatToNameThisMod>("ShockShard"));
                    }
                  

                    item.SetOutlineColor(Color.black);

                }
                foreach (var item in node.genericRenderers)
                {

                    SetRendererTexture(item, "PrimaryFragment", "PrimaryCrystal");
                    SetRendererTexture(item, "MilitaryFragment", "MilitaryCrystal");
                    SetRendererTexture(item, "MagicFragment", "MagicCrystal");
                    SetRendererTexture(item, "SupportFragment", "SupportCrystal");
                    SetRendererTexture(item, "StunFragment", "StunCrystal");
                    SetRendererTexture(item, "ResonantFragment", "ResonantCrystal");
                    SetRendererTexture(item, "RockFragment", "RockCrystal");
                    SetRendererTexture(item, "FractureFragment", "FractureCrystal");
                }
                node.RemoveBone("body");


            }

        }
        public static void SetRendererTexture(Renderer renderer, string name, string texture)
        {
            if(renderer.name == name)
            {
                renderer.SetMainTexture(ModContent.GetTexture<IdkWhatToNameThisMod>(texture));
            }
           
        }


        [HarmonyPatch(typeof(TitleScreen), nameof(TitleScreen.Start))]
        public class TitleScreenInit
        {
            [HarmonyPostfix]

            public static void Postfix()
            {
               
                
                BloonModel crystalBloon = Game.instance.model.GetBloon("DreadRockBloonStandard1").Duplicate();
                crystalBloon.maxHealth = 99999999;
                crystalBloon.ApplyDisplay<CrystalBloon>();
                crystalBloon.leakDamage = 10;
                crystalBloon.RemoveBehaviors<DamageStateModel>();
                crystalBloon.damageDisplayStates = new DamageStateModel[] { };
                BossRegistration crystalBloonRegistration = new BossRegistration(crystalBloon, "CrystalBloon", "", false, "", 99);

                BloonModel finalFragment = CreateBossBase(999999999, 10);
                finalFragment.maxHealth = 99999999;
                finalFragment.RemoveAllChildren();
                finalFragment.ApplyDisplay<BloontoniumShard>();
                finalFragment.leakDamage = 0;
                finalFragment.speed = crystalBloon.speed *1.25f;
                finalFragment.RemoveBehaviors<DamageStateModel>();
                finalFragment.damageDisplayStates = new DamageStateModel[] { };
               
                BossRegistration finalFragmentRegistration = new BossRegistration(finalFragment, "FinalFragment", "", false,"", 99);
             //   finalFragmentRegistration.SpawnOnRound(2);
                

                BloonModel crystalFrag = CreateBossBase(999999999, 1000f);
                crystalFrag.overlayClass = Il2Cpp.BloonOverlayClass.Red;
                crystalFrag.display = new PrefabReference("c2d5c1fc834bc4b4789dd98b046edacb");
                // Sets the display to BossDisplay


                

                BloonModel crystalBoss1 = CreateBossBase(30000, 1.25f);
                BloonModel crystalBoss2 = CreateBossBase(120000, 1.25f);
                BloonModel crystalBoss3 = CreateBossBase(750000, 1.25f);
                BloonModel crystalBoss4 = CreateBossBase(3000000, 1.25f);
                BloonModel crystalBoss5 = CreateBossBase(10000000, 1.25f);
                // Sets the display to BossDisplay


                SetDisplay(new BloonModel[] { crystalBoss1, crystalBoss2, crystalBoss3, crystalBoss4, crystalBoss5 });
               




                /* Registers the boss into BossHandler.

                When a bloon registered via BossRegistration spawns, it will run BossInit 
                allowing you to run any other code the Bloon needs and/or start a monobehavior

                If the isMainBoss property is set to true (its true by default), the boss UI will display the bosses display name, icon, and health.
                If the description property has text, you can toggle seeing the description ingame.

                If continueRounds is greater than 0, then rounds will continue to be sent while the boss is on screen
                up to the continueRounds value. For example, if the boss spawns on round 40 with a continueRounds value of 9,
                the boss will allow rounds to be sent until round 49 is reached. Rounds continue as normal once the boss is popped
                This value is 0 by default.

                The returned BossRegistration object can be altered further.

                SizeX/SizeY: Dimensions of the description box
                UsesExtraInfo: Adds extra UI info under the health bar.
                ExtraInfoIcon: The icon used for the extra UI
                ExtraInfoText: The initial text next to the extra UI icon.

                You can change the initial text anytime by changing bossPanel.extraText
                */
                BossRegistration crystalFragRegistration = new BossRegistration(crystalFrag, "CrystalFrag", "Crystal Frag", false, "",99);
                crystalFrag.AddBehavior(new TimeTriggerModel("Empower", 3, false, new string[] { }));

                string newText = ColorText(WHITE, "(New) ");
                string tier1 = ColorText(NAVY,  "A deity of pure Bloontonium energy that wears bloontonium crystals as its shell") +  ColorText(GREEN, " \n\nThe hardness of its crystals grants it Lead properties ") +
                 ColorText(ORANGE, "\n\n On skull: Releases fragments of itself off onto the map to accumulate power, buffing the bloon god for the remainder of the fight overtime.") +
                 ColorText(YELLOW, "\n\n Each fragment has a unique property and returns to the boss if damaged enough. The bloon god is invulnerable while split\n\n");

                  string splitDesc = ColorText(CYAN, "On the last skull, splits into two. Destroying one half empowers all attached fragments until the other half is also destroyed");

                string tier2 = ColorText(GOLD, "Places crystal shards charged with bloontonium energy on your towers with the highest damage. If not destroyed quickly, they stun all towers in a radius then heal the boss for a percentage of their remaining health\n\n");

                string tier3 = ColorText(RED, "Summons extremely dense Crystal Rock Bloons that wear down projectiles quickly. Projectiles that hit them have their pierce reduced by 10 rather than 1. Empowerment fragments can absorb nearby Crystal Rock Bloons to heal themselves\n\n");

                string tier4 = ColorText(GREEN, "Create 4 rotating shields that block projectiles. Can be disabled temporarily if they take enough damage\n\n");

                string tier5 = ColorText(CYAN, "On the second last skull, splits into two. Destroying one half empowers all attached fragments until the other half is also destroyed\n\n") +
                newText + ColorText(MAGENTA, " On the last skull sacrifices its physical form, scattering its Bloontonium crystals. Takes 5% less damage for every crystal on screen\n\n");

                BossRegistration crystalBoss1registration = new BossRegistration(crystalBoss1, "CrystalBoss1", "Crystallized Bloon God", true, "defaultIcon", 18, tier1 + splitDesc);

                // Spawns the boss on round 40 and clears all other Bloon spawns from that round unless "clearOtherSpawns" is set to false
                crystalBoss1registration.tier = 1;
                crystalBoss1registration.SpawnOnRound(40);

                // Assigns skulls and which empowerment crystals to deploy
                SetCrystalEmissions(crystalBoss1registration, new float[] {0.875f, 0.75f, 0.625f, 0.5f, 0.375f,0.25f }, new string[] {"01", "23", "02", "132","013", "x" });
                AddExtraInfo(crystalBoss1registration);
                crystalBoss1registration.sizeX = 1200;
                crystalBoss1registration.sizeY = 750;

               
                BossRegistration crystalBoss2registration = new BossRegistration(crystalBoss2, "CrystalBoss2", "Crystallized Bloon God", true, "defaultIcon", 18, tier1 + newText + tier2 + splitDesc);

                crystalBoss2registration.SpawnOnRound(60);
                crystalBoss2registration.tier = 2;
                SetCrystalEmissions(crystalBoss2registration, new float[] { 0.875f, 0.75f, 0.625f, 0.5f, 0.375f, 0.25f }, new string[] { "02", "134", "041", "0234","1234", "x" });
                AddExtraInfo(crystalBoss2registration);
         
                crystalBoss2registration.sizeX = 1200;
                crystalBoss2registration.sizeY = 1000;

                BossRegistration crystalBoss3registration = new BossRegistration(crystalBoss3, "CrystalBoss3", "Crystallized Bloon God", true, "defaultIcon", 18, tier1 + tier2 +newText + tier3 + splitDesc);
                crystalBoss3registration.tier = 3;
                crystalBoss3registration.SpawnOnRound(80);

                SetCrystalEmissions(crystalBoss3registration, new float[] { 0.875f, 0.75f, 0.625f, 0.5f, 0.375f , 0.25f}, new string[] { "1452", "2351", "0245", "1350", "4503","x" });
                AddExtraInfo(crystalBoss3registration);
              
                crystalBoss3registration.sizeX = 1200;
                crystalBoss3registration.sizeY = 1200;

                BossRegistration crystalBoss4registration = new BossRegistration(crystalBoss4, "CrystalBoss4", "Crystallized Bloon God", true, "defaultIcon", 18, tier1 + tier2 + tier3 + newText+ tier4 + splitDesc);
                crystalBoss4registration.tier = 4;
                crystalBoss4registration.SpawnOnRound(100);
                crystalBoss4registration.sizeX = 1200;
                crystalBoss4registration.sizeY = 1300;

                SetCrystalEmissions(crystalBoss4registration, new float[] { 0.875f, 0.75f, 0.625f, 0.5f, 0.375f ,0.25f}, new string[] { "01542", "12630", "23501", "34615", "340526", "x" });
                AddExtraInfo(crystalBoss4registration);
               

                BossRegistration crystalBoss5registration = new BossRegistration(crystalBoss5, "CrystalBoss5", "Crystallized Bloon God", true, "defaultIcon", 38, tier1 + tier2 + tier3 + tier4 + tier5);
                crystalBoss5registration.tier = 5;
                crystalBoss5registration.SpawnOnRound(120);

                crystalBoss5registration.sizeX = 1200;
                crystalBoss5registration.sizeY = 1500;


                SetCrystalEmissions(crystalBoss5registration, new float[] {0.875f, 0.75f, 0.625f, 0.5f, 0.375f, 0.25f, 0.125f }, new string[] {"123567", "023467", "013457", "0124567", "01234567", "x", "o"});

             

                AddExtraInfo(crystalBoss5registration);
             



                // Enables use of the extra info tabs.


                // Sets the tooltip and icon for the tab at index 0.
                // To see how to change the extra info tab text, see Bloon.Damage

                // If you want to use an embedded png as the icon, put the name of the png in the sprite parameter and set isVanillaSprite to false
                fireBall = Game.instance.model.GetTower("SpikeFactory").GetAttackModel().weapons[0].projectile.Duplicate();
                fireBall.canCollideWithBloons = false;
                fireBall.pierce = 9999;

                fireBall.AddBehavior(new CantBeReflectedModel("noReflect"));
                fireBall.RemoveBehavior<SetSpriteFromPierceModel>();
                fireBall.GetDescendant<DamageModel>().damage = 0;
                fireBall.GetDescendant<ArriveAtTargetModel>().timeToTake = 5;
                fireBall.GetDescendant<ArriveAtTargetModel>().altSpeed *= 0.1f;
                fireBall.GetDescendant<ArriveAtTargetModel>().filterCollisionWhileMoving = true;
                fireBall.GetBehavior<ScaleProjectileModel>().curve.samples = fireBall.GetBehavior<ScaleProjectileModel>().samples = Game.instance.model.GetTower("Alchemist").GetDescendant<ScaleProjectileModel>().curve.samples;
                fireBall.GetBehavior<AgeModel>().lifespan = 20;
                fireBall.GetBehavior<AgeModel>().rounds = 3;
               
                fireBall.GetDescendant<ArriveAtTargetModel>().expireOnArrival = true;


                fireBall.GetBehavior<ArriveAtTargetModel>().name = "Fireball";

                fireBall.ApplyDisplay<AdoraTrail>();
                fireBall.GetBehavior<DisplayModel>().positionOffset = new Vector3(0, 0, -60);

                BloonModel stunningCrystal = CreateBossBase(999999999, 0f);
                stunningCrystal.display = new PrefabReference("d574d35c6b0813242ae326676f77ea3b");
                stunningCrystal.speed = 0;
                stunningCrystal.AddBehavior(new TimeTriggerModel("StunPosition", 0, true, new string[] { }));
                BossRegistration stunningCrystalRegistration = new BossRegistration(stunningCrystal, "StunCrystal", "Stun Crystal", false, "defaultIcon", 9, "Does many thins \n\n Not really doesnt do much at all \n\n Excess text for testing purposes");
            


                stun = Game.instance.model.GetBloon("Vortex1").GetBehavior<StunTowersInRadiusActionModel>().Mutator;



                BloonModel splitCrystal = CreateBossBase(999999999, 4f);
                splitCrystal.display = new PrefabReference("");
                splitCrystal.GetBehavior<DisplayModel>().scale = 0;
                splitCrystal.speed = 4;

                splitCrystal.AddBehavior(new TimeTriggerModel("Empower", 3, false, new string[] { }));

                BossRegistration splitCrystalRegistration = new BossRegistration(splitCrystal, "SplitCrystal", "Split Crystal", false, "defaultIcon", 9, "");



                BloonModel shieldCrystal = CreateBossBase(999999999, 0f);
                shieldCrystal.display = splitCrystal.display ;
                shieldCrystal.speed = 0;
                shieldCrystal.radius *= 0.7f;
                shieldCrystal.AddBehavior(new TimeTriggerModel("Shield", 0, false, new string[] { }));

                BossRegistration shieldCrystalRegistration = new BossRegistration(shieldCrystal, "ShieldCrystal", "Shield Crystal", false, "defaultIcon", 9, "");

                AddBehaviors(crystalBoss1registration, crystalBoss1);
                AddBehaviors(crystalBoss2registration, crystalBoss2);
                AddBehaviors(crystalBoss3registration, crystalBoss3);
                AddBehaviors(crystalBoss4registration, crystalBoss4);
                AddBehaviors(crystalBoss5registration, crystalBoss5);



                foreach(TowerModel tower in Game.instance.model.towers)
                {
                    tower.range *= 0.5f;
                    foreach(AttackModel attack in tower.GetBehaviors<AttackModel>())
                    {
                        attack.range *= 0.5f;
                    }

                }

                CutsceneSystem.CutsceneSequence("intro", new string[] { "bonD|Thanks doc for coming down here with me\n\n your bloontonium detector makes mining so easy!",
                    "drE|Glad to help! \n\n If you have any questions feel free to ask!|L", 
                    "bon|Ive been mining Bloontonium all my life but now that I think about it...\n\n what even is bloontonium?",
                    "dr|If I was being honest... I dont fully know, but I can give you an idea.\n\n Have you heard about the " + RED + "Bloon God?|L",
                    "bon|THE WHAT NOW?!",
                    "drW|You know how the Sun god gives us the power of sun?|L",
                "bon| Yeah... what about it?","" +
                "drW|The Bloon god is just like that, except it gives bloons their power in the form of bloontonium|L",
                "drE|its ability to give Bloons life is something not even science can explain\n\n but thats what makes it so fascinating!|L",
            
                    "bon|Theres a bloon god... \n\n Can I see it? Or even pop it?",
                "dr|Ive never seen it personally\n\n but Id imagine with the bloontonium detector it would be easy to find|L",
              "dr|But to actually pop it? you have to remember " + ColorText(RED , "its the bloon god.") + " It will put up a tough fight|L",
              "drE| Youre going to need to make immense preperations\n\nIf you need " + ColorText(GREEN, "additional cash ")+ "place me down and I'll see what I can do to help|L",

                }, "");

                CutsceneSystem.CutsceneSequence("gaming", new string[] { "bon|So uh... doc \n\n how exactly are you going to get cash?",
                    "bon|Dr Monkey? What are you doing on your laptop? \n\n why are you wearing headphones?",
                    "gaming1",
                    "gaming2",
                    "drG|I need to practice Dartling more before going back to ranked \n\n thank you Monke D luffi for the $100 donation|L",
                    "bon|What. \n\n and I thought the bloon god was unbelievable"

                }, DrMonkeyGamingPopup);

                CutsceneSystem.CutsceneSequence("temple", new string[] { "bonD|The bloontonium detector is picking up immense amounts of energy from this ruined temple|{templeEntrance}",
                    "bon|Theres an " + ColorText( RED ,"abnormally large amount of Bloontonium crystals ") + "Im really tempted to mine them|{templeEntrance}",
                    "drG|\'Brb chat gotta talk to bonnie\'|L{templeEntrance}",
                    "dr|So the legends were true...\n\n the bloon god hid deep underground from the Sun God|L{templeEntrance}",
                    "drW|But to this day its true appearance remains a mystery \n\n Every monkey who has witnessed the bloon god described it differently|L{templeEntrance}",
                    "dr|My only theory is " + ColorText(RED,  "It can shapeshift")+ " \n\n But we'll see soon enough. Lead the way bonnie!|L{templeEntrance}",
                    "bon|Ok I will|{templeEntrance}",
                    "drG|\'chat Im back \n\nNo nothing is going wrong, Bonnie just found the temple of the bloon god \'|L{templeEntrance}"
                }, "");


                CutsceneSystem.CutsceneSequence("god1", new string[] { "bonD|The bloontonium detector is malfunctioning! \n\n its detecting bloontonium power levels of over \n" + RED + "nine-thou...",
                     "drG|\'Hold on chat, Bonnies trying to make meme references as ancient as the bloon god temple\'",
                    "drG|\'wait chat you'd rather me livestream the bloon god? \n\n Fine, let me adjust my webcam and change the stream title\'",
                    "drE|Hello? Bloon god? You there? \n\n Im a big fan of harnessing your bloontonium for science projects",
                     "tbgH|You are no bloon. How peculiar|L",
                    "bon|Huh... I dont think you are either. \n\n Youre a ball of floating gas?",
                     "tbg|I am the bloon god. \n\n paragon of " + GREEN +" unity " + GRAY + "among monkeys|L",
                    "tbg|My power is near infinite. No layer of rubber can contain me without melting|L",

                    "bon| Paragon of unity? \n\n What are you on about?",
                    "tbg|Perhaps you need a reminder. \n\n " + RED + " Prepare your defenses|L",
                  
                      "dr| How on earth are we supposed to pop something that lacks a physical form?",
                      "tbg| Nonsense. \n\n" + ColorText( RED , "Bloontonium crystals are my physical form") +"|L"
                }, "");


                CutsceneSystem.CutsceneSequence("godend1", new string[] { "bon|Thats it? The bloon gods crystal shell shattered into a thousand pieces",
                    "dr|Hold your darts bonnie \n\n By the looks of the " + ColorText(GRAY, "Greyed out crystals on its back ") + "It was holding back its full power|L",
                    "drW| " + ColorText( RED ," the bloon god will reform its shell and use new abilities") + "|L",
                   

                },"");

                CutsceneSystem.CutsceneSequence("godend2", new string[] { "tbg|Do you understand now?|L",
                    "bon|no \n\n There no unity, just destruction",
                }, "");


                CutsceneSystem.CutsceneSequence("godend3", new string[] { "tbg|Perhaps the darkness has blinded you to the unity I have created|L",
                    "bon|Ive been down inthe mines all my life \n\n I can see fine",
                    "drW| Im starting to doubt the bloon god means unity between us and bloons",
                }, "");

                CutsceneSystem.CutsceneSequence("godend4", new string[] { "tbg|My form. \n\n My bloontonium crystals|L",
                   "tbg|Each with different properties \n\n Each with different abilities|L",
                    "tbg|Yet they all work towards a common goal|L",
                    "tbg|You monkeys are no different|L"
                }, "");

                CutsceneSystem.CutsceneSequence("godend5", new string[] {  "drW| " + GREEN +" I think I get it now \n\n Us monkeys are all different",
                 "drE| " + YELLOW +" Yet we all have the same goal \n\n to pop bloons",
                  "tbg|correct.|L",
                  "tbg|What "  + GREEN + "unites " + GRAY+" people are the struggles we all face \n\n The ones we can all relate to \n\n It gives us empathy for one another|L",
                  "tbg|Even if those struggles can be overcome. The world can never be perfect \n\n There will always be flaws and always reason to come together|L",
                  "dr|I see.\n\n Well we're sorry for disturbing you it was quite fascinating to see the bloon god themselves",
                  "tbg|No. I very well enjoyed your visit \n\n It has been decades since one could best my tier five form|L",
                  "bon|Thats cool and all but can I atleast mine these bloontonium crystals",
                  "tbg| " + RED +"Shut up bonnie you literally did nothing this entire fight \n\n Go back to battles 2 where you belong|L",
                  "stream1", 
                  "stream2",
                  "stream3||gif",
                  "stream4||gif",
                  "stream5||gif",
                  "dr|I sure do.\n\n My lack of access to wifi down here was painful, but its what drove me to find a solution",
                  "drE|Its not easy to setup, but for all the bloontonium youve given me its the least I could do",
                  "tbg|That would be splendid.\n\n May we " + GREEN + "unite " + GRAY + "over our common problems|L",
                  "cred1",
                  "cred2",
                  "cred3",
                }, End);

                CutsceneSystem.characterColor["tbg"] = GRAY;
            }
        }
        public static void End()
        {
            InGame.instance.bridge.SetRound(159);
        }
        public static void DrMonkeyGamingPopup()
        {
            PopupScreen.instance.ShowOkPopup("Dr Monkey is supplying you with " + YELLOW+ "$100 per round, increasing by 10% per round " + WHITE + "thanks to his stream donations \n\n If you like Dr Monkeys content please use creator code DrMonke to recieve 10% off your next order of GamerPops");

        }
        public static void AddExtraInfo(BossRegistration bossRegistration)
        {
            bossRegistration.usesExtraInfoTabs = true;
            bossRegistration.ConfigureInfoTab(0, VanillaSprites.TowerTypePrimary, "0%", " <> damage resistance to Primary towers", true);
            bossRegistration.ConfigureInfoTab(1, VanillaSprites.TowerTypeMilitary, "0%", " <> damage resistance to Military towers", true);
            bossRegistration.ConfigureInfoTab(2, VanillaSprites.TowerTypeMagic, "0%", " <> damage resistance to Magic towers", true);
            bossRegistration.ConfigureInfoTab(3, VanillaSprites.TowerTypeSupport, "0%", " <> damage resistance to Support towers", true);

            int tier = bossRegistration.tier;
            if (tier >= 2)
            {
                bossRegistration.ConfigureInfoTab(4, VanillaSprites.StunEffect01, "0%", "Stunning crystal has <> increased health and stun duration", true);

                if (tier >= 3)
                {
                    bossRegistration.ConfigureInfoTab(5, VanillaSprites.DreadRockBloonStandard, "0%", "Crystal Bloons have <> more health and deplete <> more pierce", true);

                    if (tier >= 4)
                    {
                        bossRegistration.ConfigureInfoTab(6, VanillaSprites.LivesShieldIcon, "0%", "Shield has <> increased health and regeneration rate", true);

                        if (tier >= 5)
                        {
                            bossRegistration.ConfigureInfoTab(7, VanillaSprites.BrokenHeart, "0%", "on the last phase, bloontonium shards have <> increased health and pierce depletion", true);

                        }
                    }
                }
            }

        }
        public static void AddBehaviors(BossRegistration bossRegistration, BloonModel bloonModel)
        {
            if (bossRegistration.tier >= 2)
            {
                var spawnStuns = new HealthPercentTriggerModel("StunCrystal", true, new float[] { 0.1f }, new string[] { "e" }, false);

                bloonModel.AddBehavior(spawnStuns);

                if(bossRegistration.tier >= 3)
                {
                    HealthPercentTriggerModel crystalBloonsTrigger = new HealthPercentTriggerModel("TriggerCrystalBloons", true, new float[] { 0.01f }, new string[] { "SpawnCrystalBloons" }, false);
                    SpawnBloonsActionModel spawns = Game.instance.model.GetBloon("Bloonarius1").GetBehaviors<SpawnBloonsActionModel>()[1].Duplicate();
                    spawns.bloonType = "CrystalBloon";
                    spawns.bossName = "Vortex";
                    spawns.spawnCount = 5;
                    spawns.actionId = "SpawnCrystalBloons";

                    bloonModel.AddBehavior(spawns);
                    bloonModel.AddBehavior(crystalBloonsTrigger);

                    if(bossRegistration.tier >= 4)
                    {
                        if (bossRegistration.tier >= 5)
                        {
                            SpawnBloonsActionModel fracture = spawns.Duplicate();
                            fracture.spawnCount = 1;
                            fracture.bloonType = "FinalFragment";
                            fracture.actionId = "SpawnFinal";
                            bloonModel.AddBehavior(fracture);
                            fracture.spawnTrackMin = 0.05f;
                            fracture.spawnTrackMax = 0.98f;
                           
                            var final = new HealthPercentTriggerModel("Final", true, new float[] { 0.002f }, new string[] { }, false);
                            bloonModel.AddBehavior(final);
                            
                        }
                    }
                }
            }
        }
        public static void SetCrystalEmissions(BossRegistration registration, float[] percentages, string[] crystalIndexs)
        {
            registration.boss.AddBehavior(new HealthPercentTriggerModel("Empower", false, percentages, crystalIndexs, true));
            registration.skulls = percentages;
            registration.usesSkulls = true;
        }
        public static void SetDisplay(BloonModel[] boss)
        {
            foreach (var item in boss)
            {

               item.ApplyDisplay<BossDisplay>();
            }
        }
        public static void BossInit(Bloon bloon, BloonModel bloonModel, BossRegistration registration)
        {
            
            // This function runs when a boss is spawned. The parameters include the boss and its registration info
            // You can put code here to spawn minions, effects,  start a monobehavior, etc
            if (bloon.bloonModel.id.Contains("Crystal"))
            {
                if (bloon.bloonModel.id.Contains("Boss"))
                {
                    // Starts the Crystal Controller
                    bossScript = StartMonobehavior<CrystalController>();
                    bossScript.bossId = bloon.Id;
                    bossScript.registration = registration;
                   
                    if (infoPanel == null)
                    {
                        infoPanel = InGame.instance.mapRect.gameObject.AddModHelperPanel(new Info("InfoUIPanel",
                     0, 0, 350, 150, new UnityEngine.Vector2(0.5f, .5f), new UnityEngine.Vector2(.5f, .5f)), ModContent.GetSpriteReference<IdkWhatToNameThisMod>("descriptionBox").guidRef);
                        infoPanel.Background.raycastTarget = false;

                        bossInfoText = infoPanel.AddText(new BTD_Mod_Helper.Api.Components.Info("BossInfoText", 0, 0, 350, 150), "This text box", 50, Il2CppTMPro.TextAlignmentOptions.Midline);

                        infoPanel.Hide();
                    }
                }
                if (bloon.bloonModel.id.Contains("CrystalFrag"))
                {
                    // Registers the crystal fragment into the bosses controller
                    if (bossScript != null)
                    {
                        bossScript.RegisterEmpower(bloon.Id);
                    }
                    else
                    {
                        bloon.Destroy();
                    }
                }
                if (bloon.bloonModel.id.Contains("StunCrystal"))
                {
                    // Registers the crystal fragment into the bosses controller
                    if (bossScript != null)
                    {
                        bossScript.RegisterStunning(bloon.Id);
                    }
                    else
                    {
                        bloon.Destroy();
                    }
                }
                if (bloon.bloonModel.id.Contains("ShieldCrystal"))
                {
                    // Registers the shield fragment into the bosses controller
                    if (bossScript != null)
                    {
                        bossScript.RegisterShield(bloon.Id);
                    }
                    else
                    {
                        bloon.Destroy();
                    }
                }
                if (bloon.bloonModel.id.Contains("SplitCrystal"))
                {
                    // Registers the crystal fragment into the bosses controller
                    bloon.IsInvulnerable = true;
                  
                    if (bossScript != null)
                    {
                        bossScript.RegisterHalves(bloon.Id);
                    }
                    else
                    {
                        bloon.Destroy();
                    }
                }
  
            }


        }
        public class CrystalFragment
        {
            public Entity entity;
            public ObjectId crystalId;
            public Vector3 renderPosition = new Vector3(200, 200,0);
            public Vector3 bloonPlacement = new Vector3(-200, -200, 0);
            public CrystalState state = CrystalState.Idle;
            public CrystalType type = CrystalType.Empower;
            public string bossPart = "";
            public bool fixedColor = false;
            public Projectile movement;
            public int health = 10;
            public int maxHealth = 10;
            public float percThroughTrack = 0;
            public bool charge = false;
            public float time = 0;
            public Entity glow;
            public int hits = 0;
            public CrystalFragment(Entity entity, ObjectId crystalId, Vector3 renderPosition, CrystalType type, string bossPart)
            {
                this.entity = entity;
                this.crystalId = crystalId;
                this.renderPosition = renderPosition;
                this.type = type;
                this.bossPart = bossPart;
            }

        }


        public static string ColorText(string color, string text)
        {
            return color + text + WHITE;
        }
    }
    
}
