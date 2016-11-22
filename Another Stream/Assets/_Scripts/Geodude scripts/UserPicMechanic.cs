using UnityEngine;
using System.Collections;

public class UserPicMechanic : Photon.MonoBehaviour {
    private const float DISTANCE = 1.4f;

    public GameObject userPicPrefab;
    private GameObject userPicObject = null;

    void Update()
    {
        if (!this.photonView.isMine)
        {
            if (userPicObject == null)
            {
                Vector3 towardsCamera = DISTANCE * transform.forward;  // Vector from object to camera
                Quaternion rotation = Quaternion.LookRotation(-towardsCamera);     // Face of quad is on other side

                userPicObject = (GameObject)Instantiate(    // How to instantiate:
                    userPicPrefab,                          // Copy this prefab
                    transform.position + (DISTANCE * transform.forward),    // At this position
                    rotation);                              // With this rotation
                userPicObject.GetComponent<Renderer>().material.color = Color.blue;
            }
            else
            {
                Vector3 towardsCamera = transform.position - userPicObject.transform.position;  // Vector from object to camera

                userPicObject.transform.position = transform.position + (DISTANCE * transform.forward); // This distance away
                userPicObject.transform.rotation = Quaternion.LookRotation(-towardsCamera);     // Face of quad is on other side
            }
        }
    }
}
