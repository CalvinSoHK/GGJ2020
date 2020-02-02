using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using GGJ2020.Utility;

/// <summary>
/// Scriptable Object that holds all our flags.
/// </summary>
[CreateAssetMenu(fileName = "StateSystemSO", menuName = "ScriptableObjects/StateSystem", order = 1)]
public class StateSystem : ScriptableObject
{
    //Contains list of flags that are TRUE
    public ConcurrentDictionary<FlagEnum, bool> flag_dict = new ConcurrentDictionary<FlagEnum, bool>();

    /// <summary>
    /// Initializes the Flag Dictionary with all flags.
    /// <summary>
    public void InitDict(){
         FlagEnum flag = FlagEnum.Checkpoint1;
         while(flag != FlagEnum.Null){
            flag_dict.TryAdd(flag, false);
            flag++;
         }
    }

    public void ResetDict(){
         FlagEnum flag = FlagEnum.Checkpoint1;
         while(flag != FlagEnum.Null){
            SetFlag(flag, false);
            flag++;
         }
    }

    /// <summary>
    /// Sets the given flag to be true.
    /// <summary>
    public void SetFlag(FlagEnum flag, bool value){
        if(flag_dict.ContainsKey(flag)){
            flag_dict.TryUpdate(flag, value, !value);
        }
    }

    /// <summary>
    /// Lets you know if the given flag is true.
    /// <summary>
    public bool IsFlag(FlagEnum flag){
        bool value;
        flag_dict.TryGetValue(flag, out value);
        return value;
    }
}
