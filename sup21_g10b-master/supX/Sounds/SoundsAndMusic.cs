using supX.ViewModels;
using System;
using System.Collections.Generic;
using System.Media;
using System.Text;
using System.Windows.Media;

namespace supX.Sounds
{
    public class SoundsAndMusic
    {
        #region Constructors   
        public SoundsAndMusic()
        {
            
        }
        #endregion

        #region SoundEffects
        /// <summary>
        /// Plays cash Register sound when making a bet
        /// </summary>
        public void PlayCashRegisterSound()
        {
            var player = new SoundPlayer(Properties.Resources.Cash_Register);
            player.Play();
        }

        /// <summary>
        /// Plays when game over
        /// </summary>
        public void PlayGameOverSound()
        {
            var player = new SoundPlayer(Properties.Resources.GameOverSoundTuneLow);
            player.Play();
        }

        /// <summary>
        /// Plays when player loses money
        /// </summary>
        public void PlayLosingGameSound()
        {
            var player = new SoundPlayer(Properties.Resources.GameOverMelodyLow);
            player.Play();
        }
        /// <summary>
        /// Plays when player wins money
        /// </summary>
        public void PlayWinnerGameSound()
        {
            var player = new SoundPlayer(Properties.Resources.WinningSoundLow);
            player.Play();
        }

        /// <summary>
        /// Intro sound for Game
        /// </summary>
        public void PlayIntroSound()
        {
            SoundPlayer loop = new SoundPlayer(Properties.Resources.retroLowSound);
            loop.PlayLooping();
        }

        /// <summary>
        /// Sounds that starts a fight between two fighters
        /// </summary>
        public void PlayFightSound()
        {
            var player = new SoundPlayer(Properties.Resources.fight);
            player.Play();
        }

        /// <summary>
        /// Countdown befor a fight starts
        /// </summary>
        public void PlayCountDownSound()
        {
            var player = new SoundPlayer(Properties.Resources.robotic_countdown);
            player.Play();
        }

        /// <summary>
        /// Intro to Wembley
        /// </summary>
        public void PlayWemblyIntroSound()
        {
            var player = new SoundPlayer(Properties.Resources.WembleyGreetingsWithApplauseLow);
            player.Play();
        }

        /// <summary>
        /// Intro to Backyard
        /// </summary>
        public void PlayBackyardIntroSound()
        {
            var player = new SoundPlayer(Properties.Resources.BackyardGreetingsWithApplauseLow);
            player.Play();
        }

        /// <summary>
        /// Intro to Bellagio
        /// </summary>
        public void PlayBellagioIntroSound()
        {
            var player = new SoundPlayer(Properties.Resources.BellagioGreetingsWithApplauseLow);
            player.Play();
        }

        /// <summary>
        /// Sound during a fight 
        /// </summary>
        public void PlayFightingSound()
        {
            var player = new SoundPlayer(Properties.Resources.PlayFighting);
            player.Play();
        }
               

        /// <summary>
        /// Plays the Arena sound as a loop
        /// </summary>
        public void PlayArenaIntroSound() 
        {
            SoundPlayer loop  = new SoundPlayer(Properties.Resources.PlayArenaIntroSoundLowSound);
            loop.PlayLooping();
        }

        #endregion



    }
}
