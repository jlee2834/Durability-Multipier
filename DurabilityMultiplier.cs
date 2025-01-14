using System.ComponentModel;
using Newtonsoft.Json;
using Oxide.Core.Plugins;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("Durability Multiplier", "jlee2834", "1.0.0")]
    [Description("Adjusts the durability of tools and weapons.")]
    public class DurabilityMultiplier : RustPlugin
    {
        #region Configuration

        private PluginConfig _pluginConfig;

        public class PluginConfig
        {
            [JsonProperty(PropertyName = "Durability Multiplier")]
            [DefaultValue(2.0f)]
            public float Multiplier { get; set; } = 2.0f;
        }

        protected override void LoadDefaultConfig()
        {
            PrintWarning("Loading default configuration...");
            _pluginConfig = new PluginConfig();
        }

        protected override void LoadConfig()
        {
            base.LoadConfig();
            _pluginConfig = Config.ReadObject<PluginConfig>() ?? new PluginConfig();
            if (_pluginConfig.Multiplier <= 0)
            {
                _pluginConfig.Multiplier = 1.0f;
                PrintWarning("Multiplier must be greater than 0. Defaulting to 1.0.");
            }
            Config.WriteObject(_pluginConfig);
        }

        #endregion Configuration

        #region Oxide Hooks

        private void OnItemRepair(Item item, BasePlayer player)
        {
            if (item == null || player == null) return;

            // Apply the multiplier to the condition max.
            item.condition = Mathf.Min(item.maxCondition * _pluginConfig.Multiplier, item.info.condition.max);
            item.MarkDirty();

            // Notify player about the repair update
            player.ChatMessage($"[DurabilityMultiplier] Your repaired item's durability has been adjusted to {_pluginConfig.Multiplier}x.");
        }

        #endregion Oxide Hooks
    }
}
