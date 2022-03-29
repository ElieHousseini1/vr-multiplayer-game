using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkedGrabbing : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
{
    PhotonView m_photonView;

<<<<<<< HEAD
    Rigidbody rb;
    bool isBeingHeld = false;

=======
>>>>>>> 5be909e4ff33c30cca1ed4eff100ded4c235ad98
    private void Awake(){
        m_photonView = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        rb = GetComponent<Rigidbody>();
=======

>>>>>>> 5be909e4ff33c30cca1ed4eff100ded4c235ad98
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if(isBeingHeld){
            // Object is being grabbed
            rb.isKinematic = true;
            gameObject.layer = 11;
        } else{
            // Object is not being grabbed
            rb.isKinematic = false;
            gameObject.layer = 9;
        }
=======

>>>>>>> 5be909e4ff33c30cca1ed4eff100ded4c235ad98
    }

    private void TransferOwnership(){
        m_photonView.RequestOwnership();
    }

    public void OnSelectEntered(){
        Debug.Log("Grabbed");
<<<<<<< HEAD
        m_photonView.RPC("StartNetworkGrabbing", RpcTarget.AllBuffered);

        if(m_photonView.Owner == PhotonNetwork.LocalPlayer){
            Debug.Log("We do not request the ownership. Already mine.");
        } else {
        TransferOwnership();
        }
    }
    public void onSelectExited(){
        Debug.Log("Released");
        m_photonView.RPC("StopNetworkGrabbing", RpcTarget.AllBuffered);
=======
        TransferOwnership();
    }
    public void onSelectExited(){
        Debug.Log("Released");
>>>>>>> 5be909e4ff33c30cca1ed4eff100ded4c235ad98
    }

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
<<<<<<< HEAD

        if(targetView != m_photonView){
            return;
        }

=======
>>>>>>> 5be909e4ff33c30cca1ed4eff100ded4c235ad98
        Debug.Log("Ownership Requested for: " + targetView.name + " from " + requestingPlayer.NickName);
        m_photonView.TransferOwnership(requestingPlayer);
    }

    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        Debug.Log("onOwnership Transfered for: " + targetView.name + " from " + previousOwner.NickName);
    }

    public void OnOwnershipTransferFailed(PhotonView targetView, Player senderOfFailedRequest)
    {

    }
<<<<<<< HEAD

    [PunRPC]
    public void StartNetworkGrabbing(){
        isBeingHeld = true;
    }
    [PunRPC]
    public void StopNetworkGrabbing(){
        isBeingHeld = false;
    }

=======
>>>>>>> 5be909e4ff33c30cca1ed4eff100ded4c235ad98
}
