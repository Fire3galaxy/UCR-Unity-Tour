using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ConnectAndJoinRoom : Photon.MonoBehaviour {
    private const string QUIT = "Quit"; // Quit button strings
    private const string BACK = "Back";

    public byte Version = 1;

    // Quit/Back button
    public Text QuitButtonText;

    // Objects that indicate Loading
    public Text LoadingText;
    public Image LoadingImage;
    public Sprite LoadedSprite;
    public Sprite NotLoadedSprite;

    // Different User Screens
    public GameObject HomeScreen;
    public GameObject CreateRoomScreen;

    public GameObject ListContent;
    public GameObject ListButtonPrefab;

    private bool ConnectedInUpdate = false;
    private bool IsInHomeScreen = true;
    private List<GameObject> ObjectsList = new List<GameObject>();

	// Use this for initialization
	public virtual void Start ()
    {
	    
	}
	
	// Update is called once per frame
	public virtual void Update ()
    {
        if (!ConnectedInUpdate) {
            Debug.Log("In update");
            PhotonNetwork.ConnectUsingSettings(Version + ".0");
            ConnectedInUpdate = true;
        }
    }

    public virtual void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
        LoadingText.text = "In Lobby!";
        LoadingImage.sprite = LoadedSprite;
        HomeScreen.SetActive(true);
    }

    //public void OnJoinedRoom()
    //{
    //    Debug.Log("In room: " + PhotonNetwork.room.name);

    //    //string debug = "Joined: " + PhotonNetwork.room.name + " "
    //    //        + PhotonNetwork.room.playerCount + " "
    //    //        + PhotonNetwork.room.maxPlayers;
    //    //AddListItem(debug);
    //}

    //public virtual void OnReceivedRoomListUpdate()
    //{
    //    Debug.Log("Room list is available now");
    //    RoomInfo[] rooms = PhotonNetwork.GetRoomList();
        
    //    if (rooms.Length == 0)
    //    {
    //        Debug.Log("No rooms available, creating room \"Starfish\"");
    //        //PhotonNetwork.CreateRoom("Starfish");

    //    }
    //    else
    //    {
    //        if (ListContent != null)
    //        {
    //            foreach (RoomInfo game in rooms)
    //            {
    //                string debug = "Room: " + game.name + " " + 
    //                    game.playerCount + " " + game.maxPlayers;
    //                AddListItem(debug);
    //                //ObjectsList[ObjectsList.Count - 1]
    //                //    .GetComponent<Button>()
    //                //    .onClick
    //                //    .AddListener(CreateRoom);
    //            }
    //        }
    //        //PhotonNetwork.JoinRoom("Starfish");
    //    }
    //}
    
    public void OnClickQuit() {
        if (IsInHomeScreen)
            QuitApplication.Quit();
        else
            OnClickSubmitRoom();    // FIXME: replace with enum
    }

    public void OnClickCreateRoom() {
        // Remove home page and loading screen
        HomeScreen.SetActive(false);
        LoadingImage.gameObject.SetActive(false);
        LoadingText.gameObject.SetActive(false);

        // Add in create room menu
        CreateRoomScreen.SetActive(true);

        // Update this bool
        IsInHomeScreen = false;
        QuitButtonText.text = BACK;
    }

    public void OnClickSubmitRoom() {
        // Remove home page and loading screen
        HomeScreen.SetActive(true);
        LoadingImage.gameObject.SetActive(true);
        LoadingText.gameObject.SetActive(true);

        // Add in create room menu
        CreateRoomScreen.SetActive(false);

        // Update Quit button
        IsInHomeScreen = true;
        QuitButtonText.text = QUIT;
    }
    

    private void AddListItem(string s) {
        if (ListContent != null && ListButtonPrefab != null) {
            GameObject listItemRoom = (GameObject)Instantiate(ListButtonPrefab, ListContent.transform, false);
            ObjectsList.Add(listItemRoom);
            listItemRoom.GetComponentInChildren<Text>().text = s;
        }
    }

    private void CreateRoom() {
        PhotonNetwork.CreateRoom("Starfish");
    }
}
