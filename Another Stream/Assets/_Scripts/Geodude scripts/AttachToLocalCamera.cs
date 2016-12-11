using UnityEngine;
using System.Collections;

public class AttachToLocalCamera : Photon.MonoBehaviour
{
    void Update()
    {
        if (PhotonNetwork.masterClient.isLocal)
            transform.rotation = Camera.main.GetComponent<Transform>().rotation;
    }
}
