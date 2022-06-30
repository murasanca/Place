// Murat Sancak

using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

namespace murasanca
{
    public class M : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener // M: Monetization.
    {
#if UNITY_IOS
        private const string const
            b = "banner",           // b: Banner.
            g = "4767645",         // g: Game.
            i = "video",          // i: Interstitial.
            r = "rewardedVideo"; // r: Rewarded.
#else // UNITY_ANDROID
        private const string
            b = "banner",           // b: Banner.
            g = "4767644",         // g: Game.
            i = "video",          // i: Interstitial.
            r = "rewardedVideo"; // r: Rewarded.
#endif

        [SerializeField]
        private GameObject pUIGO; // pUIGO: Place User Interface Game Object.

        private const bool t = true; // t: Test.

        private readonly System.NotImplementedException NIE = new(); // NIE: Not Implemented Exception.
        private readonly WaitForSeconds wFS = new(1); // wFS: Wait For Seconds.

        private static RectTransform pUIRT; // pUIRT: Place User Interface Rect Transform.

        public static M m; // m: Monetization.

        // Murat Sancak

        public static bool IBL => Advertisement.Banner.isLoaded; // IBR: Is Banner Loaded.
        public static bool II => Advertisement.isInitialized; // II: Is Initialized.

        public static bool IIL { get; private set; } = false; // IIL: Is Interstitial Loaded.
        public static bool IIS { get; private set; } = false; // IIS: Is Interstitial Showing.

        public static bool IRL { get; private set; } = false; // IRL: Is Rewarded Loaded.
        public static bool IRS { get; private set; } = false; // IRS: Is Rewarded Showing.

        // Murat Sancak

        private void Awake()
        {
            m = this;

            pUIRT = pUIGO.GetComponent<RectTransform>();
        }

        private void Start() => StartCoroutine(S());

        // Murat Sancak

        private IEnumerator S() // S: Start.
        {
            while (true)
            {
                if(IAP.HR(0))
                {
                    H();

                    StopCoroutine(S());
                }
                else if (II)
                {
                    if (!IBL)
                        Advertisement.Banner.Load(b);
                    else
                    {
                        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                        Advertisement.Banner.Show(b);
                    }

                    if (!IIL)
                        Advertisement.Load(i, m);

                    if (!IRL)
                        Advertisement.Load(r, m);
                }
                else
                    Advertisement.Initialize(g, t, m);

                yield return wFS;
            }
        }

        // Murat Sancak

        public void I() // I: Interstitial.
        {
            if (IAP.HR(0) || !IIL)
                G.P();
            else
                Advertisement.Show(i, m);
        }

        public void R() // R: Rewarded.
        {
            if (IAP.HR(0))
                G.R();
            else if (IRL)
                Advertisement.Show(r, m);
        }

        public static void H() // H: Hide.
        {
            Advertisement.Banner.Hide();

            pUIRT.offsetMax = Vector2Int.zero;
        }

        // Murat Sancak

        public void OnInitializationComplete()
        {
            if (IBL)
            {
                Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                Advertisement.Banner.Show(b);
            }
            else
                Advertisement.Banner.Load(b);
        }

        public void OnInitializationFailed(UnityAdsInitializationError uAIE, string f) => Advertisement.Initialize(g, t, m); // uAIE: Unity Ads Initialization Error, f: Failure.

        public void OnUnityAdsAdLoaded(string a) // a: Advertisement.
        {
            switch (a)
            {
                case b:
                    Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                    Advertisement.Banner.Show(b);
                    break;
                case i:
                    IIL = true;
                    break;
                case r:
                    IRL = true;
                    break;
                default:
                    break;
            }
        }

        public void OnUnityAdsFailedToLoad(string a, UnityAdsLoadError uALE, string f) // a: Advertisement, uALE: Unity Ads Load Error, f: Failure.
        {
            switch (a)
            {
                case b:
                    Advertisement.Banner.Load();
                    Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                    Advertisement.Banner.Show(b);
                    break;
                case i:
                    Advertisement.Load(i, m);

                    IIL = false;
                    break;
                case r:
                    Advertisement.Load(r, m);

                    IRL = false;
                    break;
                default:
                    break;
            }
        }

        public void OnUnityAdsShowClick(string a) => throw NIE; // a: Advertisement.

        public void OnUnityAdsShowComplete(string a, UnityAdsShowCompletionState uASCS) // a: Advertisement, uASCS: Unity Ads Show Completion State.
        {
            switch (a)
            {
                case b:
                    if (IBL)
                    {
                        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                        Advertisement.Banner.Show(b);
                    }
                    else
                        Advertisement.Banner.Load(b);
                    break;
                case i:
                    if (!IIL)
                        Advertisement.Load(i, m);

                    if (IIS)
                        G.P();

                    IIS = false;
                    break;
                case r:
                    if (!IRL)
                        Advertisement.Load(r, m);

                    if (IRS && uASCS is UnityAdsShowCompletionState.COMPLETED)
                        G.R();
                    else // if(showCompletionState is UnityAdsShowCompletionState.SKIPPED||showCompletionState is UnityAdsShowCompletionState.UNKNOWN)
                        Handheld.Vibrate();

                    IRS = false;
                    break;
                default:
                    break;
            }
        }

        public void OnUnityAdsShowFailure(string a, UnityAdsShowError uASE, string f) // a: Advertisement, uASE: Unity Ads Show Error, f: Failure.
        {
            switch (a)
            {
                case b:
                    if (IBL)
                    {
                        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                        Advertisement.Banner.Show(b);
                    }
                    else
                        Advertisement.Banner.Load(b);
                    break;
                case i:
                    Handheld.Vibrate();

                    if (!IIL)
                        Advertisement.Load(i, m);

                    if (IIS)
                        G.P();

                    IIS = false;
                    break;
                case r:
                    Handheld.Vibrate();

                    if (!IRL)
                        Advertisement.Load(r, m);

                    IRS = false;
                    break;
                default:
                    break;
            }
        }

        public void OnUnityAdsShowStart(string a) // a: Advertisement.
        {
            switch (a)
            {
                case b:
                    Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
                    break;
                case i:
                    IIS = true;
                    break;
                case r:
                    IRS = true;
                    break;
                default:
                    break;
            }
        }
    }
}

// Murat Sancak