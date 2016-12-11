using UnityEngine;
using System.Collections;

public class InstantiateAvatar : MonoBehaviour {
    public GameObject avatarPrefab;
    private GameObject avatarGameObject;

    public void OnJoinedRoom()
    {
        avatarGameObject = PhotonNetwork.Instantiate(avatarPrefab.name, new Vector3(0, 0, 0), Quaternion.identity, 0);
        if (avatarGameObject != null)
            avatarGameObject.GetComponent<Renderer>().material.color = Color.cyan;
    }
}
