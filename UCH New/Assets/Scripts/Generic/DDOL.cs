using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour
{

    public string destroyScene;

    void Awake()
    {
        DontDestroyOnLoad(this);
        // Add the OptionalDestroy method to the delegate
        SceneManager.sceneLoaded += OptionalDestroy;
    }

    void OnDestroy()
    {
        // We MUST remove the method from the delegate manually when destroying.
        SceneManager.sceneLoaded -= OptionalDestroy;
    }

    // This method is called whenever SceneManager.sceneLoaded is invoked.
    void OptionalDestroy(Scene loadedScene, LoadSceneMode mode)
    {
        if (loadedScene.name == destroyScene)
        {
            Destroy(this);
        }
    }
}
