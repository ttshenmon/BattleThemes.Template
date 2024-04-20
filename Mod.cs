using BattleThemes.Template.Template;
using BattleThemes.Template.Template.Configuration;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using System.ComponentModel;

namespace BattleThemes.Template
{
    public class Mod : ModBase
    {
        private readonly IModLoader modLoader;
        private readonly ILogger log;
        private readonly IMod owner;

        private Config config;
        private readonly IModConfig modConfig;

        private readonly ThemeConfig themeConfig;

        public Mod(ModContext context)
        {
            this.modLoader = context.ModLoader;
            this.log = context.Logger;
            this.owner = context.Owner;
            this.config = context.Configuration;
            this.modConfig = context.ModConfig;

            this.themeConfig = new(this.modLoader, this.modConfig, this.config, this.log);

            /* Add the K-pop setting */
            this.themeConfig.AddSetting(nameof(this.config.Kpop), "kpop.theme.pme");

            /* Initialize the theme configuration */
            this.themeConfig.Initialize();
        }

        #region Standard Overrides
        public override void ConfigurationUpdated(Config configuration)
        {
            // Apply settings from configuration.
            // ... your code here.
            config = configuration;
            log.WriteLine($"[{modConfig.ModId}] Config Updated: Applying");
        }
        #endregion

        #region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Mod() { }
#pragma warning restore CS8618
        #endregion
    }

    public class Config : Configurable<Config>
    {
        /* New setting for K-pop */
        [Category("K-pop")]
        [DisplayName("K-pop Theme")]
        [Description("Enable K-pop battle theme.")]
        [DefaultValue(true)]
        public bool Kpop { get; set; } = true;
    }
}

