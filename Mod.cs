using System;
using System.IO;
using BattleThemes.Template.Template;
using BattleThemes.Template.Template.Configuration;
using BGME.BattleThemes.Config;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using System.ComponentModel;

namespace BattleThemes.Template
{
    public class Mod : ModBase
    {
        private readonly IModLoader? modLoader;
        private readonly IReloadedHooks? hooks;
        private readonly ILogger? log;
        private readonly IMod? owner;

        private Config? config;
        private readonly IModConfig? modConfig;

        private readonly ThemeConfig? themeConfig;

        public Mod(ModContext context)
        {
            this.modLoader = context.ModLoader;
            this.hooks = context.Hooks;
            this.log = context.Logger;
            this.owner = context.Owner;
            this.config = context.Configuration;
            this.modConfig = context.ModConfig;

            this.themeConfig = new(this.modLoader!, this.modConfig!, this.config!, this.log!);

            // Update the directory path to the correct one
            string modDirectory = @"E:\Reloaded2\Mods";
            string optionsDirectory = Path.Combine(modDirectory, "sees.costume.kpop", "battle-themes", "options");

            string[] themeFiles = Directory.GetFiles(optionsDirectory);

            foreach (string file in themeFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                this.themeConfig.AddSetting(nameof(Config.Aespa), fileName); // Replace Config.Aespa with appropriate names for each song
            }

            this.themeConfig.Initialize();
        }

        public override void ConfigurationUpdated(Config configuration)
        {
            config = configuration;
            log?.WriteLine($"[{modConfig?.ModId}] Config Updated: Applying");
        }

        public Mod() { }
    }

    public class Config : Configurable<Config>
    {
        /* ADD CONFIG SETTINGS HERE */

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
