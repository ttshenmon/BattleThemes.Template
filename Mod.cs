using BattleThemes.Template.Template;
using BattleThemes.Template.Template.Configuration;
using BGME.BattleThemes.Config;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace BattleThemes.Template
{
    public class Mod : ModBase
    {
        private readonly IModLoader modLoader;
        private readonly IReloadedHooks? hooks;
        private readonly ILogger log;
        private readonly IMod owner;

        private Config config;
        private readonly IModConfig modConfig;

        private readonly ThemeConfig themeConfig;

        public Mod(ModContext context)
        {
            this.modLoader = context.ModLoader;
            this.hooks = context.Hooks;
            this.log = context.Logger;
            this.owner = context.Owner;
            this.config = context.Configuration;
            this.modConfig = context.ModConfig;

            this.themeConfig = new(this.modLoader, this.modConfig, this.config, this.log);

            // Get the directory where the mod assembly is located
            string modDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Combine the mod directory with the relative path to the theme files
            string optionsDirectory = Path.Combine(modDirectory, "battle-themes", "options");

            // Get all files in the battle-themes/options folder
            string[] themeFiles = Directory.GetFiles(optionsDirectory);

            // Add settings for each song in the folder
            foreach (string file in themeFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                // Adding a configuration setting for each song file
                this.themeConfig.AddSetting(nameof(Config.Aespa), fileName); // Replace Config.Aespa with appropriate names for each song
            }

            // Initialize the theme configuration
            this.themeConfig.Initialize();
        }

        public override void ConfigurationUpdated(Config configuration)
        {
            // Apply settings from configuration.
            // ... your code here.
            config = configuration;
            log.WriteLine($"[{modConfig.ModId}] Config Updated: Applying");
        }

        public Mod() { }
    }

    public class Config : Configurable<Config>
    {
        /* ADD CONFIG SETTINGS HERE */
        // Add a configuration setting for each song file
        [DefaultValue(true)]
        public bool Aespa { get; set; } = true;

        [DefaultValue(true)]
        public bool Beast { get; set; } = true;

        [DefaultValue(true)]
        public bool Bts { get; set; } = true;

        [DefaultValue(true)]
        public bool Gidle { get; set; } = true;

        [DefaultValue(true)]
        public bool Got7 { get; set; } = true;

        [DefaultValue(true)]
        public bool Lesserafim { get; set; } = true;

        [DefaultValue(true)]
        public bool Nmixx { get; set; } = true;

        [DefaultValue(true)]
        public bool Redvelvet { get; set; } = true;

        [DefaultValue(true)]
        public bool Shinee { get; set; } = true;

        [DefaultValue(true)]
        public bool Stayc { get; set; } = true;
    }
}
