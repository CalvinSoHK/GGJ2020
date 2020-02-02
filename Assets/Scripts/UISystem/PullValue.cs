using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ2020.Utility;

///<summary>
///Pulls a single value out of GameStateManager
///<summary>
public class PullValue : MonoBehaviour
{
    public GameEnum PULL_ENUM;

    public float value = 0;

    void Update(){
        if(SystemCache.Instance.gameStateSystem.isReady){
            value = SystemCache.Instance.gameStateSystem.GetValue(PULL_ENUM);
        }       
    }
}
