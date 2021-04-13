using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finale_Project
{
    static class SoundManager
    {
        public static bool soundOn = false;
        static void Sounds()
        {
            Console.Beep(196, 250);//GVendor
            Console.Beep(220, 250);//A
            Console.Beep(233, 250);//A#
            Console.Beep(247, 250);//B
            Console.Beep(261, 250);//C
            Console.Beep(277, 250);//C#
            Console.Beep(293, 250);//D
            Console.Beep(311, 250);//Eb
            Console.Beep(329, 250);//E
            Console.Beep(349, 250);//F
            Console.Beep(370, 250);//F#
            Console.Beep(392, 250);//G
            Console.Beep(415, 250);//G#
            Console.Beep(440, 250);//A
            Console.Beep(466, 250);//Bb
            Console.Beep(493, 250);//B
        }
        public static void WalkSound()
        {
            if(soundOn)
            {
                Console.Beep(261, 100);//C
            }
        }
        public static void SwordSound()
        {
            if (soundOn)
            {
                Console.Beep(329, 100);//E
                Console.Beep(329, 100);//E
                Console.Beep(392, 250);//G
            }
        }
        public static void BowSound()
        {
            if (soundOn)
            {
                Console.Beep(392, 100);//G
                Console.Beep(392, 100);//G
                Console.Beep(493, 250);//B
            }
        }
        public static void GetHitSound()
        {
            if (soundOn)
            {
                Console.Beep(440, 200);//A
                Console.Beep(415, 200);//G#
                Console.Beep(392, 400);//G
            }
        }
        public static void TrapSound()
        {
            if (soundOn)
            {
                Console.Beep(247, 50);//B
                Console.Beep(233, 50);//A#
                Console.Beep(220, 200);//A
            }
        }
        public static void VendorSound()
        {
            if (soundOn)
            {
                Console.Beep(261, 100);//C
                Console.Beep(392, 250);//G
            }
        }
        public static void ChestSound()
        {
            if (soundOn)
            {
                Console.Beep(261, 100);//C
                Console.Beep(349, 250);//F
            }
        }
        public static void PerchaseSound()
        {
            if (soundOn)
            {
                Console.Beep(247, 100);//B
                Console.Beep(329, 250);//E
            }
        }
        public static void NextLevelSound()
        {
            if (soundOn)
            {
                Console.Beep(261, 150);//C
                Console.Beep(277, 250);//C#
                Console.Beep(293, 250);//D
                Console.Beep(311, 250);//Eb
                Console.Beep(329, 250);//E
            }
        }
    }
}
