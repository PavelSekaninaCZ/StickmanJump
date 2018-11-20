using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveCurrentMatch : MonoBehaviour {

    public void OnClick_LeaveMatch()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel(0);
        
    }

    public void Menu()
    {
        PhotonNetwork.LoadLevel(0);
    }

    public void OnClickSpawnPlayer()
    {
        GameObject.Find("PlayerNetwork").GetComponent<PlayerNetwork>().RPC_CreatePlayer();
        Debug.Log("Func");
    }
}
