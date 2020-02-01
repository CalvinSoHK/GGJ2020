using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GGJ2020.Utility;

///<summary>
///Slider for temperature
///<summary>
public class TemperatureSlider : MonoBehaviour, IMessagable
{
    /// <summary>
    /// Sends messages to gameStateSystem about temperature.
    /// <summary>
    public void SendMessage(GameStateSystem gameStateSystem){
        gameStateSystem.SetValue(GameEnum.Temperature, GetComponent<Slider>().value);
    }
}
