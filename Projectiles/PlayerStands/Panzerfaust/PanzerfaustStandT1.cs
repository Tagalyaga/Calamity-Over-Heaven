using JoJoStands;
using JoJoStands.Buffs.Debuffs;
using JoJoStands.Buffs.EffectBuff;
using JoJoStands.Items;
using JoJoStands.Projectiles;
using JoJoStands.Projectiles.PlayerStands;
using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityOverHeaven.Projectiles.PlayerStands.Panzerfaust
{
    public class PanzerfaustStandT1 : StandClass
    {
        public override int PunchDamage => 21;
        public override int PunchTime => 13;
        public override int HalfStandHeight => 44;
        public override int FistID => 1;
        public override int TierNumber => 1;
        public override string PunchSoundName => "Muda";
        public override string PoseSoundName => "ComeAsCloseAsYouLike";
        public override string SpawnSoundName => "The World";
        public override int AmountOfPunchVariants => 3;
        public override string PunchTexturePath => "CalamityOverHeaven/Projectiles/PlayerStands/Panzerfaust/TWOH_Punch_";
        public override Vector2 PunchSize => new Vector2(28, 12);
        public override PunchSpawnData PunchData => new PunchSpawnData()
        {
            standardPunchOffset = new Vector2(10f, 0f),
            minimumLifeTime = 6,
            maximumLifeTime = 12,
            minimumTravelDistance = 18,
            maximumTravelDistance = 36,
            bonusAfterimageAmount = 0
        };

        public override bool CanUseSaladDye => true;
        public override StandAttackType StandType => StandAttackType.Melee;

        public override void AI()
        {
            SelectAnimation();
            UpdateStandInfo();
            UpdateStandSync();
            if (shootCount > 0)
                shootCount--;

            Player player = Main.player[Projectile.owner];
            MyPlayer mPlayer = player.GetModPlayer<MyPlayer>();
            CalOHPlayer cPlayer = player.GetModPlayer<CalOHPlayer>();
            if (mPlayer.standOut)
                Projectile.timeLeft = 2;

            if (mPlayer.standControlStyle == MyPlayer.StandControlStyle.Manual)
            {
                if (Projectile.owner == Main.myPlayer)
                {
                    if (Main.mouseLeft)
                        Punch();
                    else
                    {
                        attacking = false;
                        currentAnimationState = AnimationState.Idle;
                    }
                }
                if (!attacking)
                    StayBehind();
            }
            else if (mPlayer.standControlStyle == MyPlayer.StandControlStyle.Auto)
            {
                BasicPunchAI();
            }
            if (mPlayer.posing)
                currentAnimationState = AnimationState.Pose;

            
        }


        


        public override void SelectAnimation()
        {
            if (oldAnimationState != currentAnimationState)
            {
                Projectile.frame = 0;
                Projectile.frameCounter = 0;
                oldAnimationState = currentAnimationState;
                Projectile.netUpdate = true;
            }

            if (currentAnimationState == AnimationState.Idle)
                PlayAnimation("Idle");
            else if (currentAnimationState == AnimationState.Attack)
                PlayAnimation("Attack");
            else if (currentAnimationState == AnimationState.Pose)
                PlayAnimation("Pose");
        }

        public override void PlayAnimation(string animationName)
        {
            if (Main.netMode != NetmodeID.Server)
                standTexture = GetStandTexture("CalamityOverHeaven/Projectiles/PlayerStands/Panzerfaust", "TWOH_" + animationName);

            if (animationName == "Idle")
                AnimateStand(animationName, 4, 15, true);
            else if (animationName == "Attack")
                AnimateStand(animationName, 4, newPunchTime, true);
            else if (animationName == "Pose")
                AnimateStand(animationName, 1, 10, true);
        }
    }
}