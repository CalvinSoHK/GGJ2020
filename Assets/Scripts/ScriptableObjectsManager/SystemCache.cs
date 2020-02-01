using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Loads all scriptable objects as references
/// </summary>
public class ResourceCache : Singleton<ResourceCache>
{
    protected ResourceCache(){}

    [SerializeField]
    public StateSystem stateSystem;

    [SerializeField]
    public GameStateSystem gameStateSystem;

    void Start(){
        stateSystem.InitDict();
    }

}
