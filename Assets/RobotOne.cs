using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ2020.Utility;

public class RobotOne : MonoBehaviour, IPatient
{
    //Referneces to both because we use them quite frequently.
    GameStateSystem gameStateSystem;
    StateSystem stateSystem;
    GameObject allText;
    GameObject textDisplayer;

    List<ExcelReader> nameData;
    List<ExcelReader> checkpointData;

    //Enum for what checkpoint we're on
    //Starts with None, counts up to One, then Two, all the way to Finished.
    public CheckPointProgress checkpoint = CheckPointProgress.None;

    //Type of robot this is.
    public RobotType robot = RobotType.ShyBot;

    //Goals for different checkpoints
    public float volumeGoal = 80;

    public float brightnessGoal = 80;

    ParseCSV data;
    bool setup = false, looping = false;
    float lastLoop = 0.0f;

    void Start(){
        gameStateSystem = SystemCache.Instance.gameStateSystem;
        stateSystem = SystemCache.Instance.stateSystem;
        allText = SystemCache.Instance.textData;
        textDisplayer = SystemCache.Instance.textDisplayer;
        data = allText.GetComponent<ParseCSV>();
        //SetupTextData();
    }

    void Update()
    {
        if(data.doneParsingData() && !setup)
        {
            Debug.Log("here twice");
            SetupTextData();
            setup = true;
        }

        if(looping)
        {
            if(Time.time - lastLoop > 5.0)
            {
                loop(checkpointData);
            }
        }
    }



    void SetupTextData()
    {
       //ParseCSV data = allText.GetComponent<ParseCSV>();
        nameData = data.GetDataByName("ShyRobot");
        //Debug.Log(nameData[0].speaker);
        string checkPointValue = "";

        switch (checkpoint)
        {
            case CheckPointProgress.None:
                checkPointValue = "None";
                break;
            case CheckPointProgress.One:
                checkPointValue = "One";
                break;
            case CheckPointProgress.Two:
                checkPointValue = "Two";
                break;
            case CheckPointProgress.Three:
                checkPointValue = "Three";
                break;
            case CheckPointProgress.Four:
                checkPointValue = "Four";
                break;
            case CheckPointProgress.Five:
                checkPointValue = "Five";
                break;
            case CheckPointProgress.Six:
                checkPointValue = "Six";
                break;
            case CheckPointProgress.Seven:
                checkPointValue = "Seven";
                break;
            case CheckPointProgress.Eight:
                checkPointValue = "Eigth";
                break;
        }
        GetCheckpointData(nameData, checkPointValue);
    }

    void GetCheckpointData(List<ExcelReader> nameData, string checkpoint)
    {
        checkpointData = new List<ExcelReader>();
        foreach (ExcelReader er in nameData)
        {
            if(er.checkpoint == checkpoint)
            {
                checkpointData.Add(er);
            }
        }
        Debug.Log(checkpointData[0].type.Trim().Equals("Loop".Trim()) );
        if(checkpointData[0].type.Trim().Equals("Loop".Trim()))
        {
            loop(checkpointData);
            looping = true;
        }
        //textDisplayer.GetComponent<DialogueManager>().ReceiveCurrentCheckPointInfo(checkpointData);
    }

    //loop current test data
    void loop(List<ExcelReader> data)
    {
        ExcelReader element = data[Random.Range(0, data.Count)];
        textDisplayer.GetComponent<DialogueManager>().createTheTextBoxes(element.text);
        lastLoop = Time.time;
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

    public CheckPointProgress GetCheckpointProgress(){
        return checkpoint;
    }
}
