// Murat Sancak

using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

using static PGS; // PGS: Play Games Services.
using static UnityEngine.SystemInfo;

namespace murasanca
{
    /// <summary>
    /// Game
    /// </summary>
    public class G:MonoBehaviour
    {
        /// <summary>
        /// Game Object
        /// </summary>
        [SerializeField]
        private GameObject
            aGO,                  // a: Animation.
            cGO,                 // c: Color.
            fPGO,               // fP: Fancy Panel.
            gPGO,              // gP: Gem Panel.
            gRIGO,            // gRI: Gem Raw Image.
            mSVGO,           // mSV: Menu Scroll View.
            pBGO,           // pB: Paintbrush Button.
            pGO,           // p: Palette.
            pSRIGO,       // pSRI: Place Selection Raw Image.
            pSVGO,       // pSV: Place Scroll View.
            pUIGO,      // pUI: Place User Interface.
            qCBGO,     // qCB: Question Close Button.
            rBGO,     // rB: Reload Button.
            sGO,     // s: Selection.
            tBGO,   // tB: Torch Button.
            tGO,   // t: Timer.
            tSGO; // tS: Torch Slider.
        /// <summary>
        /// Place Content Rect Transform
        /// </summary>
        [SerializeField]
        private RectTransform pCRT; // pCRT: Place Content Rect Transform.
        /// <summary>
        /// Texture 2D
        /// </summary>
        [SerializeField]
        private Texture2D
            pT2D,   // p: Place.
            sCT2D; // sC: Selected Color.
        /// <summary>
        /// Text Mesh Pro UGUI
        /// </summary>
        [SerializeField]
        private TMPro.TextMeshProUGUI
            bHT,         // bH: Blue Handle.
            dNT,        // dN: Display Name.
            gHT,       // gH: Green Handle.
            gT,       // g: Gem.
            pT,      // p: Place.
            rHT,    // rH: Red Handle.
            rT,    // r: Placer.
            tT,   // t: Timer.
            tVT; // tV: Torch Value.
        /// <summary>
        /// Button
        /// </summary>
        [SerializeField]
        private UnityEngine.UI.Button
            cB,          // c: Crystals.
            fCB,        // fC: Fancy Close.
            gB,        // g: Goblet.
            pB,       // p: Paintbrush.
            pCB,     // pC: Paintbrush Close.
            qCB,    // qC: Question Close.
            rB,    // r: Reload.
            sB,   // s: Scroll.
            tPB; // tP: Timer Play.
        /// <summary>
        /// Color Raw Image
        /// </summary>
        [SerializeField]
        private UnityEngine.UI.RawImage cRI; // cRI: Color Raw Image.
        /// <summary>
        /// Place Scroll Rect
        /// </summary>
        [SerializeField]
        private UnityEngine.UI.ScrollRect pSR;
        /// <summary>
        /// Slider
        /// </summary>
        [SerializeField]
        private UnityEngine.UI.Slider
            bS,    // b: Blue.
            gS,   // g: Green.
            rS,  // r: Red.
            tS; // t: Torch.

        /// <summary>
        /// is Zoomable
        /// </summary>
        private bool iZ;
        /// <summary>
        /// Camera
        /// </summary>
        private Camera c;
        /// <summary>
        /// Data Snapshot
        /// </summary>
        private DataSnapshot
            pCDS, // pC: Place Child.
            pDS; // p: Place.
        private float
            b,      // b: Blue.
            cDT,   // cDT: Current Difference of Touches.
            g,    // g: Green.
            pDT, // pDT: Previous Difference of Touches.
            r,  // r: Red.
            z; // z: Zoom.
        private int
            e, // e: Edge.
            x,y;

        /// <summary>
        /// Color 32's
        /// </summary>
        private Color32[]c32;
        private float[]
            rGB=new float[3],   // rGB: Red Green Blue.
            rGBE=new float[3]; // E: Event.
        /// <summary>
        /// Event XY
        /// </summary>
        private int[]eXY=new int[2]{0,0};

        /// <summary>
        /// Wait for Seconds
        /// </summary>
        private readonly WaitForSeconds
            wFS2=new(2.08f),
            wFS7=new(7.28f);

