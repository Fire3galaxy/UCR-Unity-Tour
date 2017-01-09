using UnityEngine;
using System.Collections;

public class TourLogic : MonoBehaviour {
    public GameObject UICanvas;
    public GameObject GvrViewerPrefab;

    public void ChangeCamera() {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        UICanvas.SetActive(false);
        Object.Instantiate(GvrViewerPrefab, Camera.main.transform);
        Debug.Log("Should be in VR mode");
    }
}
