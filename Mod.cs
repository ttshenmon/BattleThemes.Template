using BattleThemes.Template.Template;
using BattleThemes.Template.Template.Configuration;
using BGME.BattleThemes.Config;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

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

            /* Connect the battle theme files to the config. */
            /* Steps:
             * 1. Place battle theme files in: MOD_FOLDER/battle-themes/options
             * 2. Add a config setting for each song in the public class Config : Configurable<Config>
             * 3. Edit/copy and paste the line below with your new setting and the theme file it enables.
             * 
             * For example, if you have "song1.mp3" and "song2.mp3" in the options folder,
             * you can add settings like:
             * 
             * [DefaultValue(true)]
             * public bool Song1 { get; set; } = true;
             * 
             * [DefaultValue(true)]
             * public bool Song2 { get; set; } = true;
             */

            // Get all files in the battle-themes/options folder
            string[] themeFiles = Directory.GetFiles(Path.Combine(context.ModDirectory.FullName, "battle-themes", "options"));

            // Add settings for each song in the folder
            foreach (string file in themeFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                // Adding a configuration setting for each song file
                this.themeConfig.AddSetting(nameof(Config.Aespa), fileName); // Replace Config.Aespa with appropriate names for each song
            }

            /*-------------------------------------------------------*/
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
