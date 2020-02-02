using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ2020.Utility;
using UnityEngine.SceneManagement;

public class RobotOne : MonoBehaviour, IPatient
{
    //Referneces to both because we use them quite frequently.
    GameStateSystem gameStateSystem;
    StateSystem stateSystem;
    GameObject allText;
    GameObject textDisplayer;

    public float messageInterval = 1f;

    int firstCheckPoint = 3, secondCheckPoint = 3, thirdCheckPoint = 3; // 1 = success, 2 = fail, 3 = inProgress

    public enum RoboDialogueStates { Setup, DetermineCheckpoint, WaitToDisplayText, DisplayText, Over, Idle }; //The states that could occur for the moving of the object
    public RoboDialogueStates currentRoboDState = RoboDialogueStates.Setup;
    float timeOnStateChange = 0.0f;
    string checkPointValue = "None";

    List<ExcelReader> nameData, playerData;
    List<ExcelReader> checkpointData;

    //Enum for what checkpoint we're on
    //Starts with None, counts up to One, then Two, all the way to Finished.
    public CheckPointProgress checkpoint = CheckPointProgress.None;

    //Type of robot this is.
    public RobotType robot = RobotType.ShyBot;

    //Goals for different checkpoints
    public float volumeGoal = 80;

    public float brightnessGoal = 80;

    int currentLinearCheck = 0;

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
        switch(currentRoboDState)
        {
            case RoboDialogueStates.Setup:
                if (data.doneParsingData())
                {
                    SetupTextData();
                    setCurrentState(RoboDialogueStates.DetermineCheckpoint);
                }
                break;
            case RoboDialogueStates.DetermineCheckpoint:
                CheckPointCompletionCheck();
                GetCheckpointData(nameData, checkPointValue);
                //have a check to see if reached last checkpoint
                if(checkPointValue.Trim().Equals("Three".Trim()))
                {
                    setCurrentState(RoboDialogueStates.Over);
                }
                else
                {
                    setCurrentState(RoboDialogueStates.WaitToDisplayText);
                }

                break;

            case RoboDialogueStates.WaitToDisplayText:
                if(Time.time - timeOnStateChange > messageInterval)
                {
                    setCurrentState(RoboDialogueStates.DisplayText);
                }
                break;
            case RoboDialogueStates.DisplayText:
                if (checkpointData[0].type.Trim().Equals("Loop".Trim()))
                {
                    loop(checkpointData);
                }
                else if(checkpointData[0].type.Trim().Equals("Linear".Trim()))
                {
                    linear(checkpointData);
                }
                setCurrentState(RoboDialogueStates.DetermineCheckpoint);
                break;

            case RoboDialogueStates.Over:
                if(Time.time - timeOnStateChange > 3)
                {
                    Complete();
                    setCurrentState(RoboDialogueStates.Idle);
                }
                break;

            case RoboDialogueStates.Idle:
                break;
        }


