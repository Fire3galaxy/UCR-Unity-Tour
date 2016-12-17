using UnityEngine;
using System.Collections;

public class CreateRoomResponder : MonoBehaviour {
    public ConnectAndJoinRoom GameLogic;

    public void OnClick() {
        GameLogic.OnClickCreateRoom();
    }
}
