// Murat Sancak

using UnityEngine;

namespace murasanca
{
    public class PP : PlayerPrefs // PP: Placer Preferences.
    {
        private readonly static int
            b,    // b: Blue.
            g,   // g: Green.
            r,  // r: Red.
            t; // t: Timer.

        // Murat Sancak

        public static int B // B: Blue.
        {
            get
            {
                if (!HasKey("b"))
                    B = 255;

                return GetInt("b", b);
            }
            set
            {
                SetInt("b", value);
                Save();
            }
        }
        public static int G // G: Green.
        {
            get
            {
                if (!HasKey("g"))
                    G = 255;

                return GetInt("g", g);
            }
            set
            {
                SetInt("g", value);
                Save();
            }
        }
        public static int R // R: Red.
        {
            get
            {
                if (!HasKey("r"))
                    R = 255;

                return GetInt("r", r);
            }
            set
            {
                SetInt("r", value);
                Save();
            }
        }

        public static int T // T: Timer.
        {
            get
            {
                if (!HasKey("t"))
                    T = 0;

                return GetInt("t", t);
            }
            set
            {
                SetInt("t", value);
                Save();
            }
        }

        // Murat Sancak

        public static void D()
        {
            DeleteKey("t"); // D: Delete.
            Save();
        }
    }
}

// Murat Sancak