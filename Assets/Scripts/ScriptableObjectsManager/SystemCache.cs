using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Loads all scriptable objects as references
/// </summary>
public class SystemCache : Singleton<SystemCache>
{
    protected SystemCache(){}

    [SerializeField]
    public StateSystem stateSystem;

    [SerializeField]
    public GameStateSystem gameStateSystem;

    [SerializeField]
    public GameObject textData;

    [SerializeField]
    public GameObject textDisplayer;

    public bool isReady = true;


    void Start(){
        DontDestroyOnLoad(gameObject);
        stateSystem.InitDict();
        gameStateSystem.InitDict();
    }

    void Update(){
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2) &&
            !isReady){
            textData = GameObject.Find("ParseCSV");
            textDisplayer = GameObject.Find("TextDisplayer");
            isReady = true;
        }
        else if(textData == null){
            isReady = false;
        }
    }

}
