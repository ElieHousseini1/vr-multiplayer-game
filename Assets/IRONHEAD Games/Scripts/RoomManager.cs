using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    #region UI Callback Methods
    public void JoinRandomRoom(){
        PhotonNetwork.JoinRandomRoom();
    }
    #endregion


    #region Photon Callback Methods
    public override void OnJoinRandomFailed(short returnCode, string message){
        Debug.Log(message);
        CreateAndJoinRoom();
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("A room is created with name: " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("The Local Player : " + PhotonNetwork.LocalPlayer.NickName + " is in the room: " + PhotonNetwork.CurrentRoom.Name + " Player Count: " + PhotonNetwork.CurrentRoom.PlayerCount);
        if(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(MultiplayerVRConstants.MAP_TYPE_KEY)){
            object mapType;
            if(PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue(MultiplayerVRConstants.MAP_TYPE_KEY, out mapType)){
                Debug.Log("Joined Room with map: " + (string)mapType);
            }
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined. Player count: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }
    #endregion


    #region Private Methods
    private void CreateAndJoinRoom(){
        string randomRoomName = "Room_" + Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;

        string[] roomPropsInLobby = { MultiplayerVRConstants.MAP_TYPE_KEY};
        // we have 2 different maps
        // 1.Outdoor = "outdoor"
        // 2.School = "school"

        ExitGames.Client.Photon.Hashtable customRoomProperties = new ExitGames.Client.Photon.Hashtable(){{MultiplayerVRConstants.MAP_TYPE_KEY, MultiplayerVRConstants.MAP_TYPE_VALUE_SCHOOL}};

        roomOptions.CustomRoomPropertiesForLobby = roomPropsInLobby;
        roomOptions.CustomRoomProperties = customRoomProperties;

        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);
    }
    #endregion

}
