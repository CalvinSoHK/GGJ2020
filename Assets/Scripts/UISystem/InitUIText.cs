using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary> 
///Sets the UI text to reflect the correct value
///<summary>
[RequireComponent(typeof(PullValue))]
public class InitUIText : MonoBehaviour
{
    void Start(){
        float value = SystemCache.Instance.gameStateSystem.GetValue(transform.GetComponent<PullValue>().PULL_ENUM);       
        GetComponent<Text>().text = (Mathf.Round(value * 10f)/10f).ToString();
    }
}
