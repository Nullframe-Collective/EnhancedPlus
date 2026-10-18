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
                    playerName.text = $"{playerName.text} — Host";

                    break;
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
                //new hat { hatID = 74, hatName = "Bald (Sean's hat)", hatPrice = 0 },
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
                __instance.GKCNMADGAAF.Add(hat);
            }
        }
    }
}
