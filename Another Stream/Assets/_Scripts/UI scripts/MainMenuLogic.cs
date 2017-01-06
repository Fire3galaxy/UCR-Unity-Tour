using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainMenuLogic : Photon.MonoBehaviour {
    enum States { HomeScreen, CreateRoomScreen, JoinRoomScreen, EnterRoomScreen, TourScreen };

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
    public GameObject EnterRoomScreen;

    public GameObject ListContent;
    public GameObject ListButtonPrefab;

    private bool ConnectedInUpdate = false;
    private States GameState = States.HomeScreen;
    private bool CreatingRoom = false;
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

    public virtual void OnFailedToConnectToPhoton(DisconnectCause cause) {
        Debug.LogError("OnFailedToConnectToPhoton(): " + cause.ToString());
    }

    public virtual void OnJoinedRoom() {
        if (CreatingRoom) {
            LoadingImage.sprite = LoadedSprite;
            EnterRoomScreen.GetComponentInChildren<Text>().text = "Room created!\n<size=40>"
                + PhotonNetwork.room.name + "</size>";
            EnterRoomScreen.GetComponentInChildren<Button>(true).gameObject.SetActive(true);

            CreatingRoom = false;
        }
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
        switch (GameState) {
            case States.HomeScreen:
                QuitApplication.Quit();
                break;
            default:
                BackToHomeScreen();
                break;
        }
    }

    public void BackToHomeScreen() {
        // Add home page and loading screen
        HomeScreen.SetActive(true);
        LoadingImage.gameObject.SetActive(true);
        LoadingText.gameObject.SetActive(true);

        // Remove anything else
        CreateRoomScreen.SetActive(false);
        EnterRoomScreen.SetActive(false);

        // Update state
        GameState = States.HomeScreen;
        QuitButtonText.text = QUIT;
    }

    public void OnClickCreateRoom() {
        // Remove home page and loading screen
        HomeScreen.SetActive(false);
        LoadingImage.gameObject.SetActive(false);
        LoadingText.gameObject.SetActive(false);

        // Add in create room menu
        CreateRoomScreen.SetActive(true);

        // Update state
        GameState = States.CreateRoomScreen;
        QuitButtonText.text = BACK;
    }

    public void OnClickSubmitRoom() {
        // Views in CreateRoomScreen
        InputField roomInputField = CreateRoomScreen.GetComponentInChildren<InputField>();
        GameObject createRoomText = CreateRoomScreen.GetComponentInChildren<Text>().gameObject;
        GameObject submitRoomButton = CreateRoomScreen.GetComponentInChildren<Button>().gameObject;
        Text enterRoomText = EnterRoomScreen.GetComponentInChildren<Text>();

        // Change game state
        roomInputField.gameObject.SetActive(false); // Create Room Screen state
        createRoomText.SetActive(false);
        submitRoomButton.SetActive(false);

        GameState = States.EnterRoomScreen;         // Enter Room Screen state
        LoadingImage.sprite = NotLoadedSprite;
        LoadingImage.gameObject.SetActive(true);
        EnterRoomScreen.SetActive(true);

        // Create room with name given by user
        CreatingRoom = true;
        string roomName = roomInputField.text;
        enterRoomText.text = "Creating room:\n<size=40>" + roomName + "</size>";
        PhotonNetwork.CreateRoom(roomName);
    }

    public void OnClickJoinRoom() {
        Debug.Log("Clicked Join Room");
    }

    public void OnClickToRoom() {
        Debug.Log("To the room now!");
        GetComponent<TourLogic>().ChangeCamera();
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
