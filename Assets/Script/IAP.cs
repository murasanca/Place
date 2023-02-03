// Murat Sancak

using UnityEngine.Purchasing;

namespace murasanca
{
    /// <summary>
    /// In-App Purchase
    /// </summary>
    public class IAP:UnityEngine.MonoBehaviour,IStoreListener
    {
        /// <summary>
        /// Palette Button (Legacy)
        /// </summary>
        [UnityEngine.SerializeField]
        private IAPButton pBL;
        /// <summary>
        /// Game Object
        /// </summary>
        [UnityEngine.SerializeField]
        private UnityEngine.GameObject
            cGO,    // c: Color.
            mSVGO, // mSV: Menu Scroll View.
            pGO;  // p: Palette.
        /// <summary>
        /// Button (Legacy)
        /// </summary>
        [UnityEngine.SerializeField]
        private UnityEngine.UI.Button
            pB,  // p: Palette.
            sB; // s: Shield.
        /// <summary>
        /// Slider
        /// </summary>
        [UnityEngine.SerializeField]
        private UnityEngine.UI.Slider
            bS,   // b: Blue.
            gS,  // g: Green.
            rS; // r: Red.

        /// <summary>
        /// Extension Provider
        /// </summary>
        private static IExtensionProvider eP;
        /// <summary>
        /// Store Controller
        /// </summary>
        private static IStoreController sC;

        /// <summary>
        /// Buy
        /// </summary>
        private static Product b;

        /// <summary>
        /// Products' Definition Id
        /// </summary>
        private readonly static string[]pDI=new string[2]
        {
            "com.murasanca.place.0", // 0: Advertisement.
            "com.murasanca.place.1" // 1: Palette.
        };

        // Murat Sancak

        /// <summary>
        /// is Initialized
        /// </summary>
        public static bool II=>eP is not null&&sC is not null;

        // Murat Sancak

        private void Start()
        {
            I();

            pBL.enabled=!HR(1);
            sB.interactable=!HR(0);
        }

        // Murat Sancak

        /// <summary>
        /// Initialize
        /// </summary>
        private void I()
            =>
            UnityPurchasing.Initialize
            (
                this,
                ConfigurationBuilder.Instance(StandardPurchasingModule.Instance())
                                    .AddProduct(pDI[0],ProductType.NonConsumable)
                                    .AddProduct(pDI[1],ProductType.NonConsumable)
            );

        /// <summary>
        /// Product
        /// </summary>
        /// <param name="p">Product</param>
        /// <returns></returns>
        private static Product P(string p)=>sC.products.WithStoreSpecificID(p);

        /// <summary>
        /// Has Receipt
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns></returns>
        public static bool HR(int i)=>II&&P(pDI[i]).hasReceipt;

        /// <summary>
        /// Initate Purchase
        /// </summary>
        /// <param name="i">Index</param>
        public static void IP(int i)
        {
            if (II&&(b=P(pDI[i]))is not null&&b.availableToPurchase)
                sC.InitiatePurchase(b);
            else
                UnityEngine.Handheld.Vibrate();
        }

        // Murat Sancak

        /// <summary>
        /// Process Purchase
        /// </summary>
        /// <param name="pEA">Purchase Event Args</param>
        /// <returns></returns>
        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs pEA)
        {
            if(string.Equals(pEA.purchasedProduct.definition.id,pDI[0],System.StringComparison.Ordinal))
            {
                M.H();

                mSVGO.SetActive(false);
            }
            else if(string.Equals(pEA.purchasedProduct.definition.id,pDI[1],System.StringComparison.Ordinal))
            {
                bS.value=PP.B;
                gS.value=PP.G;
                rS.value=PP.R;

                cGO.SetActive(false);
                pGO.SetActive(true);
            }
            else
                UnityEngine.Handheld.Vibrate();

            return PurchaseProcessingResult.Complete;
        }

        /// <summary>
        /// on Initialized
        /// </summary>
        /// <param name="sC">Store Controller</param>
        /// <param name="eP">Extension Provider</param>
        public void OnInitialized(IStoreController sC,IExtensionProvider eP)
        {
            IAP.eP=eP;
            IAP.sC=sC;

            pB.interactable=sB.interactable=true;
        }

        /// <summary>
        /// on Initialize Failed
        /// </summary>
        /// <param name="iFR">Initialization Failure Reason</param>
        public void OnInitializeFailed(InitializationFailureReason iFR)=>I();

        /// <summary>
        /// on Purchase Failed
        /// </summary>
        /// <param name="p">Product</param>
        /// <param name="pFR">Purchase Failure Reason</param>
        public void OnPurchaseFailed(Product p,PurchaseFailureReason pFR)
        {
            if(string.Equals(p.definition.id,pDI[0],System.StringComparison.Ordinal))
                mSVGO.SetActive(false);
            else if(string.Equals(p.definition.id,pDI[1],System.StringComparison.Ordinal))
            {
                cGO.SetActive(true);
                pGO.SetActive(false);
            }

            UnityEngine.Handheld.Vibrate();
        }
    }
}

// Murat Sancak