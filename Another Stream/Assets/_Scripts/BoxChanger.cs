using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

public class BoxChanger : NetworkBehaviour, IGvrGazeResponder {
    private bool touchingBox = false;

    public void OnGazeEnter()
    {
        if (!touchingBox)
        {
            Debug.Log("Touching box");
            touchingBox = true;
        }
    }

    public void OnGazeExit()
    {
        Debug.Log("Not touching box");
        touchingBox = false;
    }

    public void OnGazeTrigger()
    {
        CmdChangeBox();
    }

    [ClientRpc] // Run by client
    public void RpcChangeColor()
    {
        Debug.Log("In RpcChangeColor()");
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    [Command]   // Run by server
    void CmdChangeBox()
    {
        //if (hitObject.GetComponent<Collider>().tag == "box")
        Debug.Log("In CmdChangeBox()");
        RpcChangeColor();  // Maybe turn this into generic function of class that implements interactableInterface
    }
}
