using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace CalamityOverHeaven
{
    public class CustomizableOptions : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [DefaultValue(false)]
        [Label("Gay Mode")]
        [Tooltip("Whether or not you are gay")]
        public bool Gay;

        public override void OnChanged()        //couldn't use Player player = Main.LocalPlayer cause it wasn't set to an instance of an object
        {
            CalOHPlayer.Gay = Gay;
        }
    }
}