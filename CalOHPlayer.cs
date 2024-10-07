//using CalamityOverHeaven.Buffs;
using CalamityOverHeaven.Items.Stands;
//using CalamityOverHeaven.Mounts;
using JoJoStands;
using JoJoStands.Items.Hamon;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalamityOverHeaven
{
    public class CalOHPlayer : ModPlayer
    {
        public static bool Gay = false;

        private int standKeyPressTimer = 0;

        public bool customCameraOverride = false;

        public Vector2 customCameraPosition;

        public override void ResetEffects()
        {
            customCameraOverride = false;
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            Player player = Main.player[Main.myPlayer];
            MyPlayer mPlayer = player.GetModPlayer<MyPlayer>();
            HamonPlayer hPlayer = player.GetModPlayer<HamonPlayer>();

            if (JoJoStands.JoJoStands.StandOutHotKey.JustPressed && mPlayer.standOut && standKeyPressTimer <= 0)
            {
                standKeyPressTimer += 30;
                mPlayer.immuneToTimestopEffects = false;
                
            }
            if (JoJoStands.JoJoStands.SpecialHotKey.JustPressed)
            {
                
            }
        }

        public override void PreUpdate()
        {
            Player player = Main.player[Main.myPlayer];
            MyPlayer mPlayer = player.GetModPlayer<MyPlayer>();
        }

            
    

        public void SpawnCalOHStand()
        {
            MyPlayer mPlayer = Player.GetModPlayer<MyPlayer>();
            Item inputItem = mPlayer.StandSlot.SlotItem;

            CalOHStandItemClass standItem = inputItem.ModItem as CalOHStandItemClass;
            string standClassName = standItem.StandIdentifierName + "StandT" + standItem.StandTier;
            if (standClassName.Contains("T4"))
                standClassName = standItem.StandIdentifierName + "StandFinal";

            int standProjectileType = Mod.Find<ModProjectile>(standClassName).Type;
            Projectile.NewProjectile(inputItem.GetSource_FromThis(), Player.position, Player.velocity, standProjectileType, 0, 0f, Player.whoAmI);
        }

        public override void ModifyScreenPosition()     //used HERO's Mods FlyCam as a reference for this
        {
            MyPlayer mPlayer = Player.GetModPlayer<MyPlayer>();
            if (mPlayer.standOut && customCameraOverride)
                Main.screenPosition = customCameraPosition;
        }

        public override void ModifyHitByNPC(NPC npc, ref Player.HurtModifiers modifiers)
        {
            
        }

        public override void HideDrawLayers(PlayerDrawSet drawInfo)
        {
            
        }
    }
}