        //if(looping)
        //{
        //    if(Time.time - lastLoop > 5.0)
        //    {
        //        loop(checkpointData);
        //    }
        //}
    }



    void SetupTextData()
    {
       //ParseCSV data = allText.GetComponent<ParseCSV>();
        nameData = data.GetDataByName("ShyRobot");
        playerData = data.GetDataByName("Player");
        SetupCheckPoint();
        //Debug.Log(nameData[0].speaker);

    }

    void SetupCheckPoint()
    {
        checkPointValue = "";

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
        //Debug.Log(checkpointData[0].type.Trim().Equals("Loop".Trim()) );
        //if(checkpointData[0].type.Trim().Equals("Loop".Trim()))
        //{
        //    loop(checkpointData);
        //    looping = true;
        //}
        //textDisplayer.GetComponent<DialogueManager>().ReceiveCurrentCheckPointInfo(checkpointData);
    }

    //loop current test data
    void loop(List<ExcelReader> data)
    {
        ExcelReader element = data[Random.Range(0, data.Count)];
        textDisplayer.GetComponent<DialogueManager>().createTheTextBoxes(element.text);
        //lastLoop = Time.time;
    }

    void linear(List<ExcelReader> data)
    {
        if(currentLinearCheck < data.Count)
        {
            ExcelReader element = data[currentLinearCheck];
            textDisplayer.GetComponent<DialogueManager>().createTheTextBoxes(element.text);
        }
        else
        {
            if(checkPointValue.Trim().Equals("One".Trim()))
            {
                FailedSecondCheckPoint();
            }
            else if (checkPointValue.Trim().Equals("Two".Trim()))
            {
                FailedThirdCheckPoint();
            }

        }

        currentLinearCheck += 1;
    }

    void CheckPointCompletionCheck()
    {
        switch (checkpoint)
        {
            case CheckPointProgress.None:
                if(isFirstCheckpoint())
                {
                    PlayerResponse();
                    firstCheckPoint = 1;
                    currentLinearCheck = 0;
                    //Call the Individual Success Response for Success
                    checkpoint = CheckPointProgress.One;
                }
                break;
            case CheckPointProgress.One:
               
                if (isSecondCheckpoint())
                {
                    Debug.Log("checkpoint 2 bab,...");
                    PlayerResponse();
                    secondCheckPoint = 1;
                    currentLinearCheck = 0;
                    checkpoint = CheckPointProgress.Two;
                }
                break;
            case CheckPointProgress.Two:
                if (isThirdCheckpoint())
                {
                    PlayerResponse();
                    checkpoint = CheckPointProgress.Three;
                    currentLinearCheck = 0;
                }
                break;
            case CheckPointProgress.Three:
                break;
        }
        SetupCheckPoint();

    }

    void FailedSecondCheckPoint()
    {
        secondCheckPoint = 2;
        string text = data.allData[23].text;
        checkpoint = CheckPointProgress.Two;
        textDisplayer.GetComponent<DialogueManager>().createPlayerTextBoxes(text);
        currentLinearCheck = 0;
        SetupCheckPoint();
    }

    void FailedThirdCheckPoint()
    {
        thirdCheckPoint = 2;
        string text = data.allData[35].text;
        checkpoint = CheckPointProgress.Three;
        textDisplayer.GetComponent<DialogueManager>().createPlayerTextBoxes(text);
        currentLinearCheck = 0;
        SetupCheckPoint();
    }

    void PlayerResponse ()
    {
        List<string> responses = new List<string>();
        foreach (ExcelReader er in playerData)
        {
            //Debug.Log(er.special);
            if (er.checkpoint.Trim().Equals(checkPointValue.Trim()) && er.special.Trim().Equals("Ending".Trim()))
            {
                responses.Add(er.text);
            }
        }
        string response = responses[Random.Range(0, responses.Count)];
        textDisplayer.GetComponent<DialogueManager>().createPlayerTextBoxes(response);
    }

    void GameOver ()
    {
        textDisplayer.GetComponent<DialogueManager>().createPlayerTextBoxes("Thank you for getting your repairs. Hopefully it helps");
    }


    public void Init()
    {

    }

    public void Complete()
    {
        SceneManager.LoadScene(3);
    }

    public bool isFirstCheckpoint()
    {
        //This robot needs volume tuned up to 80, around that value it will be good.
        if(gameStateSystem.isSimilar(gameStateSystem.GetValue(GGJ2020.Utility.GameEnum.Volume), volumeGoal)){
            stateSystem.SetFlag(FlagEnum.Checkpoint1, true);
            return true;
        }
        return false;
    }

    public bool isSecondCheckpoint()
    {
        //This robot needs the screen to cover his face to move on. Check for the flag.
        if(stateSystem.IsFlag(GGJ2020.Utility.FlagEnum.FaceCovered)){
            stateSystem.SetFlag(FlagEnum.Checkpoint2, true);
            return true;
        }
        return false;
    }

    public bool isThirdCheckpoint()
    {
        if(gameStateSystem.isSimilar(gameStateSystem.GetValue(GGJ2020.Utility.GameEnum.Brightness), brightnessGoal)){
            stateSystem.SetFlag(FlagEnum.Checkpoint3, true);
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

    /// <summary>
    /// update the current Typing State.
    /// </summary>
    /// <param name="newState"></param>
    public void setCurrentState(RoboDialogueStates newState)
    {
        currentRoboDState = newState;
        timeOnStateChange = Time.time;
    }

    /// <summary>
    /// check how much time has passed since the last state change.
    /// </summary>
    /// <returns></returns>
    public float getStateElapsed()
    {
        return Time.time - timeOnStateChange;
    }
}