        /// <summary>
        /// Database Reference
        /// </summary>
        private static DatabaseReference
            pDR,    // p: Place.
            pVCDR, // pVC: Place Value Changed.
            rDR;  // r: Placer.
        
        /// <summary>
        /// Selection Color String
        /// </summary>
        private static string sCS="1 1 1";

        private readonly static int[]xY=new int[2]{0,0};

        /// <summary>
        /// Wait for Seconds
        /// </summary>
        public static WaitForSecondsRealtime wFS=new(1);

        // Murat Sancak

        /// <summary>
        /// is Authenticated
        /// </summary>
        private static bool IA=>Social.localUser.authenticated;

        /// <summary>
        /// Id
        /// </summary>
        private static string I
            =>
#if UNITY_EDITOR
            "Murat Sancak";
#else
            Social.localUser.id;
#endif

        /// <summary>
        /// User Name
        /// </summary>
        private static string UN
            =>
#if UNITY_EDITOR
            "Murat Sancak";
#else
            Social.localUser.userName;
#endif

        // Murat Sancak

        private void Awake()
        {
            System.Globalization.CultureInfo.CurrentCulture
            =
            System.Globalization.CultureInfo.CurrentUICulture
            =
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture
            =
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture
            =
            System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
#if UNITY_EDITOR
            (rDR=FirebaseDatabase.DefaultInstance.RootReference.Child("Placer").Child(I)).ValueChanged+=RVC;
#else
            GooglePlayGames.PlayGamesPlatform.InitializeInstance(new GooglePlayGames.BasicApi.PlayGamesClientConfiguration.Builder().Build());
            GooglePlayGames.PlayGamesPlatform.DebugLogEnabled=true;
            _=GooglePlayGames.PlayGamesPlatform.Activate();
            Social.localUser.Authenticate
            (
                iA // iA: is Authenticated.
                =>
                {
                    if(gB.interactable=pB.interactable=sB.interactable=iA)
                    {
                        (Social.Active as GooglePlayGames.PlayGamesPlatform).SetGravityForPopups(GooglePlayGames.BasicApi.Gravity.TOP);

                        _=(rDR=FirebaseDatabase.DefaultInstance.RootReference.Child("Placer").Child(I)).GetValueAsync().ContinueWithOnMainThread
                        (
                            t // t: Task.
                            =>
                            {
                                if (t.Result.Exists&&1>(PP.T=(int)(System.DateTime.Parse(t.Result.Value.ToString())-System.DateTime.Now).TotalSeconds))
                                    PP.D();
                            }
                        );

                        dNT.text=UN;

                        rDR.ValueChanged+=RVC;
                    }
                }
            );
#endif
            (pVCDR=FirebaseDatabase.DefaultInstance.RootReference.Child("P")).ValueChanged+=PVC;
            _=(pDR=FirebaseDatabase.DefaultInstance.RootReference.Child("Place")).GetValueAsync().ContinueWithOnMainThread
            (
                t // t: Task.
                =>
                {
                    if(t.IsCompleted)
                    {
                        e=(int)Mathf.Sqrt((c32=new Color32[(pDS=t.Result).ChildrenCount]).Length);
                        for(y=0;e>y;++y) // B2T.
                            for(x=0;e>x;++x) // L2R.
                                c32[e*y+x]=new Color((rGB=System.Array.ConvertAll(pDS.Child(string.Concat(x,' ',y)).Value.ToString().Split(':')[0].Split(' '),float.Parse))[0],rGB[1],rGB[2]);
                        pT2D.SetPixels32(c32);
                        pT2D.Apply();

                        // rT.text=pDS.Child("64 64").Value.ToString().Split(':')[1];
                    }
                }
            );

            _=StartCoroutine(C());

            c=GetComponent<Camera>();
        }

        private void Start()=>StartCoroutine(S());

