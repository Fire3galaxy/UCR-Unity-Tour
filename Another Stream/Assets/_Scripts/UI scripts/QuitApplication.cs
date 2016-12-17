using UnityEngine;
using System.Collections;

public class QuitApplication : MonoBehaviour {
    public static void Quit() {
        if (Application.isEditor)
            UnityEditor.EditorApplication.isPlaying = false;
        else
            Application.Quit();
    }
}
