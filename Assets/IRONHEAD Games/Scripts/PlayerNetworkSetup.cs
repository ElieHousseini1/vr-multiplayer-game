using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerNetworkSetup : MonoBehaviourPunCallbacks
{
    public GameObject LocalXRRigGameobject;

    public GameObject AvatarHeadGameObject;
    public GameObject AvatarBodyGameObject;

    // Start is called before the first frame update
    void Start()
    {
        if(photonView.IsMine){
            // The player is local
            LocalXRRigGameobject.SetActive(true);

            SetLayerRecursively(AvatarHeadGameObject,6);
            SetLayerRecursively(AvatarBodyGameObject,7);

            TeleportationArea[] teleportationAreas = GameObject.FindObjectsOfType<TeleportationArea>();
            if(teleportationAreas.Length > 0){
                Debug.Log("Found " + teleportationAreas.Length + " teleportation area.");
                foreach(var item in teleportationAreas){
                    item.teleportationProvider = LocalXRRigGameobject.GetComponent<TeleportationProvider>();
                }
            }


        } else {
            // The player is remote
            LocalXRRigGameobject.SetActive(false);

            SetLayerRecursively(AvatarHeadGameObject,0);
            SetLayerRecursively(AvatarBodyGameObject,0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetLayerRecursively(GameObject go, int layerNumber)
    {
        if (go == null) return;
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }
}
