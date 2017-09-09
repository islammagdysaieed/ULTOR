using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace DS_project
{
    public static class SoundManager
    {
        private static Song MenuSound;
        private static SoundEffectInstance GameSoundTrack;
        private static SoundEffectInstance HeroShootSound;
        private static SoundEffectInstance EnemyShootSound;
        private static SoundEffectInstance HeroDieSound;
        private static SoundEffectInstance EnemyDieSound;
        private static SoundEffectInstance PlaneSound;
        private static SoundEffectInstance PlaneCrashSound;
        private static SoundEffectInstance PlaneGrenadeSound;
        private static SoundEffectInstance GameOverSound;
        //For The Menu
        private static SoundEffectInstance ReloadSound;
        private static SoundEffectInstance BulletLoadSound;
        // Class Constructor
        public static void Load(ContentManager content)
        {
            MenuSound = content.Load<Song>("Tracks/Menuloop");
            GameSoundTrack = content.Load<SoundEffect>("Tracks/GameSoundTrack").CreateInstance();
            HeroShootSound = content.Load<SoundEffect>("Tracks/HeroGun").CreateInstance();
            EnemyShootSound = content.Load<SoundEffect>("Tracks/EnemyGun").CreateInstance();
            HeroDieSound = content.Load<SoundEffect>("Tracks/HeroDie").CreateInstance();
            EnemyDieSound = content.Load<SoundEffect>("Tracks/EnemyDie").CreateInstance();
            PlaneSound = content.Load<SoundEffect>("Tracks/Plane").CreateInstance();
            PlaneCrashSound = content.Load<SoundEffect>("Tracks/PlaneCrash").CreateInstance();
            PlaneGrenadeSound = content.Load<SoundEffect>("Tracks/PlaneGrenade").CreateInstance();
            GameOverSound = content.Load<SoundEffect>("Tracks/GameOver").CreateInstance();
            ReloadSound = content.Load<SoundEffect>("Tracks/Reload").CreateInstance();
            BulletLoadSound = content.Load<SoundEffect>("Tracks/BulletLoad").CreateInstance();
        }
        public static void PlayMenuSound()
        {
            MediaPlayer.Play(MenuSound);
        }
        public static void PlayGameSound()
        {
           GameSoundTrack.Play();
        }
        
        public static void PlayHeroShootSound()
        {
            HeroShootSound.Play();
        }
        public static void PlayEnemyShootSound()
        {
            EnemyShootSound.Play();
        }
        public static void PlayHeroDieSound()
        {
            HeroDieSound.Play();
        }
        public static void PlayEnemyDieSound()
        {
            EnemyDieSound.Play();
        }
        public static void PlayPlaneSound()
        {
            PlaneSound.Play();
        }
        public static void PlayPlaneCrushSound()
        {
            PlaneCrashSound.Play();
        }
        public static void PlayPlaneGrenadeSound()
        {
            PlaneGrenadeSound.Play();
        }
        public static void PlayPlaneCrashSound()
        {
            PlaneCrashSound.Play();
        }
        public static void PlayGameOverSound()
        {
            GameOverSound.Play();
        }
        public static void PlayReloadSound()
        {
            ReloadSound.Play();
        }
        public static void PlayBulletLoadSound()
        {
            BulletLoadSound.Play();
        }
    }
}

