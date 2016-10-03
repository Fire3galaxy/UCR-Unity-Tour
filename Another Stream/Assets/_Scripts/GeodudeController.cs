using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GeodudeController : NetworkBehaviour {
    void Start ()
    {
        if (isLocalPlayer)
            GetComponent<Renderer>().material.color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            transform.rotation = Camera.main.transform.rotation;

            // Raycast code to change box color
            //RaycastHit hit;
            //// .3f * forward is to avoid hitting Geodude asset's visors by starting raycast after it
            //Ray ray = new Ray(transform.position + (.3f * transform.forward), transform.forward);

            ////Debug.Log("Fire!");
            //if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane, 1 << 8))
            //{
            //    //Debug.Log(hit.collider.gameObject.name);
            //    if (hit.collider.tag == "box")
            //    {
            //        CmdChangeBox(hit.collider.gameObject);
            //    }
            //}
        }
    }
    
    [Command]   // Run by server
    void CmdChangeBox(GameObject hitObject)
    {
        //if (hitObject.GetComponent<Collider>().tag == "box")
            hitObject.GetComponent<BoxChanger>().RpcChangeColor();  // Maybe turn this into generic function of class that implements interactableInterface
    }
}
