using UnityEditor;
using UnityEngine;

namespace Lukomor.Tools.Editor
{
    public class ClearPrefsTools : MonoBehaviour
    {
        [MenuItem("Tools/Clear player prefs")]
        public static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}
