// Murat Sancak

using UnityEngine.Advertisements;

namespace murasanca
{
    /// <summary>
    /// Monetization
    /// </summary>
    public class M:UnityEngine.MonoBehaviour,IUnityAdsInitializationListener,IUnityAdsLoadListener,IUnityAdsShowListener
    {
        /// <summary>
        /// Place User Interface Game Object
        /// </summary>
        [UnityEngine.SerializeField]
        private UnityEngine.GameObject pUIGO;

        /// <summary>
        /// Test
        /// </summary>
        private const bool t=true;
        private const string
            b="banner", // b: Banner.
            g          // g: Game.
            =
#if UNITY_IOS
            "4767645"
#else // UNITY_ANDROID
            "4767644"
#endif
            ,
            i="video",          // i: Interstitial.
            r="rewardedVideo"; // r: Rewarded.

        /// <summary>
        /// not Implemented Exception
        /// </summary>
        private readonly System.NotImplementedException NIE=new();
        /// <summary>
        /// Wait for Seconds
        /// </summary>
        private readonly UnityEngine.WaitForSeconds wFS=new(1);

        /// <summary>
        /// Monetization
        /// </summary>
        public static M m;
                /// <summary>
        /// Place User Interface Rect Transform
        /// </summary>
        private static UnityEngine.RectTransform pUIRT;

        // Murat Sancak

        /// <summary>
        /// is Banner Loaded
        /// </summary>
        public static bool IBL=>Advertisement.Banner.isLoaded;
        /// <summary>
        /// is Initialized
        /// </summary>
        public static bool II=>Advertisement.isInitialized;

        /// <summary>
        /// is Interstitial Loaded
        /// </summary>
        public static bool IIL{get;private set;}=false;
        /// <summary>
        /// is Interstitial Showing
        /// </summary>
        public static bool IIS{get;private set;}=false;

        /// <summary>
        /// is Rewarded Loaded
        /// </summary>
        public static bool IRL{get;private set;}=false;
        /// <summary>
        /// is Rewarded Showing
        /// </summary>
        public static bool IRS{get;private set;}=false;

        // Murat Sancak

        private void Awake()
        {
            m=this;

            pUIRT=pUIGO.GetComponent<UnityEngine.RectTransform>();
        }

        private void Start()=>StartCoroutine(S());

        // Murat Sancak

        /// <summary>
        /// Start
        /// </summary>
        /// <returns>Wait for Seconds</returns>
        private System.Collections.IEnumerator S()
        {
            while(true)
            {
                if(IAP.HR(0))
                {
                    H();

                    StopCoroutine(S());
                }
                else if(II)
                {
                    if(!IBL)
                        Advertisement.Banner.Load(b);
                    else
                    {
                        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                        Advertisement.Banner.Show(b);
                    }

                    if(!IIL)
                        Advertisement.Load(i,m);

                    if(!IRL)
                        Advertisement.Load(r,m);
                }
                else
                    Advertisement.Initialize(g,t,m);

                yield return wFS;
            }
        }

        // Murat Sancak

        /// <summary>
        /// Interstitial
        /// </summary>
        public void I()
        {
            if(IAP.HR(0)||!IIL)
                G.P();
            else
                Advertisement.Show(i,m);
        }

        /// <summary>
        /// Rewarded
        /// </summary>
        public void R()
        {
            if(IAP.HR(0))
                G.R();
            else if(IRL)
                Advertisement.Show(r,m);
        }

        /// <summary>
        /// Hide
        /// </summary>
        public static void H()
        {
            Advertisement.Banner.Hide();

            pUIRT.offsetMax=UnityEngine.Vector2Int.zero;
        }

        // Murat Sancak

        /// <summary>
        /// on Initialization Complete
        /// </summary>
        public void OnInitializationComplete()
        {
            if(IBL)
            {
                Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                Advertisement.Banner.Show(b);
            }
            else
                Advertisement.Banner.Load(b);
        }

