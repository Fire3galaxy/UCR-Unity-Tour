using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SubmitRoomResponder : MonoBehaviour {
    public ConnectAndJoinRoom GameLogic;
    public Text InputField;

    public void onClick() {
        //Debug.Log("clicked Submit Room: " + InputField.text.Trim());
        GameLogic.OnClickSubmitRoom();
    }
}
