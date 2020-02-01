using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TestRobot : MonoBehaviour
{
    // Start is called before the first frame update
    public DialogueManager DialogueManager;
    public Text RobotTextObject;
    void Start()
    {
        DialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            DialogueManager.SetDisplayTextContainer(this.gameObject);
        }
    }
}
