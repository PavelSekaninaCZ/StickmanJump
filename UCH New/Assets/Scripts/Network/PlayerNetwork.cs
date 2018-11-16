using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNetwork : MonoBehaviour {

    public static PlayerNetwork Instance;
    public string PlayerName { get; private set; }
    private PhotonView PhotonView;
    private int PlayerInGame = 0;

    private void Awake()
    {
        Instance = this;
        PhotonView = GetComponent<PhotonView>();

        PlayerName = "Player # " + Random.Range(1, 9999);

        PhotonNetwork.sendRate = 60;
        PhotonNetwork.sendRateOnSerialize = 30;
        PhotonNetwork.automaticallySyncScene = true;
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
	}

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level 1")
        {
            if (PhotonNetwork.isMasterClient)
                MasterLoadedGame();
            else
                NoMasterLoadedGame();
        }
    }

    private void MasterLoadedGame()
    {
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
        PhotonView.RPC("RPC_LoadGameOthers", PhotonTargets.Others);
    }

    private void NoMasterLoadedGame()
    {
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
    }

    [PunRPC]
    private void RPC_LoadGameOthers()
    {
        PhotonNetwork.LoadLevel(3);
    }

    [PunRPC]
    public void RPC_LoadedGameScene()
    {
        PlayerInGame++;
        if (PlayerInGame == PhotonNetwork.playerList.Length)
        {
            print("All players are in the game scene");
            PhotonView.RPC("RPC_CreatePlayer", PhotonTargets.All);
        }
    }

    [PunRPC]
    public void RPC_CreatePlayer()
    {
        float randomValue = Random.Range(0f, 15f);
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "NewPlayer"), Vector3.up * randomValue, Quaternion.identity, 0);
    }
	
}
