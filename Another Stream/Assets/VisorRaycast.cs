using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class VisorRaycast : NetworkBehaviour {
    private GameObject hitObject;

	// Update is called once per frame
	void Update () {
        //if (isServer)
        //{
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);

            Debug.Log("Fire!");
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.tag == "box")
                {
                    Debug.Log("Hit!");
                    hitObject = hit.collider.gameObject;
                    CmdChangeBox();
                }
            }
        //}
    }

    [Command]
    void CmdChangeBox()
    {
        hitObject.GetComponent<Renderer>().material.color = Color.yellow;
    }
}
