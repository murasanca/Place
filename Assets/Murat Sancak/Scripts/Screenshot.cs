// Murat Sancak

#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

namespace murasanca
{
    public class Screenshot : EditorWindow
    {
        private bool
            l = true, // l: Left.
            r = false; // r: Right.

        private GameObject c; // c: Camera.

        private GUIContent m; // m: murasanca.

        private int pu; // pu: Pop-up.

        private string
            e = "",   // e: Extension.
            n = "",  // n: Name.
            p = ""; // p: Path.

        private readonly string[] o = new string[3] { "Data", "Desktop", "Other" }; // o: Options.

        private static EditorWindow eW; // eW: Editor Window.

        private static Vector2Int
            h = new(256, 128),  // h: Horizontal.
            v = new(256, 512); // v: Vertical.

        // Murat Sancak

        [MenuItem("Murat Sancak/Screenshot", false, 0)]
        private static void S() // S: Screenshot.
        {
            eW = GetWindow<Screenshot>(true, "Screenshot by Murat Sancak", true);
            eW.maxSize = eW.minSize = h;
            eW.position = Rect.zero;
            eW.Show();
        }

        // Murat Sancak

        private void Awake() => m = new GUIContent("Screenshot by Murat Sancak", AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Murat Sancak/Sprites/Murat Sancak.png"));

        private void OnGUI()
        {
            // Camera Label Field.
            EditorGUI.LabelField(new Rect(8, 8, position.width - 16, 16), "Camera", EditorStyles.centeredGreyMiniLabel);
            // Camera Object Field.
            if
            (
                (
                    c = c
                        ? EditorGUI.ObjectField(new Rect(8, 32, position.width - 16, 16), c, typeof(GameObject), true) as GameObject
                        : EditorGUI.ObjectField(new Rect(8, 32, position.width - 16, 16), Camera.main.gameObject, typeof(GameObject), true) as GameObject
                )
                is not null
                &&
                c.TryGetComponent(out Camera _)
            )
            {
                maxSize = minSize = v;

                // Path Label Field.
                EditorGUI.LabelField(new Rect(8, 56, position.width - 16, 16), "Path", EditorStyles.centeredGreyMiniLabel);
                // Path Popup
                switch (pu = EditorGUI.Popup(new Rect(8, 80, position.width - 16, 16), pu, o, EditorStyles.popup))
                {
                    case 0:
                        p = "Assets/Murat Sancak";
                        break;
                    case 1:
                        p = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
                        break;
                    case 2:
                        // Path Text Field.
                        p = p is ""
                            ? EditorGUI.TextArea(new Rect(8, 104, position.width - 16, 32), string.Concat(Application.dataPath, "/Murat Sancak"), EditorStyles.textArea)
                            : EditorGUI.TextArea(new Rect(8, 104, position.width - 16, 32), p, EditorStyles.textArea);
                        break;
                    default:
                        break;
                }

                if (pu is 2)
                {
                    // Name Label Field.
                    EditorGUI.LabelField(new Rect(8, 144, position.width - 16, 16), "Name", EditorStyles.centeredGreyMiniLabel);
                    // Name Text Field.
                    n = n is ""
                        ? EditorGUI.TextArea(new Rect(8, 168, position.width - 16, 16), "Screenshot", EditorStyles.textArea)
                        : EditorGUI.TextArea(new Rect(8, 168, position.width - 16, 16), n, EditorStyles.textArea);

                    // Extension Label Field.
                    EditorGUI.LabelField(new Rect(8, 192, position.width - 16, 16), "Extension", EditorStyles.centeredGreyMiniLabel);
                    // Extension Text Field.
                    e = e is ""
                        ? EditorGUI.TextArea(new Rect(8, 216, position.width - 16, 16), "png", EditorStyles.textArea)
                        : EditorGUI.TextArea(new Rect(8, 216, position.width - 16, 16), e, EditorStyles.textArea);

                    // Eyes Label Field.
                    EditorGUI.LabelField(new Rect(8, 240, position.width - 16, 16), "Eyes", EditorStyles.centeredGreyMiniLabel);
                    // Left Toggle.
                    l = EditorGUI.ToggleLeft(new Rect(8, 264, position.width / 2 - 16, 16), "Left", l, EditorStyles.centeredGreyMiniLabel);
                    // Right Toggle.
                    r = EditorGUI.ToggleLeft(new Rect(position.width / 2 + 8, 264, position.width / 2 - 16, 16), "Right", r, EditorStyles.centeredGreyMiniLabel);

                    // Resolution Label Field
                    EditorGUI.LabelField(new Rect(8, 288, position.width - 16, 16), "Resolution", EditorStyles.centeredGreyMiniLabel);
                    // X Label Field.
                    EditorGUI.LabelField(new Rect(8, 312, position.width / 2 - 16, 16), string.Concat("X:\t", c.GetComponent<Camera>().pixelWidth), EditorStyles.centeredGreyMiniLabel);
                    // Y Label Field.
                    EditorGUI.LabelField(new Rect(position.width / 2 + 8, 312, position.width / 2 - 16, 16), string.Concat("Y:\t", c.GetComponent<Camera>().pixelHeight), EditorStyles.centeredGreyMiniLabel);

                    // Screenshot Label Field.
                    EditorGUI.LabelField(new Rect(8, 336, position.width - 16, 16), "Screenshot", EditorStyles.centeredGreyMiniLabel);
                    // File Label Field.
                    EditorGUI.LabelField(new Rect(8, 360, position.width - 16, 32), R('/', string.Concat(p, '/', n, '.', e)), EditorStyles.wordWrappedMiniLabel);
                }
                else // popup is 0 or 1.
                {
                    // Name Label Field.
                    EditorGUI.LabelField(new Rect(8, 104, position.width - 16, 16), "Name", EditorStyles.centeredGreyMiniLabel);
                    // Name Text Field.
                    n = n is ""
                        ? EditorGUI.TextArea(new Rect(8, 128, position.width - 16, 16), "Screenshot", EditorStyles.textArea)
                        : EditorGUI.TextArea(new Rect(8, 128, position.width - 16, 16), n, EditorStyles.textArea);

                    // Extension Label Field.
                    EditorGUI.LabelField(new Rect(8, 152, position.width - 16, 16), "Extension", EditorStyles.centeredGreyMiniLabel);
                    // Extension Text Field.
                    e = e is ""
                        ? EditorGUI.TextArea(new Rect(8, 176, position.width - 16, 16), "png", EditorStyles.textArea)
                        : EditorGUI.TextArea(new Rect(8, 176, position.width - 16, 16), e, EditorStyles.textArea);

                    // Eyes Label Field.
                    EditorGUI.LabelField(new Rect(8, 200, position.width - 16, 16), "Eyes", EditorStyles.centeredGreyMiniLabel);
                    // Left Toggle.
                    l = EditorGUI.ToggleLeft(new Rect(8, 224, position.width / 2 - 16, 16), "Left", l, EditorStyles.centeredGreyMiniLabel);
                    // Right Toggle.
                    r = EditorGUI.ToggleLeft(new Rect(position.width / 2 + 8, 224, position.width / 2 - 16, 16), "Right", r, EditorStyles.centeredGreyMiniLabel);

                    // Resolution Label Field
                    EditorGUI.LabelField(new Rect(8, 248, position.width - 16, 16), "Resolution", EditorStyles.centeredGreyMiniLabel);
                    // X Label Field.
                    EditorGUI.LabelField(new Rect(8, 272, position.width / 2 - 16, 16), string.Concat("X:\t", c.GetComponent<Camera>().pixelWidth), EditorStyles.centeredGreyMiniLabel);
                    // Y Label Field.
                    EditorGUI.LabelField(new Rect(position.width / 2 + 8, 272, position.width / 2 - 16, 16), string.Concat("Y:\t", c.GetComponent<Camera>().pixelHeight), EditorStyles.centeredGreyMiniLabel);

                    // Screenshot Label Field.
                    EditorGUI.LabelField(new Rect(8, 296, position.width - 16, 16), "Screenshot", EditorStyles.centeredGreyMiniLabel);
                    // File Label Field.
                    EditorGUI.LabelField(new Rect(8, 320, position.width - 16, 72), R('/', string.Concat(p, '/', n, '.', e)), EditorStyles.wordWrappedMiniLabel);
                }

                // Capture Screenshot Button.
                if (GUI.Button(new Rect(8, position.height - 112, position.width - 16, 32), "Capture Screenshot"))
                    if (Directory.Exists(R('\\', p)))
                    {
                        if (l)
                            ScreenCapture.CaptureScreenshot(R('\\', string.Concat(p, '\\', n, '.', e)), ScreenCapture.StereoScreenCaptureMode.LeftEye);
                        else if (r)
                            ScreenCapture.CaptureScreenshot(R('\\', string.Concat(p, '\\', n, '.', e)), ScreenCapture.StereoScreenCaptureMode.RightEye);
                        else if (l && r)
                            ScreenCapture.CaptureScreenshot(R('\\', string.Concat(p, '\\', n, '.', e)), ScreenCapture.StereoScreenCaptureMode.BothEyes);
                        else
                            ScreenCapture.CaptureScreenshot(R('\\', string.Concat(p, '\\', n, '.', e)), 1);
                    }
                    else
                        Debug.LogWarning(string.Concat("Directory.Exists(", p, "):\t", Directory.Exists(R('\\', p))));
            }
            else
                maxSize = minSize = h;

            // Drop Shadow Label.
            EditorGUI.DropShadowLabel(new Rect(8, position.height - 72, position.width - 16, 64), m, EditorStyles.centeredGreyMiniLabel);
        }

        private void OnInspectorUpdate()
        {
            m = new GUIContent("Screenshot by Murat Sancak", AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Murat Sancak/Sprites/Murat Sancak.png"));

            Repaint();
        }

        private void OnProjectChange() => AssetDatabase.Refresh();

        private void OnSelectionChange() => AssetDatabase.Refresh();

        // Murat Sancak

        private string R(char c, string s) => c is '/' ? s.Replace('\\', '/') : s.Replace('/', '\\'); // R: Replace, c: Character, s: String.
    }
}
#endif

// Murat Sancak