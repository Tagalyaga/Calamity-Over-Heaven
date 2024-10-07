using CalamityOverHeaven.Items;
using CalamityOverHeaven.Items.Stands;
using CalamityOverHeaven.Projectiles.PlayerStands.Panzerfaust;
using JoJoStands.UI;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;

namespace CalamityOverHeaven
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class CalamityOverHeaven : Mod
	{
		public static Mod JoJoStandsMod;
		public static Mod CalamityMod;
		public static CalamityOverHeaven Instance;

		public override void Load()
		{
			Instance = ModContent.GetInstance<CalamityOverHeaven>();
			JoJoStandsMod = ModLoader.GetMod("JojoStands");
			CalamityMod = ModLoader.GetMod("CalamityMod");

			JoJoStands.JoJoStands.standTier1List.Add(ModContent.ItemType<PanzerfaustT1>());

			//JojoStands.JojoStands.timestopImmune.Add(ModContent.ProjectileType<PanzerfaustT3>());
			//JojoStands.JojoStands.timestopImmune.Add(ModContent.ProjectileType<PanzerfaustT4>());
			//JojoStands.JojoStands.timestopImmune.Add(ModContent.ProjectileType<PanzerfaustModernaT1>());
			//JojoStands.JojoStands.timestopImmune.Add(ModContent.ProjectileType<PanzerfaustModernaT2>());
			//JojoStands.JojoStands.timestopImmune.Add(ModContent.ProjectileType<PanzerfaustModernaT3>());
			//JojoStands.JojoStands.timestopImmune.Add(ModContent.ProjectileType<PanzerfaustModernaT4>());
			//JojoStands.JojoStands.timestopImmune.Add(ModContent.ProjectileType<PanzerfaustModernaExtreme>());
		}

		public override void Unload()
		{
			JoJoStandsMod = null;
			Instance = null;
		}
	}
}
