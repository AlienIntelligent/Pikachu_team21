using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace Pikachu_Sound
{
    class Sound
    {
        private SoundPlayer soundplayer;
        private bool isPlaying;
        
        public Sound(string path)
        {
            soundplayer = new SoundPlayer(path);
        }
        
        public bool GetisPlaying()
        {
            return isPlaying;
        }
        public void SetisPlaying(bool value)
        {
            isPlaying = value;
        }
        public void PlaySound()
        {
            soundplayer.PlayLooping();
            isPlaying = true;
        }

        public void PlaySoundOnce()
        {
            soundplayer.Play();
        }
        public void StopSound() 
        {
            soundplayer.Stop();
            isPlaying= false;
        }
    }
}
