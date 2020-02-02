using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ2020.Utility;

public class RobotOne : MonoBehaviour, IPatient
{
    //Referneces to both because we use them quite frequently.
    GameStateSystem gameStateSystem;
    StateSystem stateSystem;

    //Enum for what checkpoint we're on
    //Starts with None, counts up to One, then Two, all the way to Finished.
    public CheckPointProgress checkpoint = CheckPointProgress.None;

    //Type of robot this is.
    public RobotType robot = RobotType.ShyBot;

    //Goals for different checkpoints
    public float volumeGoal = 80;

    public float brightnessGoal = 80;

    void Start(){
        gameStateSystem = SystemCache.Instance.gameStateSystem;
        stateSystem = SystemCache.Instance.stateSystem;
    }

    public void Init()
    {

    }

    public void Complete()
    {

    }

    public bool isFirstCheckpoint()
    {
        //This robot needs volume tuned up to 80, around that value it will be good.
        if(gameStateSystem.isSimilar(gameStateSystem.GetValue(GGJ2020.Utility.GameEnum.Volume), volumeGoal)){
            return true;
        }
        return false;
    }

    public bool isSecondCheckpoint()
    {
        //This robot needs the screen to cover his face to move on. Check for the flag.
        if(stateSystem.IsFlag(GGJ2020.Utility.FlagEnum.FaceCovered)){
            return true;
        }
        return false;
    }

    public bool isThirdCheckpoint()
    {
        if(gameStateSystem.isSimilar(gameStateSystem.GetValue(GGJ2020.Utility.GameEnum.Brightness), brightnessGoal)){
            return true;
        }
        return false;
    }

    public RobotType GetRobotType(){
        return robot;
    }

    public CheckPointProgress GetCheckPointProgress(){
        return checkpoint;
    }
}
