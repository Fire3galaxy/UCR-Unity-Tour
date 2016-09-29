using UnityEngine;
using System.Collections;

public class TransformToCamera : MonoBehaviour {
    public Camera fpsCamera;
	
	// Update is called once per frame
	void Update () {
        transform.rotation = fpsCamera.GetComponent<Transform>().rotation;
	}
}
