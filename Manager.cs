using Il2Cpp;
using Il2CppFishNet;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

[assembly: MelonInfo(typeof(EnhancedPlus.Manager), "Enhanced+", "1.0.0", "Nullframe Collective", null)]
[assembly: MelonGame("ZeoWorks", "Slendytubbies 3")]
[assembly: MelonColor(8, 245, 174, 39)]

namespace EnhancedPlus
{
    public class Manager : MelonMod
    {
        private WhoKilledWho _whoKilledWho;
        private bool _showInfoData = false;
        private int _sceneIndex;

        public override void OnInitializeMelon()
        {
            MelonLogger.Msg("Initialized.");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            _sceneIndex = buildIndex;
            _whoKilledWho = null;
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F10))
            {
                _showInfoData = !_showInfoData;
            }

            if (Input.GetKeyDown(KeyCode.F9))
            {
                SceneManager.LoadScene(0);
            }
        }

        public override void OnGUI()
        {
            if (!_showInfoData || _sceneIndex <= 1) return;

            GUI.skin = GetWhoKilledWho()?.BIPMFIBNFBC;
            int fpsValue = (int)(1f / Time.unscaledDeltaTime);
            long pingValue = InstanceFinder.TimeManager.RoundTripTime;
            string fpsText = $"FPS: <color={GetFpsColor(fpsValue)}>{fpsValue}</color>";
            string pingText = $"PING: {pingValue}ms";

            GUI.Label(new Rect(0f, 0f, 100f, 50f), fpsText);
            GUI.Label(new Rect(100f, 0f, 100f, 50f), pingText);
        }

        private WhoKilledWho GetWhoKilledWho()
        {
            if (_whoKilledWho == null)
            {
                _whoKilledWho = GameObject.FindObjectOfType<WhoKilledWho>();
            }

            return _whoKilledWho;
        }

        private static string GetFpsColor(int fps) => fps switch
        {
            < 30 => "red",
            < 50 => "yellow",
            _ => "green"
        };

        public static void Log(object msg)
        {
            MelonLogger.Msg(msg);
        }
    }
}