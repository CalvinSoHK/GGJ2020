using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ2020.Utility;

///<summary>
/// Contains all the info we need for game state. This is not flags.
/// This is for values we are watching during the consultation.
/// Extend this script as we add new values that need to be tracked.
///<summary>
[CreateAssetMenu(fileName = "GameStateSystemSO", menuName = "ScriptableObjects/GameStateSystem", order = 1)]
public class GameStateSystem : ScriptableObject
{
    //Contains list of flags that are TRUE
    public Dictionary<GameEnum, float> game_dict = new Dictionary<GameEnum, float>();

    public void InitDict(){
         GameEnum flag = GameEnum.Temperature;
         while(flag != GameEnum.Null){
            game_dict.Add(flag, 0.5f);
            flag++;
         }
    }

    ///<summary>
    ///Sets the whole dictionary to the values in a given settings
    ///<summary>
    public void SetDict(SettingsObject settings){
        GameEnum flag = GameEnum.Temperature;
        while(flag != GameEnum.Null){
            float value;
            switch(flag){
                case GameEnum.Temperature:
                    value = settings.temperature;
                    break;
                case GameEnum.Brightness:
                    value = settings.brightness;
                    break;
                case GameEnum.Volume:
                    value = settings.volume;
                    break;
                default:
                    throw new System.Exception("Calvin: Enum has not yet been integrated into dictionary.");
            }
            game_dict[flag] = value;
            flag++;
        }

    }

    ///<summary>
    /// Returns true if the current settings are exactly the same as a given SettingsObject.
    ///<summary>
    public bool isSettingsSame(SettingsObject settings){
        GameEnum flag = GameEnum.Temperature;
        while(flag != GameEnum.Null){
            float value;
            switch(flag){
                case GameEnum.Temperature:
                    value = settings.temperature;
                    break;
                case GameEnum.Brightness:
                    value = settings.brightness;
                    break;
                case GameEnum.Volume:
                    value = settings.volume;
                    break;
                default:
                    throw new System.Exception("Calvin: Enum has not yet been integrated into dictionary.");
            }
            if(game_dict[flag] != value){
                return false;
            }
            flag++;
        }
        return true;
    }

    ///<summary>
    ///Sets the value of the given gameEnum to the given value.
    ///<summary>
    public void SetValue(GameEnum variable, float value){
        game_dict[variable] = value;
    }

    ///<summary>
    ///Returns the values of the given variable in the dictionary.
    ///<summary>
    public float GetValue(GameEnum variable){
        return game_dict[variable];
    }
}
