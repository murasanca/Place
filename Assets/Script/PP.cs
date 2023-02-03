// Murat Sancak

namespace murasanca
{
    /// <summary>
    /// Placer Preferences
    /// </summary>
    public class PP:UnityEngine.PlayerPrefs
    {
        /// <summary>
        /// Blue
        /// </summary>
        public static int B
        {
            get=>GetInt("b",255);
            set
            {
                SetInt("b",value);
                Save();
            }
        }
        /// <summary>
        /// Green
        /// </summary>
        public static int G
        {
            get=>GetInt("g",255);
            set
            {
                SetInt("g",value);
                Save();
            }
        }
        /// <summary>
        /// Red
        /// </summary>
        public static int R
        {
            get=>GetInt("r",255);
            set
            {
                SetInt("r",value);
                Save();
            }
        }

        /// <summary>
        /// Timer
        /// </summary>
        public static int T
        {
            get=>GetInt("t",0);
            set
            {
                SetInt("t",value);
                Save();
            }
        }

        // Murat Sancak

        /// <summary>
        /// Delete
        /// </summary>
        public static void D()
        {
            DeleteKey("t");
            Save();
        }
    }
}

// Murat Sancak