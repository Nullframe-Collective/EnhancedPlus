using EnhancedPlus.ConfigStuff;
using Il2Cpp;
using Il2CppFishNet;
using MasterHell.Configs;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

[assembly: MelonInfo(typeof(EnhancedPlus.Manager), "Enhanced+", "1.1.0", "Nullframe Collective", "https://github.com/Nullframe-Collective/EnhancedPlus")]
[assembly: MelonGame("ZeoWorks", "Slendytubbies 3")]
[assembly: MelonColor(8, 245, 174, 39)]

namespace EnhancedPlus
{
    public class Manager : MelonMod
    {
        public static Config Config;
        private ConfigManager _configManager = new();
        private WhoKilledWho _whoKilledWho;
        private bool _showInfoData = false;
        private int _sceneIndex;

        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
            Config = _configManager.Load();
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            _sceneIndex = buildIndex;
            _whoKilledWho = null;
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(ConfigManager.TryParseKeyCode(Config.ShowInfoButton)))
            {
                _showInfoData = !_showInfoData;
            }

            if (Input.GetKeyDown(ConfigManager.TryParseKeyCode(Config.ReturnToMenuButton)))
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