        private void Update()
        {
            if(Input.GetKeyUp(KeyCode.Escape))
            {
                if(fPGO.activeSelf)
                {
                    if(rBGO.activeSelf)
                        rB.onClick.Invoke();
                    else if(gPGO.activeSelf)
                        cB.onClick.Invoke();
                    else
                        fCB.onClick.Invoke();
                }
                else // if(!fPGO.activeSelf)
                {
                    if(cGO.activeSelf)
                        pCB.onClick.Invoke();
                    else if(pGO.activeSelf)
                    {
                        cGO.SetActive(true);
                        pGO.SetActive(false);
                    }

                    if(mSVGO.activeSelf)
                        mSVGO.SetActive(false);

                    if(qCBGO.activeSelf)
                        qCB.onClick.Invoke();

                    if(tSGO.activeSelf)
                    {
                        tBGO.SetActive(true);
                        tSGO.SetActive(false);
                    }
                }
            }

            if(Input.touchCount is 2&&iZ)
            {
                PSV();

                z=(Input.GetTouch(0).deltaPosition-Input.GetTouch(1).deltaPosition).magnitude*Time.deltaTime;
                if((cDT=(Input.GetTouch(0).position-Input.GetTouch(1).position).magnitude)<(pDT=(Input.GetTouch(0).position-Input.GetTouch(0).deltaPosition+Input.GetTouch(1).deltaPosition-Input.GetTouch(1).position).magnitude))
                    tS.value-=z;
                else if(cDT>pDT)
                    tS.value+=z;
            }

            pSR.enabled=Input.touchCount is 0or 1;
        }

        // Murat Sancak

        /// <summary>
        /// on Application Focus
        /// </summary>
        /// <param name="f">Focus</param>
        private void OnApplicationFocus(bool f)
        {
            if(f)
            {
                _=pDR.GetValueAsync().ContinueWithOnMainThread
                (
                    t // t: Task.
                    =>
                    {
                        if(t.IsCompleted)
                        {
                            e=(int)Mathf.Sqrt((c32=new Color32[(pDS=t.Result).ChildrenCount]).Length);
                            for(y=0;e>y;++y) // B2T.
                                for(x=0;e>x;++x) // L2R.
                                    c32[e*y+x]=new Color((rGB=System.Array.ConvertAll(pDS.Child(string.Concat(x,' ',y)).Value.ToString().Split(':')[0].Split(' '),float.Parse))[0],rGB[1],rGB[2]);
                            pT2D.SetPixels32(c32);
                            pT2D.Apply();

                            rT.text=string.Concat(pDS.Child(string.Concat(64+xY[0],' ',64+xY[1])).Value.ToString().Split(':')[1]);
                        }
                    }
                );

                _=rDR.GetValueAsync().ContinueWithOnMainThread
                (
                    t // t: Task.
                    =>
                    {
                        if(t.IsCompleted&&(PP.T=(int)(System.DateTime.Parse(t.Result.Value.ToString())-System.DateTime.Now).TotalSeconds)<1)
                            PP.T=0;
                    }
                );
            }
        }

        // Murat Sancak

        /// <summary>
        /// Countdown
        /// </summary>
        /// <returns>Wait for Seconds</returns>
        private System.Collections.IEnumerator C()
        {
            while(true)
            {
                if(0<PP.T)
                {
                    pB.interactable=false;

                    if(pBGO.activeSelf||tGO.activeSelf)
                    {
                        pBGO.SetActive(false);
                        tGO.SetActive(true);

                        tPB.interactable=119<PP.T&&M.IRL;
                        tT.text=60>PP.T?string.Concat(0,'.',PP.T):string.Concat(PP.T/60,'.',PP.T%60);
                    }
                    --PP.T;
                }
                else if(tGO.activeSelf)
                {
                    _=rDR.GetValueAsync().ContinueWithOnMainThread
                    (
                        t // t: Task.
                        =>
                        {
                            if(t.Result.Exists&&1>(PP.T=(int)(System.DateTime.Parse(t.Result.Value.ToString())-System.DateTime.Now).TotalSeconds))
                            {
                                PP.D();

                                pB.interactable=IA;
                            }
                        }
                    );

                    pBGO.SetActive(true);
                    tGO.SetActive(false);
                }

                yield return wFS;
            }
        }

        /// <summary>
        /// Start
        /// </summary>
        /// <returns>Wait for Seconds</returns>
        private System.Collections.IEnumerator S()
        {
            yield return wFS7;

            Destroy(aGO);

            pSRIGO.SetActive(true);
            pSVGO.SetActive(true);

            yield return wFS2;

            Destroy(GetComponent<Animator>());
            
            pUIGO.SetActive(iZ=true);
        }

