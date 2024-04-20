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

            this.themeConfig = new ThemeConfig(this.modLoader, this.modConfig, this.config, this.log);

            string modDirectory = @"E:\Reloaded2\Mods";
            string optionsDirectory = Path.Combine(modDirectory, "sees.costume.kpop", "battle-themes", "music");

            string[] themeFiles = Directory.GetFiles(optionsDirectory);

            foreach (string file in themeFiles)
            {
                string fileName = Path.GetFileName(file);
                this.themeConfig.AddSetting(nameof(Config.Kpop), fileName); // Replace Config.Kpop with appropriate names for each song
            }

            this.themeConfig.Initialize();
        }

        public override void ConfigurationUpdated(Config configuration)
        {
            config = configuration;
            log.WriteLine($"[{modConfig.ModId}] Config Updated: Applying");
        }

        public Mod() { }
    }

    public class Config : Configurable<Config>
    {
        /* ADD CONFIG SETTINGS HERE */

        // Replace the configuration settings with appropriate names for your songs
        [Category("Kpop")]
        [DisplayName("Aespa")]
        [Description("Battle theme: Aespa")]
        [DefaultValue(true)]
        public bool Aespa { get; set; } = true;

        [Category("Kpop")]
        [DisplayName("Beast")]
        [Description("Battle theme: Beast")]
        [DefaultValue(true)]
        public bool Beast { get; set; } = true;

        [Category("Kpop")]
        [DisplayName("BTS")]
        [Description("Battle theme: BTS")]
        [DefaultValue(true)]
        public bool Bts { get; set; } = true;

        [Category("Kpop")]
        [DisplayName("Gidle")]
        [Description("Battle theme: Gidle")]
        [DefaultValue(true)]
        public bool Gidle { get; set; } = true;

        [Category("Kpop")]
        [DisplayName("Got7")]
        [Description("Battle theme: Got7")]
        [DefaultValue(true)]
        public bool Got7 { get; set; } = true;

        [Category("Kpop")]
        [DisplayName("Lesserafim")]
        [Description("Battle theme: Lesserafim")]
        [DefaultValue(true)]
        public bool Lesserafim { get; set; } = true;

        [Category("Kpop")]
        [DisplayName("Nmixx")]
        [Description("Battle theme: Nmixx")]
        [DefaultValue(true)]
        public bool Nmixx { get; set; } = true;

        [Category("Kpop")]
        [DisplayName("Redvelvet")]
        [Description("Battle theme: Redvelvet")]
        [DefaultValue(true)]
        public bool Redvelvet { get; set; } = true;

        [Category("Kpop")]
        [DisplayName("Shinee")]
        [Description("Battle theme: Shinee")]
        [DefaultValue(true)]
        public bool Shinee { get; set; } = true;

        [Category("Kpop")]
        [DisplayName("Stayc")]
        [Description("Battle theme: Stayc")]
        [DefaultValue(true)]
        public bool Stayc { get; set; } = true;
    }
