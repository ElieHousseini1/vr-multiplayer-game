using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class LoginManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField PlayerName_InputName;
    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region UI callback methods
    public void connectAnynomously()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public void connectToPhotonServer(){
        if(PlayerName_InputName != null){
            PhotonNetwork.NickName = PlayerName_InputName.text;
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    #endregion

    #region Photon Callbacks
    public override void OnConnected()
    {
        Debug.Log("OnConnected is called. The server is available.");
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master Server with player name: " + PhotonNetwork.NickName);
        PhotonNetwork.LoadLevel("HomeScene");
    }
    #endregion

}
