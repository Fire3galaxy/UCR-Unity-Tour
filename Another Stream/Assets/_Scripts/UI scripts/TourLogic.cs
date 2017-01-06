using UnityEngine;
using System.Collections;

public class TourLogic : Photon.MonoBehaviour {
    public GameObject UICanvas;

    public void ChangeCamera() {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        UICanvas.SetActive(false);
        Debug.Log("Should be in VR mode");
    }
}
