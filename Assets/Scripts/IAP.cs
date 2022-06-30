// Murat Sancak

using System;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

namespace murasanca
{
    public class IAP : MonoBehaviour, IStoreListener // IAP: In-App Purchase.
    {
        [SerializeField]
        private Button // B: Button (Legacy).
            pB,       // p: Palette.
            sB;      // s: Shield.
        [SerializeField]
        private GameObject // GO: Game Object.
            cGO,          // c: Color.
            mSVGO,       // mSV: Menu Scroll View.
            pGO;        // p: Palette.
        [SerializeField]
        private IAPButton pBL; // pBL: Palette Button (Legacy).
        [SerializeField]
        private Slider // S: Slider.
            bS,       // b: Blue.
            gS,      // g: Green.
            rS;     // r: Red.

        private static IExtensionProvider eP; // eP: Extension Provider.
        private static IStoreController sC; // sC: Store Controller.

        private static Product b; // b: Buy.

        private readonly static string[] pDI = new string[2] // pDI: Products' Definition Id.
        {
            "com.murasanca.place.0", // 0: Advertisement.
            "com.murasanca.place.1" // 1: Palette.
        };

        // Murat Sancak

        public static bool II => eP is not null && sC is not null; // II: Is Initialized.

        // Murat Sancak

        private void Start()
        {
            I();

            pBL.enabled = !HR(1);
            sB.interactable = !HR(0);
        }

        // Murat Sancak

        private void I() => // I: Initialize.
            UnityPurchasing.Initialize
            (
                this,
                ConfigurationBuilder.Instance(StandardPurchasingModule.Instance())
                                    .AddProduct(pDI[0], ProductType.NonConsumable)
                                    .AddProduct(pDI[1], ProductType.NonConsumable)
            );

        private static Product P(string p) => sC.products.WithStoreSpecificID(p); // P: Product, p: Product.

        public static bool HR(int i) => II && P(pDI[i]).hasReceipt; // HR: Has Receipt, i: Index.

        public static void IP(int i) // IP: InitatePurchase, i: Index.
        {
            if (II && (b = P(pDI[i])) is not null && b.availableToPurchase)
                sC.InitiatePurchase(b);
            else
                Handheld.Vibrate();
        }

        // Murat Sancak

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs pEA) // pEA: Purchase Event Args.
        {
            if (string.Equals(pEA.purchasedProduct.definition.id, pDI[0], StringComparison.Ordinal))
            {
                M.H();

                mSVGO.SetActive(false);
            }
            else if (string.Equals(pEA.purchasedProduct.definition.id, pDI[1], StringComparison.Ordinal))
            {
                bS.value = PP.B;
                gS.value = PP.G;
                rS.value = PP.R;

                cGO.SetActive(false);
                pGO.SetActive(true);
            }
            else
                Handheld.Vibrate();

            return PurchaseProcessingResult.Complete;
        }

        public void OnInitialized(IStoreController sC, IExtensionProvider eP) // sC: Store Controller, eP: Extension Provider.
        {
            IAP.eP = eP;
            IAP.sC = sC;

            pB.interactable = sB.interactable = true;
        }

        public void OnInitializeFailed(InitializationFailureReason iFR) => I(); // iFR: Purchase Failure Reason.

        public void OnPurchaseFailed(Product p, PurchaseFailureReason pFR) // p: Product, pFR: Purchase Failure Reason.
        {
            if (string.Equals(p.definition.id, pDI[0], StringComparison.Ordinal))
                mSVGO.SetActive(false);
            else if (string.Equals(p.definition.id, pDI[1], StringComparison.Ordinal))
            {
                cGO.SetActive(true);
                pGO.SetActive(false);
            }

            Handheld.Vibrate();
        }
    }
}

// Murat Sancak