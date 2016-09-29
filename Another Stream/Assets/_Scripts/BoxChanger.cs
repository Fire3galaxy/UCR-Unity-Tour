using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

public class BoxChanger : NetworkBehaviour {
    [ClientRpc] // Run by client
    public void RpcChangeColor()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }
}
