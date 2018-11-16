using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevel : MonoBehaviour {

    public void LoadScene(string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }

    public void OnClickSpawnPlayer()
    {
        GameObject.Find("PlayerNetwork").GetComponent<PlayerNetwork>().RPC_CreatePlayer();
    }
}
