using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary> 
///maps enum value to color
///<summary>
[RequireComponent(typeof(PullValue))]
public class MapEnumToTransparency : MonoBehaviour
{
    [SerializeField]
    Image image;

    [SerializeField]
    PullValue pull;

    Color originalColor;

    void Start(){
        originalColor = image.color;
    }

    void Update(){
        Color newColor = originalColor;
        newColor.a = pull.value/100f;
        image.color = newColor;
    }
}
