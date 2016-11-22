using UnityEngine;
using System.Collections;

public class GeodudePUNController : Photon.MonoBehaviour {
	// Update is called once per frame
	void Update () {
        if (this.photonView.isMine)
            transform.rotation = Camera.main.transform.rotation;
	}
}
