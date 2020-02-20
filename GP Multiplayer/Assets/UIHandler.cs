using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class UIHandler : MonoBehaviourPunCallbacks
{
    public InputField createRoomTF;
    public InputField joinRoomTF;

    public void OnClick_JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoomTF.text, null);
    }

    public void OnClick_CreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoomTF.text, new RoomOptions { MaxPlayers = 4 }, null);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Successfully joined room!");
        PhotonNetwork.LoadLevel(1);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        Debug.Log("Failed to join room" + returnCode + "Message" + message);
    }




}
