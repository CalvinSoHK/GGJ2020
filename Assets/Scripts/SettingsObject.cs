using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// Scriptable Object that marks a collection of settings, either the initial one or the solution.
///<summary>
[CreateAssetMenu(fileName = "SettingsObject", menuName = "ScriptableObjects/SettingsObject", order = 1)]
public class SettingsObject : ScriptableObject
{
    [Range(0, 100)]
    public float temperature;
    [Range(0, 100)]
    public float brightness;
    [Range(0, 100)]
    public float volume;
    [Range(0, 100)]
    public float redX;
    [Range(0, 100)]
    public float redY;
    [Range(0, 100)]
    public float yellowX; 
    [Range(0, 100)]
    public float yellowY; 
    [Range(0, 100)]
    public float blueX;
    [Range(0, 100)]
    public float blueY;
}
