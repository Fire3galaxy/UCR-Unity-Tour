using UnityEngine;
using System.Collections;

public class ConnectAndJoinRoom : Photon.MonoBehaviour {
    public byte Version = 1;
    private bool ConnectedInUpdate = false;

	// Use this for initialization
	public virtual void Start ()
    {
	    
	}
	
	// Update is called once per frame
	public virtual void Update ()
    {
        if (!ConnectedInUpdate)
        {
            Debug.Log("In update");
            PhotonNetwork.ConnectUsingSettings(Version + ".0");
            ConnectedInUpdate = true;
        }
    }

    public virtual void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();

        if (rooms.Length == 0)
            Debug.Log("No rooms available");
        else
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                Debug.Log(rooms[i].name);
            }
        }
    }
}
