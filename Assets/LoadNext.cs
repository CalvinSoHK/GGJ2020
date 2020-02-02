using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNext : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += UnloadCurrentScene;
    }

    public void UnloadCurrentScene(Scene scene, LoadSceneMode mode){
        SceneManager.sceneLoaded -= UnloadCurrentScene;
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
        SceneManager.UnloadScene(SceneManager.GetSceneByBuildIndex(0));
    }
}
