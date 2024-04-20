using System.IO;
using Reloaded.Mod.Interfaces;
using System.ComponentModel;

namespace BattleThemes.Template
{
    public class Mod : ModBase
    {
        public Mod(ModContext context)
        {
            string modDirectory = @"E:\Reloaded2\Mods";
            string optionsDirectory = Path.Combine(modDirectory, "sees.costume.kpop", "battle-themes", "music");

            string[] themeFiles = Directory.GetFiles(optionsDirectory);

            foreach (string file in themeFiles)
            {
                string fileName = Path.GetFileName(file);
                AddSetting(nameof(Config.Kpop), fileName); // Change Aespa to Kpop
            }

            Initialize();
        }

        public Mod() { }
    }

    public class Config : Configurable<Config>
    {
        /* ADD CONFIG SETTINGS HERE */

        [DefaultValue(true)]
        public bool Kpop { get; set; } = true; // Change Aespa to Kpop

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
