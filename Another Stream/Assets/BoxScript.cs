using UnityEngine;
using System.Collections;

public class BoxScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Collider>().tag = "box";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