        // Murat Sancak

        /// <summary>
        /// Report Progress
        /// </summary>
        /// <param name="a">Achievement</param>
        private static void RP(int a)
        {
            if(IA)
                switch(a) // s: Success.
                {
                    case -1:
                        Social.ReportProgress(achievement_question,100,s=>{});
                        break;
                    case 1:
                        Social.ReportProgress(achievement_1,100,s=>{});
                        break;
                    case 2:
                        Social.ReportProgress(achievement_2,100,s=>{});
                        break;
                    case 3:
                        Social.ReportProgress(achievement_3,100,s=>{});
                        break;
                    case 4:
                        Social.ReportProgress(achievement_4,100,s=>{});
                        break;
                    case 5:
                        Social.ReportProgress(achievement_5,100,s=>{});
                        break;
                    case 6:
                        Social.ReportProgress(achievement_6,100,s=>{});
                        break;
                    case 7:
                        Social.ReportProgress(achievement_7,100,s=>{});
                        break;
                    case 8:
                        Social.ReportProgress(achievement_8,100,s=>{});
                        break;
                    case 9:
                        Social.ReportProgress(achievement_9,100,s=>{});
                        break;
                    case 10:
                        Social.ReportProgress(achievement_10,100,s=>{});
                        break;
                    case 16:
                        Social.ReportProgress(achievement_16,100,s=>{});
                        break;
                    default:
                        break;
                }
        }

        /// <summary>
        /// Color
        /// </summary>
        /// <param name="c">Color</param>
        public void C(GameObject c)
        {
            sCS=c.name;

            sGO.transform.position=c.transform.position;
        }

        /// <summary>
        /// Close Button
        /// </summary>
        public void CB()
            =>
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying=false;
#else
            Application.Quit();
#endif

        /// <summary>
        /// Goblet Button
        /// </summary>
        public void GB()=>Social.ShowLeaderboardUI();

