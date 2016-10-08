using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AttachToCamera : NetworkBehaviour {
    
	void Start () {
        if (isLocalPlayer)
            Camera.main.GetComponent<PlayerHolder>().playerObject = gameObject;
	}
}
