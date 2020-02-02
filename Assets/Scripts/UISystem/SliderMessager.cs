using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GGJ2020.Utility;

///<summary>
///Slider for temperature
///<summary>
public class SliderMessager : MonoBehaviour, IMessagable
{
    public GameEnum PULL_ENUM;

    void Start()
    {
        SendMessage(SystemCache.Instance.gameStateSystem);
    }

    /// <summary>
    /// Sends messages to gameStateSystem about temperature.
    /// <summary>
    public void SendMessage(GameStateSystem gameStateSystem){
        gameStateSystem.SetValue(PULL_ENUM, GetComponent<Slider>().value);
    }
}
