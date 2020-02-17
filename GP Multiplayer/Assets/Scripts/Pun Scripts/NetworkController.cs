using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkController : MonoBehaviourPunCallbacks
{
    //public string versionName = "0.1";

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connecting to photon...");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("We are now connected to the " + PhotonNetwork.CloudRegion + "server!");
    }

    /*
    private void OnJoinedLobby()
    {
        
    }
    */






}