        /// <summary>
        /// Mail to Button
        /// </summary>
        public void M2B()=>Application.OpenURL
        (
            string.Concat
            (
                "mailto:murasanca@pm.me?subject=Place&body=%0A%0A%0A%0A%0AStatic Properties%0A%0A%0ABattery Level: ",batteryLevel,
                "%0ABattery Status: ",batteryStatus,

                "%0A%0AConstant Buffer Offset Alignment: ",constantBufferOffsetAlignment,

                "%0A%0ACopy Texture Support: ",copyTextureSupport,

                "%0A%0ADevice Model: ",deviceModel,
                "%0ADevice Name: ",deviceName,
                "%0ADevice Type: ",deviceType,
                "%0ADevice Unique Identifier: ",deviceUniqueIdentifier,

                "%0A%0AGraphics Device ID: ",graphicsDeviceID,
                "%0AGraphics Device Name: ",graphicsDeviceName,
                "%0AGraphics Device Type: ",graphicsDeviceType,
                "%0AGraphics Device Vendor: ",graphicsDeviceVendor,
                "%0AGraphics Device Vendor ID: ",graphicsDeviceVendorID,
                "%0AGraphics Device Version: ",graphicsDeviceVersion,
                "%0AGraphics Memory Size: ",graphicsMemorySize,
                "%0AGraphics Multi Threaded: ",graphicsMultiThreaded,
                "%0AGraphics Shader Level: ",graphicsShaderLevel,
                "%0AGraphics UV Starts At Top: ",graphicsUVStartsAtTop,

                "%0A%0AHas Dynamic Uniform Array Indexing In Fragment Shaders: ",hasDynamicUniformArrayIndexingInFragmentShaders,
                "%0AHas Hidden Surface Removal On GPU: ",hasHiddenSurfaceRemovalOnGPU,
                "%0AHas Mip Max Level: ",hasMipMaxLevel,

                "%0A%0AHDR Display Support Flags: ",hdrDisplaySupportFlags,

                "%0A%0AMax Compute Buffer Inputs Compute: ",maxComputeBufferInputsCompute,
                "%0AMax Compute Buffer Inputs Domain: ",maxComputeBufferInputsDomain,
                "%0AMax Compute Buffer Inputs Fragment: ",maxComputeBufferInputsFragment,
                "%0AMax Compute Buffer Inputs Geometry: ",maxComputeBufferInputsGeometry,
                "%0AMax Compute Buffer Inputs Hull: ",maxComputeBufferInputsHull,
                "%0AMax Compute Buffer Inputs Vertex: ",maxComputeBufferInputsVertex,
                "%0AMax Compute Work Group Size: ",maxComputeWorkGroupSize,
                "%0AMax Compute Work Group Size X: ",maxComputeWorkGroupSizeX,
                "%0AMax Compute Work Group Size Y: ",maxComputeWorkGroupSizeY,
                "%0AMax Compute Work Group Size Z: ",maxComputeWorkGroupSizeZ,
                "%0AMax Cubemap Size: ",maxCubemapSize,
                "%0AMax Texture Size: ",maxTextureSize,

                "%0A%0ANPOT Support: ",npotSupport,

                "%0A%0AOperating System: ",operatingSystem,
                "%0AOperating System Family: ",operatingSystemFamily,

                "%0A%0AProcessor Count: ",processorCount,
                "%0AProcessor Frequency: ",processorFrequency,
                "%0AProcessor Type: ",processorType,

                "%0A%0ARendering Threading Mode: ",renderingThreadingMode,

                "%0A%0ASupported Random Write Target Count: ",supportedRandomWriteTargetCount,
                "%0ASupported Render Target Count: ",supportedRenderTargetCount,

                "%0A%0ASupports 2D Array Textures: ",supports2DArrayTextures,
                "%0ASupports 32 Bits Index Buffer: ",supports32bitsIndexBuffer,
                "%0ASupports 3D Render Textures: ",supports3DRenderTextures,
                "%0ASupports 3D Textures: ",supports3DTextures,
                "%0ASupports Accelerometer: ",supportsAccelerometer,
                "%0ASupports Async Compute: ",supportsAsyncCompute,
                "%0ASupports Async GPU Readback: ",supportsAsyncGPUReadback,
                "%0ASupports Audio: ",supportsAudio,
                "%0ASupports Compressed 3D Textures: ",supportsCompressed3DTextures,
                "%0ASupports Compute Shaders: ",supportsComputeShaders,
                "%0ASupports Conservative Raster: ",supportsConservativeRaster,
                "%0ASupports Cubemap Array Textures: ",supportsCubemapArrayTextures,
                "%0ASupports Geometry Shaders: ",supportsGeometryShaders,
                "%0ASupports GPU Recorder: ",supportsGpuRecorder,
                "%0ASupports Graphics Fence: ",supportsGraphicsFence,
                "%0ASupports Gyroscope: ",supportsGyroscope,
                "%0ASupports Hardware Quad Topology: ",supportsHardwareQuadTopology,
                "%0ASupports Instancing: ",supportsInstancing,
                "%0ASupports Location Service: ",supportsLocationService,
                "%0ASupports Mip Streaming: ",supportsMipStreaming,
                "%0ASupports Motion Vectors: ",supportsMotionVectors,
                "%0ASupports Multisample Auto Resolve: ",supportsMultisampleAutoResolve,
                "%0ASupports Multisampled 2D Array Textures: ",supportsMultisampled2DArrayTextures,
                "%0ASupports Multisampled Textures: ",supportsMultisampledTextures,
                "%0ASupports Multiview: ",supportsMultiview,
                "%0ASupports Raw Shadow Depth Sampling: ",supportsRawShadowDepthSampling,
                "%0ASupports Ray Tracing: ",supportsRayTracing,
                "%0ASupports Render Target Array Index From Vertex Shader: ",supportsRenderTargetArrayIndexFromVertexShader,
                "%0ASupports Separated Render Targets Blend: ",supportsSeparatedRenderTargetsBlend,
                "%0ASupports Set Constant Buffer: ",supportsSetConstantBuffer,
                "%0ASupports Shadows: ",supportsShadows,
                "%0ASupports Sparse Textures: ",supportsSparseTextures,
                "%0ASupports Store And Resolve Action: ",supportsStoreAndResolveAction,
                "%0ASupports Tessellation Shaders: ",supportsTessellationShaders,
                "%0ASupports Texture Wrap Mirror Once: ",supportsTextureWrapMirrorOnce,
                "%0ASupports Vibration: ",supportsVibration,

                "%0A%0ASystem Memory Size: ",systemMemorySize,

                "%0A%0AUnsupported Identifier: ",unsupportedIdentifier,

                "%0A%0AUses Load Store Actions: ",usesLoadStoreActions,
                "%0AUses Reversed Z Buffer: ",usesReversedZBuffer,

                "%0A%0A%0A"
            )
        );

