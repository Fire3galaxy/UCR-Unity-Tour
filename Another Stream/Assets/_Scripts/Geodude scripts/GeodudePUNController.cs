using UnityEngine;
using System.Collections;

public class GeodudePUNController : Photon.MonoBehaviour {
    void Start ()
    {
        if (this.photonView.isMine)
            this.GetComponent<Renderer>().material.color = Color.cyan;
    }

	// Update is called once per frame
	void Update () {
        if (this.photonView.isMine)
            transform.rotation = Camera.main.transform.rotation;
	}
}
