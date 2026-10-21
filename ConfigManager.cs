using System.Text.Json;
using UnityEngine;
using Config = EnhancedPlus.ConfigStuff.Config;

namespace MasterHell.Configs
{
    public class ConfigManager
    {
        private const string DefaultConfigPath = "UserData/EnhancedPlus/Config.json";

        public virtual Config Load(string configPath = "")
        {
            configPath = string.IsNullOrEmpty(configPath) ? DefaultConfigPath : configPath;

            Directory.CreateDirectory(Path.GetDirectoryName(configPath));

            if (File.Exists(configPath))
            {
                try
                {
                    var json = File.ReadAllText(configPath);
                    return JsonSerializer.Deserialize<Config?>(json) ?? new Config();
                }
                catch { }
            }

            return Save(new Config(), configPath);
        }

        public virtual Config Save(Config config, string configPath = "")
        {
            configPath = string.IsNullOrEmpty(configPath) ? DefaultConfigPath : configPath;

            var json = JsonSerializer.Serialize(config);
            File.WriteAllText(configPath, json);

            return config;
        }

        public static KeyCode TryParseKeyCode(string keyName, KeyCode defaultValue = KeyCode.None)
        {
            if (Enum.TryParse(keyName, true, out KeyCode result)) return result;

            return defaultValue;
        }
    }
}