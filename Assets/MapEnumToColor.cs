using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary> 
///maps enum value to color
///<summary>
[RequireComponent(typeof(PullValue))]
public class MapEnumToColor : MonoBehaviour
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
        image.color = MapValToColorChange(pull.value);
    }

    public Color MapValToColorChange(float val){
        Color newColor = originalColor;
        //Instead of mapping to the color we want to shower, lower the other channels
        if(val < 50){
            newColor.r = 1 - Mathf.Abs(val - 50)/100;
            newColor.g = 1 - Mathf.Abs(val - 50)/100;
        }
        else if(val > 50){
            newColor.g =  1- (val - 50)/ 100;
            newColor.b = 1 -(val - 50)/ 100;
        }
        return newColor;
    }
}
