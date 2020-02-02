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

    //Contains solution for
    public SettingsObject solution;

    public void InitDict(){
        GameEnum flag = GameEnum.Temperature;
        while(flag != GameEnum.Null){
            game_dict.Add(flag, 0.5f);
            flag++;
        }
           
    }

    public void ResetDict(){
         GameEnum flag = GameEnum.Temperature;
         while(flag != GameEnum.Null){
            SetValue(flag, 0);
            flag++;
         }
         Debug.Log("Exit Reset");
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
                case GameEnum.RedX:
                    value = settings.redX;
                    break;
                case GameEnum.RedY:
                    value = settings.redY;
                    break;
                case GameEnum.BlueX:
                    value = settings.blueX;
                    break;
                case GameEnum.BlueY:
                    value = settings.blueY;
                    break;
                case GameEnum.YellowX:
                    value = settings.yellowX;
                    break;
                case GameEnum.YellowY:
                    value = settings.yellowY;
                    break;
                default:
                    throw new System.Exception("Calvin: Enum has not yet been integrated into dictionary.");
            }
            if(!isSimilar(value, GetValue(flag))) {
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
        float returnVal;
        game_dict.TryGetValue(variable, out returnVal);
        return returnVal;
    }

    ///<summary>
    ///Since we are working with floats, we should just check they are within reason
    ///<summary>
    public bool isSimilar(float value1, float value2){
        if(Mathf.Abs(value1 - value2) <= 10f){
            return true;
        }
        return false;
    }
}