        /// <summary>
        /// Menu Button
        /// </summary>
        public void MB()=>mSVGO.SetActive(!mSVGO.activeSelf);

        /// <summary>
        /// Murat Sancak
        /// </summary>
        public void MS()=>Application.OpenURL("https://murasanca.blogspot.com/");

        /// <summary>
        /// Palette Button
        /// </summary>
        public void PB()
        {
            if(IAP.HR(1)) // 1: Palette.
            {
                bS.value=PP.B;
                gS.value=PP.G;
                rS.value=PP.R;

                cGO.SetActive(false);
                pGO.SetActive(true);
            }
            else
                IAP.IP(1); // 1: Palette.
        }

        /// <summary>
        /// Placer Text
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        public void PT(int x,int y)
        {
            c.transform.position=new Vector2(pCRT.anchoredPosition.x+x,pCRT.anchoredPosition.y+y);

            cRI.color=pT2D.GetPixel(64+xY[0],64+xY[1]);
            gT.text=string.Concat(xY[0].ToString("00"),'\n',xY[1].ToString("00"));

            if(tSGO.activeSelf)
            {
                tBGO.SetActive(true);
                tSGO.SetActive(false);
            }

            pT.text=string.Concat('(',x,',',y,')');

            rT.text=pDS.Child(string.Concat(64+x,' ',64+y)).Value.ToString().Split(':')[1];

            xY[0]=x;
            xY[1]=y;
        }

        /// <summary>
        /// Question Button
        /// </summary>
        public void QB()=>RP(-1);

        /// <summary>
        /// Question Place Button
        /// </summary>
        public void QPB()=>Application.OpenURL("https://murasanca.blogspot.com/PrivacyPolicyPlace");

        /// <summary>
        /// Reload Button
        /// </summary>
        public void RB()=>gPGO.SetActive(gRIGO.activeSelf);

        /// <summary>
        /// Scroll Button
        /// </summary>
        public void S0B()=>Social.ShowAchievementsUI();

        /// <summary>
        /// Star Button
        /// </summary>
        public void SB()=>Application.OpenURL("market://details?id=com.murasanca.Place");

        /// <summary>
        /// Shield Button (Legacy)
        /// </summary>
        public void SBL()=>IAP.IP(0);

        /// <summary>
        /// Place
        /// </summary>
        public static void P()
        {
            _=pDR.Child(string.Concat(64+xY[0],' ',64+xY[1])).SetValueAsync(string.Concat(sCS,':',UN));
            _=pVCDR.SetValueAsync(string.Concat(64+xY[0],' ',64+xY[1]));
            _=rDR.SetValueAsync(System.DateTime.Now.AddSeconds(PP.T=600).ToString());

            if(IA)
            {
                Social.ReportScore(0,leaderboard_place,s=>{});
                GooglePlayGames.PlayGamesPlatform.Instance.LoadScores
                (
                    leaderboard_place,
                    GooglePlayGames.BasicApi.LeaderboardStart.PlayerCentered,
                    1,
                    GooglePlayGames.BasicApi.LeaderboardCollection.Public,
                    GooglePlayGames.BasicApi.LeaderboardTimeSpan.AllTime,
                    (lSD)=>Social.ReportScore(++lSD.PlayerScore.value,leaderboard_place,s=>RP((int)lSD.PlayerScore.value)) // lSD: Leaderboard Score Data, s: Success.
                );
            }
        }

        /// <summary>
        /// Reward
        /// </summary>
        public static void R()=>rDR.GetValueAsync().ContinueWithOnMainThread
        (
            t // t: Task.
            =>
            {
                if(t.IsCompleted)
                {
                    if(1>(PP.T=(int)(System.DateTime.Parse(t.Result.Value.ToString()).AddSeconds(-60)-System.DateTime.Now).TotalSeconds))
                        PP.T=0;
                    _=rDR.SetValueAsync(System.DateTime.Now.AddSeconds(PP.T).ToString());
                }
            }
        );

