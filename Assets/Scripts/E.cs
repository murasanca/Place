// Murat Sancak

#if UNITY_EDITOR
using Firebase.Database;
using Firebase.Extensions;
using UnityEditor;
using UnityEngine;

namespace murasanca
{
    public class E : MonoBehaviour // E: Editor.
    {
        private static DatabaseReference // DR: Database Reference.
            pDR,                        // p: Place.
            pVCDR;                     // pVC: Place Value Changed.

        private static int x, y;

        // Murat Sancak

        [MenuItem("Murat Sancak/JSON 2 Desktop", false, 1)]
        private static void JSON2D() // JSON2D: JavaScript Object Notation to Desktop.
        {
            System.Text.StringBuilder s = new("{\n\t\"P\":\"64 64\",\n\t\"Place\":\n\t{\n");

            for (x = 0; 129 > x; ++x)
                for (y = 0; 129 > y; ++y)
                    _ = s.Append(string.Concat("\t\t\"", x, ' ', y, "\":\"1 1 1:.\",\n"));

            System.IO.File.WriteAllText(string.Concat(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop), "/Place 64x64.json"), s.Remove(s.Length - 2, 2).Append(string.Concat("\n\t},\n\t\"Placer\":\n\t{\n\t\t\"Murat Sancak\":\"", System.DateTime.Now, "\"\n\t}\n}")).ToString());
        }

        // Murat Sancak

        [MenuItem("Murat Sancak/Place 2 Zero", false, 1)]
        private static void P2Z() // P2Z: Place to Zero. 
        {
            _ = (pDR = FirebaseDatabase.DefaultInstance.RootReference.Child("Place")).Child("62 62").SetValueAsync("1 .25 0:Murat Sancak"); _ = (pVCDR = FirebaseDatabase.DefaultInstance.RootReference.Child("P")).SetValueAsync("62 62");
            _ = pDR.Child("62 63").SetValueAsync("1 1 1:Murat Sancak"); _ = pVCDR.SetValueAsync("62 63");
            _ = pDR.Child("62 64").SetValueAsync("1 1 1:Murat Sancak"); _ = pVCDR.SetValueAsync("62 64");
            _ = pDR.Child("62 65").SetValueAsync("1 .25 0:Murat Sancak"); _ = pVCDR.SetValueAsync("62 65");
            _ = pDR.Child("62 66").SetValueAsync("1 .25 0:Murat Sancak"); _ = pVCDR.SetValueAsync("62 66");

            _ = pDR.Child("63 62").SetValueAsync("1 1 1:Murat Sancak"); _ = pVCDR.SetValueAsync("63 62");
            _ = pDR.Child("63 63").SetValueAsync("1 1 1:Murat Sancak"); _ = pVCDR.SetValueAsync("63 63");
            _ = pDR.Child("63 64").SetValueAsync("1 1 1:Murat Sancak"); _ = pVCDR.SetValueAsync("63 64");
            _ = pDR.Child("63 65").SetValueAsync("1 1 1:Murat Sancak"); _ = pVCDR.SetValueAsync("63 65");
            _ = pDR.Child("63 66").SetValueAsync("1 .25 0:Murat Sancak"); _ = pVCDR.SetValueAsync("63 66");

            _ = pDR.Child("64 62").SetValueAsync("1 .25 0:Murat Sancak"); _ = pVCDR.SetValueAsync("64 62");
            _ = pDR.Child("64 63").SetValueAsync("1 1 1:Murat Sancak"); _ = pVCDR.SetValueAsync("64 63");
            _ = pDR.Child("64 64").SetValueAsync("0 0 0:Murat Sancak"); _ = pVCDR.SetValueAsync("64 64");
            _ = pDR.Child("64 65").SetValueAsync("1 1 1:Murat Sancak"); _ = pVCDR.SetValueAsync("64 65");
            _ = pDR.Child("64 66").SetValueAsync("1 .25 0:Murat Sancak"); _ = pVCDR.SetValueAsync("64 66");

            _ = pDR.Child("65 62").SetValueAsync("1 1 1:Murat Sancak"); _ = pVCDR.SetValueAsync("65 62");
            _ = pDR.Child("65 63").SetValueAsync("1 1 1:Murat Sancak"); _ = pVCDR.SetValueAsync("65 63");
            _ = pDR.Child("65 64").SetValueAsync("0 0 0:Murat Sancak"); _ = pVCDR.SetValueAsync("65 64");
            _ = pDR.Child("65 65").SetValueAsync("1 1 1:Murat Sancak"); _ = pVCDR.SetValueAsync("65 65");
            _ = pDR.Child("65 66").SetValueAsync("1 .25 0:Murat Sancak"); _ = pVCDR.SetValueAsync("65 66");

            _ = pDR.Child("66 62").SetValueAsync("1 .25 0:Murat Sancak"); _ = pVCDR.SetValueAsync("66 62");
            _ = pDR.Child("66 63").SetValueAsync("1 .25 0:Murat Sancak"); _ = pVCDR.SetValueAsync("66 63");
            _ = pDR.Child("66 64").SetValueAsync("1 .25 0:Murat Sancak"); _ = pVCDR.SetValueAsync("66 64");
            _ = pDR.Child("66 65").SetValueAsync("1 .25 0:Murat Sancak"); _ = pVCDR.SetValueAsync("66 65");
            _ = pDR.Child("66 66").SetValueAsync("1 1 1:Murat Sancak"); _ = pVCDR.SetValueAsync("66 66");
        }

        // Murat Sancak

        [MenuItem("Murat Sancak/Place's Children Count", false, 1)]
        private static void PCC() // PCC: Place's Children Count.
        {
            _ = FirebaseDatabase.DefaultInstance.RootReference.Child("Place").GetValueAsync().ContinueWithOnMainThread
            (
                t // t: Task.
                =>
                {
                    if (t.IsCompleted)
                        Debug.LogWarning(string.Concat("Place's Children Count:\t", t.Result.ChildrenCount));
                }
            );
        }
    }
}
#endif

// Murat Sancak