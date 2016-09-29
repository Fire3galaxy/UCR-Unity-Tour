using UnityEngine;
using System.Collections;

public class UserReticle : MonoBehaviour {
    public GameObject userPicPrefab;
    private GameObject userPicObject = null;

    // Use this for initialization
    void Start () {
        userPicObject = (GameObject)Instantiate(    // How to instantiate:
                    userPicPrefab,                  // Copy this prefab
                    getReticlePosition(),           // At this position
                    getReticleRotation());          // With this rotation
    }
	
	// Update is called once per frame
	void Update () {
        if (userPicObject != null)
        {
            // Circular side of reticle cylinder towards user
            userPicObject.transform.rotation = getReticleRotation();
            userPicObject.transform.position = getReticlePosition();
        }
    }

    Vector3 getReticlePosition()
    {
        return transform.position + transform.forward;
    }

    Quaternion getReticleRotation()
    {
        return Quaternion.LookRotation(
                Vector3.Cross(Vector3.Cross(Vector3.up, transform.forward), transform.forward));
    }
}
