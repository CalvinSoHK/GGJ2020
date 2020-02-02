using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// When Covered by another collider, sendFlag that we are covered. Otherwise send flag we aren't covered.
/// </summary>
public class CoveredSendFlag : MonoBehaviour
{
    public int count_of_covers = 0;

    void OnTriggerEnter2D()
    {
        count_of_covers++;
    }

    void OnTriggerStay2D()
    {
        if(count_of_covers > 0){
            SystemCache.Instance.stateSystem.SetFlag(GGJ2020.Utility.FlagEnum.FaceCovered, true);
            Debug.Log("Correct.");
        }
        
    }

    void OnTriggerExit2D()
    {
        count_of_covers--;
        if(count_of_covers == 0){
            SystemCache.Instance.stateSystem.SetFlag(GGJ2020.Utility.FlagEnum.FaceCovered, false);
        }
    }
}
