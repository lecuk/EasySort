using System;
using System.Collections.Generic;
using System.Media;

namespace EasySort.Classes
{
    static class SoundSource
    {
        static SoundPlayer player = new SoundPlayer(@"C:\Users\Fox\source\repos\ArraySortVisualizer\ArraySortVisualizer\PianoHitSound.wav");

        public static void Play()
        {
            player.Play();
        }
    }
}