        /// <summary>
        /// on Initialization Failed
        /// </summary>
        /// <param name="uAIE">Unity Ads Initialization Error</param>
        /// <param name="f">Failure</param>
        public void OnInitializationFailed(UnityAdsInitializationError uAIE,string f)=>Advertisement.Initialize(g,t,m);

        /// <summary>
        /// on Unity Ads Ad Loaded
        /// </summary>
        /// <param name="a">Advertisement</param>
        public void OnUnityAdsAdLoaded(string a)
        {
            switch(a)
            {
                case b:
                    Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                    Advertisement.Banner.Show(b);
                    break;
                case i:
                    IIL=true;
                    break;
                case r:
                    IRL=true;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// on Unity Ads Failed to Load
        /// </summary>
        /// <param name="a">Advertisement</param>
        /// <param name="uALE">Unity Ads Load Error</param>
        /// <param name="f">Failure</param>
        public void OnUnityAdsFailedToLoad(string a,UnityAdsLoadError uALE,string f)
        {
            switch (a)
            {
                case b:
                    Advertisement.Banner.Load();
                    Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                    Advertisement.Banner.Show(b);
                    break;
                case i:
                    Advertisement.Load(i,m);

                    IIL=false;
                    break;
                case r:
                    Advertisement.Load(r,m);

                    IRL=false;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// on Unity Ads Show Click
        /// </summary>
        /// <param name="a">Advertisement</param>
        public void OnUnityAdsShowClick(string a)=>throw NIE;

        /// <summary>
        /// on Unity Ads Show Complete
        /// </summary>
        /// <param name="a">Advertisement</param>
        /// <param name="uASCS">Unity Ads Show Completion State</param>
        public void OnUnityAdsShowComplete(string a,UnityAdsShowCompletionState uASCS)
        {
            switch (a)
            {
                case b:
                    if(IBL)
                    {
                        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                        Advertisement.Banner.Show(b);
                    }
                    else
                        Advertisement.Banner.Load(b);
                    break;
                case i:
                    if(!IIL)
                        Advertisement.Load(i,m);

                    if(IIS)
                        G.P();

                    IIS=false;
                    break;
                case r:
                    if(!IRL)
                        Advertisement.Load(r,m);

                    if(IRS && uASCS is UnityAdsShowCompletionState.COMPLETED)
                        G.R();
                    else // if(showCompletionState is UnityAdsShowCompletionState.SKIPPED||showCompletionState is UnityAdsShowCompletionState.UNKNOWN)
                        UnityEngine.Handheld.Vibrate();

                    IRS=false;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// on Unity Ads Show Failure
        /// </summary>
        /// <param name="a">Advertisement</param>
        /// <param name="uASE">Unity Ads Show Error</param>
        /// <param name="f">Failure</param>
        public void OnUnityAdsShowFailure(string a,UnityAdsShowError uASE,string f)
        {
            switch (a)
            {
                case b:
                    if(IBL)
                    {
                        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                        Advertisement.Banner.Show(b);
                    }
                    else
                        Advertisement.Banner.Load(b);
                    break;
                case i:
                    UnityEngine.Handheld.Vibrate();

                    if(!IIL)
                        Advertisement.Load(i,m);

                    if(IIS)
                        G.P();

                    IIS=false;
                    break;
                case r:
                    UnityEngine.Handheld.Vibrate();

                    if(!IRL)
                        Advertisement.Load(r,m);

                    IRS=false;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// on Unity Ads Show Start
        /// </summary>
        /// <param name="a">Advertisement</param>
        public void OnUnityAdsShowStart(string a)
        {
            switch (a)
            {
                case b:
                    Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                    break;
                case i:
                    IIS=true;
                    break;
                case r:
                    IRS=true;
                    break;
                default:
                    break;
            }
        }
    }
}

// Murat Sancak