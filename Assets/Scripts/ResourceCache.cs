using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Loads all scriptable objects as references
/// </summary>
public class SystemCache : Singleton<SystemCache>
{
    protected SystemCache(){}

    [SerializeField]
    public StateSystem stateSystem;

    public GameStateSystem gameStateSystem;

    void Start(){
        stateSystem.InitDict();
        gameStateSystem.InitDict();
    }

}
