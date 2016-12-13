using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ConnectAndJoinRoom : Photon.MonoBehaviour {
    public byte Version = 1;
    public GameObject ListContent;
    public GameObject ListItemPrefab;

    private bool ConnectedInUpdate = false;
    private List<GameObject> ObjectsList = new List<GameObject>();

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

    private void AddListItem(string s) {
        if (ListContent != null && ListItemPrefab != null) {
            GameObject listItemRoom = (GameObject)Instantiate(ListItemPrefab, ListContent.transform, false);
            ObjectsList.Add(listItemRoom);
            listItemRoom.GetComponentInChildren<Text>().text = s;
            //ListContent.text += debug;

        }
    }

    public virtual void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
    }

    public void OnJoinedRoom()
    {
        Debug.Log("In room: " + PhotonNetwork.room.name);

        string debug = "Joined: " + PhotonNetwork.room.name + " "
                + PhotonNetwork.room.playerCount + " "
                + PhotonNetwork.room.maxPlayers;
        AddListItem(debug);
    }

    public virtual void OnReceivedRoomListUpdate()
    {
        Debug.Log("Room list is available now");
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();
        
        if (rooms.Length == 0)
        {
            Debug.Log("No rooms available, creating room \"Starfish\"");
            PhotonNetwork.CreateRoom("Starfish");
        }
        else
        {
            if (ListContent != null)
            {
                foreach (RoomInfo game in rooms)
                {
                    string debug = "Room: " + game.name + " " + game.playerCount + " " + game.maxPlayers;
                    AddListItem(debug);
                    //ListContent.text += debug;
                }
            }
            PhotonNetwork.JoinRoom("Starfish");
        }
    }
}
