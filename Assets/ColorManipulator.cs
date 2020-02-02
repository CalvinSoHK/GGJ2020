using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ2020.Utility;

[RequireComponent(typeof(PullValue))]
public class ColorManipulator : MonoBehaviour
{
    public ColorEnum CUR_CHANNEL = ColorEnum.Blue;

    public PullValue x_value, y_value;

    public void SetChannel(int inputColor){
        ColorEnum newColor = (ColorEnum)inputColor;
        CUR_CHANNEL = newColor;
        switch(newColor){
            case ColorEnum.Blue:
                x_value.PULL_ENUM = GameEnum.BlueX;
                y_value.PULL_ENUM = GameEnum.BlueY;
                break;
            case ColorEnum.Yellow:
                x_value.PULL_ENUM = GameEnum.YellowX;
                y_value.PULL_ENUM = GameEnum.YellowY;
                break;
            case ColorEnum.Red:
                x_value.PULL_ENUM = GameEnum.RedX;
                y_value.PULL_ENUM = GameEnum.RedY;
                break;
            default:
                throw new System.Exception("Error, somehow inputted a color channel we don't support.");      
        }
        
    }
}
