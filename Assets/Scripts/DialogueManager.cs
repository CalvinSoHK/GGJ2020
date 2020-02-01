using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public enum DisplayTextState { Idle, Displaying, Skip, PlayerTyping, Reset, Stop }; //The states that could occur for typing
    public DisplayTextState currentTypingState;

    //Variables relevant to the current robot the player is dealing with
    public GameObject CurrentRobot;
    private TestRobot CurrentRobotScript;
    private Text CurrentRobotText;
    private BrunoMikoski.TextJuicer.JuicedText JuicedTextReference;

    void Start()
    {

    }

    void Update()
    {
        
    }

    /// <summary>
    /// Updates the Dialogue Manager's references to the current robot
    /// </summary>
    /// <param name="robot">Robot.</param>
    public void SetDisplayTextContainer(GameObject robot)
    {
        CurrentRobot = robot;
        CurrentRobotScript = CurrentRobot.GetComponent<TestRobot>();
        CurrentRobotText = CurrentRobotScript.RobotTextObject;
        JuicedTextReference = CurrentRobotText.GetComponent<BrunoMikoski.TextJuicer.JuicedText>();

        //Below should likely be moved into an appropriate State Manager
        ResetRobotDialogueEffect();
        UpdateRobotLine("Welcome to Isaac's repair shop");
        ShowRobotDialogue();

    }

    /// <summary>
    /// Updates the robot's line of dialogue.
    /// </summary>
    /// <param name="dialogue">Dialogue.</param>
    public void UpdateRobotLine(string dialogue)
    {
        CurrentRobotText.text = dialogue;
    }

    /// <summary>
    /// Will reset the effects on the robot dialogue's text.
    /// Note this will not change the content of the dialogue nor play the effect again.
    /// </summary>
    public void ResetRobotDialogueEffect()
    {
        JuicedTextReference.Restart();
    }

    /// <summary>
    /// Plays the Juiced Text effect associated with the text object.
    /// </summary>
    public void ShowRobotDialogue()
    {
        JuicedTextReference.Play();
    }
}
