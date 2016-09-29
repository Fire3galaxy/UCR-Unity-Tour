using UnityEngine;
using System.Collections;

public class RaycastTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        Debug.Log("Fire!");
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.tag);
            if (hit.collider.tag == "box")
            {
                Debug.Log("Hit!");
            }
        }
    }
}
