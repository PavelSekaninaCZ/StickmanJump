using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("PlayerNetwork").GetComponent<PlayerNetwork>().RPC_LoadedGameScene();
    }
	
	
}