        // Murat Sancak

        /// <summary>
        /// Blue Slider (on Value Changed)
        /// </summary>
        /// <param name="v">Value</param>
        public void BS(float v)
        {
            bHT.text=(PP.B=(int)v).ToString();

            sCS=string.Concat(r,' ',g,' ',b=v/255);

            sCT2D.SetPixel(0,0,new Color(r,g,b));
            sCT2D.Apply();
        }
        /// <summary>
        /// Green Slider (on Slider Changed)
        /// </summary>
        /// <param name="v">Value</param>
        public void GS(float v)
        {
            gHT.text=(PP.G=(int)v).ToString();

            sCS=string.Concat(r,' ',g=v/255,' ',b);

            sCT2D.SetPixel(0,0,new Color(r,g,b));
            sCT2D.Apply();
        }
        /// <summary>
        /// Red Slider (on Value Changed)
        /// </summary>
        /// <param name="v">Value</param>
        public void RS(float v)
        {
            rHT.text=(PP.R=(int)v).ToString();

            sCS=string.Concat(r=v/255,' ',g,' ',b);

            sCT2D.SetPixel(0,0,new Color(r,g,b));
            sCT2D.Apply();
        }

        /// <summary>
        /// P Value Changed
        /// </summary>
        /// <param name="o">Object</param>
        /// <param name="vCEA">Value Changed Event Args</param>
        private void PVC(object o,ValueChangedEventArgs vCEA)
        {
            if(vCEA.DatabaseError is null)
                _=pDR.Child(vCEA.Snapshot.Value.ToString()).GetValueAsync().ContinueWithOnMainThread
                (
                    t // t: Task.
                    =>
                    {
                        if(t.IsCompleted)
                        {
                            _=pDR.GetValueAsync().ContinueWithOnMainThread
                            (
                                t // t: Task.
                                =>
                                {
                                    if(t.IsCompleted)
                                        pDS=t.Result;
                                }
                            );

                            pT2D.SetPixel((eXY=System.Array.ConvertAll((pCDS=t.Result).Key.Split(' '),int.Parse))[0],eXY[1],new Color((rGBE=System.Array.ConvertAll(pCDS.Value.ToString().Split(':')[0].Split(' '),float.Parse))[0],rGBE[1],rGBE[2]));
                            pT2D.Apply();
                            rT.text=64+xY[0]==eXY[0]&&64+xY[1]==eXY[1]
                                ?pCDS.Value.ToString().Split(':')[1]
                                :pDS.Child(string.Concat(64+xY[0],' ',64+xY[1])).Value.ToString().Split(':')[1];
                        }
                    }
                );
            else
                Debug.LogError(vCEA.DatabaseError.Message);
        }

        /// <summary>
        /// Placer Value Changed
        /// </summary>
        /// <param name="o">Object</param>
        /// <param name="vCEA">Value Changed Event Args</param>
        private void RVC(object o,ValueChangedEventArgs vCEA)
        {
            if(vCEA.DatabaseError is null)
                _=rDR.GetValueAsync().ContinueWithOnMainThread
                (
                    t // t: Task.
                    =>
                    {
                        if(t.IsCompleted&&1>(PP.T=(int)(System.DateTime.Parse(t.Result.Value.ToString())-System.DateTime.Now).TotalSeconds))
                            PP.T=0;
                        N.USN();
                    }
                );
            else
                Debug.LogError(vCEA.DatabaseError.Message);
        }

        /// <summary>
        /// Place Scroll View (on Value Changed)
        /// </summary>
        public void PSV()=>PT((int)(c.transform.position.x-(pCRT.anchoredPosition=new Vector2Int((int)Mathf.Clamp(pCRT.anchoredPosition.x,-64,64),(int)Mathf.Clamp(pCRT.anchoredPosition.y,-64,64))).x),(int)(c.transform.position.y-pCRT.anchoredPosition.y));

        /// <summary>
        /// Torch Slider (on Value Changed)
        /// </summary>
        public void TS()=>tVT.text=((int)(c.orthographicSize=Mathf.Abs(tS.value))).ToString();
    }
}

// Murat Sancak