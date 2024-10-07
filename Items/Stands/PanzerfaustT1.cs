using CalamityOverHeaven.Projectiles.PlayerStands.Panzerfaust;
using CalamityOverHeaven;
using JoJoStands;
using JoJoStands.Items.CraftingMaterials;
using JoJoStands.Items;
using JoJoStands.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalamityOverHeaven.Items.Stands
{
    public class PanzerfaustT1 : CalOHStandItemClass
    {
        public override int StandSpeed => 13;
        public override int StandType => 1;
        public override string StandIdentifierName => "Panzerfaust";
        public override int StandTier => 1;
        public override Color StandTierDisplayColor => Color.Yellow;
        public override string Texture
        {
            get { return Mod.Name + "/Items/Stands/PanzerfaustT1"; }
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Panzerfaust (Tier 1)");
            // Tooltip.SetDefault("Punch enemies at a really fast rate!\nUsed in Stand Slot");
        }

        public override void SetDefaults()
        {
            Item.damage = 21;
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 1;
            Item.value = 0;
            Item.noUseGraphic = true;
            Item.rare = ItemRarityID.LightPurple;
        }

        public override bool ManualStandSpawning(Player player)
        {
            Projectile.NewProjectile(Item.GetSource_FromThis(), player.position, player.velocity, ProjectileType<PanzerfaustStandT1>(), 0, 0f, Main.myPlayer);
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemType<StandArrow>())
                .AddIngredient(ItemType<WillToFight>(), 10)
                .AddIngredient(ItemType<WillToDestroy>(), 10)
                .AddTile(ModContent.TileType<RemixTableTile>())
                .Register();
        }
    }
}
