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
                MasterLoadedGameLevel1();
            else
                NoMasterLoadedGame();
        }

        if (scene.name == "Level 2")
        {
            if (PhotonNetwork.isMasterClient)
                MasterLoadedGameLevel2();
            else
                NoMasterLoadedGame();
        }

        if (scene.name == "Level 3")
        {
            if (PhotonNetwork.isMasterClient)
                MasterLoadedGameLevel3();
            else
                NoMasterLoadedGame();
        }

        if (scene.name == "Level 4")
        {
            if (PhotonNetwork.isMasterClient)
                MasterLoadedGameLevel4();
            else
                NoMasterLoadedGame();
        }

        if (scene.name == "Level 5")
        {
            if (PhotonNetwork.isMasterClient)
                MasterLoadedGameLevel5();
            else
                NoMasterLoadedGame();
        }

        if (scene.name == "Level 6")
        {
            if (PhotonNetwork.isMasterClient)
                MasterLoadedGameLevel6();
            else
                NoMasterLoadedGame();
        }

        if (scene.name == "Level 7")
        {
            if (PhotonNetwork.isMasterClient)
                MasterLoadedGameLevel7();
            else
                NoMasterLoadedGame();
        }
    }

    private void MasterLoadedGameLevel1()
    {
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
        PhotonView.RPC("RPC_LoadGameOthersLevel1", PhotonTargets.Others);
    }

    private void MasterLoadedGameLevel2()
    {
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
        PhotonView.RPC("RPC_LoadGameOthersLevel2", PhotonTargets.Others);
    }

    private void MasterLoadedGameLevel3()
    {
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
        PhotonView.RPC("RPC_LoadGameOthersLevel3", PhotonTargets.Others);
    }

    private void MasterLoadedGameLevel4()
    {
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
        PhotonView.RPC("RPC_LoadGameOthersLevel4", PhotonTargets.Others);
    }

    private void MasterLoadedGameLevel5()
    {
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
        PhotonView.RPC("RPC_LoadGameOthersLevel5", PhotonTargets.Others);
    }

    private void MasterLoadedGameLevel6()
    {
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
        PhotonView.RPC("RPC_LoadGameOthersLevel6", PhotonTargets.Others);
    }

    private void MasterLoadedGameLevel7()
    {
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
        PhotonView.RPC("RPC_LoadGameOthersLevel7", PhotonTargets.Others);
    }

    private void NoMasterLoadedGame()
    {
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
    }

    [PunRPC]
    private void RPC_LoadGameOthersLevel1()
    {
        PhotonNetwork.LoadLevel(3);
    }

    [PunRPC]
    private void RPC_LoadGameOthersLevel2()
    {
        PhotonNetwork.LoadLevel(4);
    }

    [PunRPC]
    private void RPC_LoadGameOthersLevel3()
    {
        PhotonNetwork.LoadLevel(5);
    }

    [PunRPC]
    private void RPC_LoadGameOthersLevel4()
    {
        PhotonNetwork.LoadLevel(6);
    }

    [PunRPC]
    private void RPC_LoadGameOthersLevel5()
    {
        PhotonNetwork.LoadLevel(7);
    }

    [PunRPC]
    private void RPC_LoadGameOthersLevel6()
    {
        PhotonNetwork.LoadLevel(8);
    }

    [PunRPC]
    private void RPC_LoadGameOthersLevel7()
    {
        PhotonNetwork.LoadLevel(9);
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
