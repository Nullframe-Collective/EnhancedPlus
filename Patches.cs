using HarmonyLib;
using Il2Cpp;
using UnityEngine;
using UnityEngine.UI;
using static Il2Cpp.CharacterCustomization;

namespace EnhancedPlus
{
    [HarmonyPatch(typeof(RoomMultiplayerMenu), "Update")]
    public static class RMMPatch
    {
        public static void Postfix(RoomMultiplayerMenu __instance)
        {
            if (!__instance.IOMIAHNBDOG) return;

            Transform playerList = __instance.MLKCIJMJNHM.parent;
            if (playerList == null) return;

            foreach (Transform playerCard in playerList.GetComponentsInChildren<Transform>())
            {
                Text playerName = playerCard.Find("Name")?.GetComponent<Text>();
                if (playerName == null) continue;

                if (playerName.text == RoomProperties.Current?.HostName)
                {
                    playerName.text = $"{playerName.text} (Host)";

                    break;
                }
            }
        }
    }

    [HarmonyPatch(typeof(SyncCustomization), "Start")]
    public static class SyncCustomizationPatch
    {
        public static void Postfix(SyncCustomization __instance)
        {
            if (!Manager.Config.FixBrokenHats) return;

            GameObject hats = __instance.LEEICKEPPEB?.gameObject;
            if (hats == null) return;

            foreach (Transform hat in hats.GetComponentsInChildren<Transform>(true))
            {
                if (hat.gameObject.name == "Fire (1)")
                {
                    ParticleSystem particleSystem = hat.gameObject.GetComponent<ParticleSystem>();
                    if (particleSystem != null)
                    {
                        particleSystem.emission.enabled = true;
                    }
                }

                if (hat.gameObject.name == "KnightHelmet")
                {
                    MeshRenderer meshRenderer = hat.gameObject.GetComponent<MeshRenderer>();
                    if (meshRenderer != null)
                    {
                        meshRenderer.enabled = true;
                    }
                }
            }
        }
    }

    [HarmonyPatch(typeof(CharacterCustomization), "Awake")]
    public static class CharacterCustomizationPatch
    {
        public static void Prefix(CharacterCustomization __instance)
        {
            hat[] hats =
            [
                new hat { hatID = 74, hatName = "Sean's Hat", hatPrice = 0 },
                new hat { hatID = 23, hatName = "KnightHelmet", hatPrice = 0 },
                new hat { hatID = 7, hatName = "Ushanka", hatPrice = 0 },
                new hat { hatID = 15, hatName = "Fez", hatPrice = 0 },
                new hat { hatID = 18, hatName = "HuntersHat", hatPrice = 0 },
                new hat { hatID = 24, hatName = "LaserGlasses", hatPrice = 0 },
                new hat { hatID = 25, hatName = "Mohawk", hatPrice = 0 },
                new hat { hatID = 28, hatName = "PirateHat", hatPrice = 0 },
                new hat { hatID = 29, hatName = "PoliceHat", hatPrice = 0 },
                new hat { hatID = 30, hatName = "TopHat", hatPrice = 0 },
                new hat { hatID = 71, hatName = "Pumpkin_03", hatPrice = 0 },
                new hat { hatID = 72, hatName = "CowboyHat", hatPrice = 0 },
                new hat { hatID = 73, hatName = "BowlerHat", hatPrice = 0 },
            ];

            foreach (hat hat in hats)
            {
                if ((hat.hatID == 23 || hat.hatID == 74) && !Manager.Config.FixBrokenHats) continue;

                __instance.GKCNMADGAAF.Add(hat);
            }

            if (!Manager.Config.FixBrokenHats) return;

            GameObject knightHelmet = __instance.LEEICKEPPEB?.Find("KnightHelmet").gameObject;
            MeshRenderer meshRenderer = knightHelmet?.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.enabled = true;
            }
        }
    }
}
