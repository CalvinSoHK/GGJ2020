using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the current robot in the scene
/// </summary>
public class RobotManager : MonoBehaviour
{
    //The interface we use to work with robots.
    private IPatient cur_patient;

    //List of patients in our game
    public List<IPatient> patient_list;

    //Reference to what will load the next scene
    public Scene next_scene;

    //States for the manager
    enum ManagerState {
        Idle,
        FirstCheckpoint,
        SecondCheckpoint,
        ThirdCheckpoint,
        Complete
    }

    ManagerState state = ManagerState.Idle;

    public void NextState(){
        if((int)state < (int)(ManagerState.Complete)){
            state++;
        }
    }

    void Update(){
        switch(state){
            case ManagerState.Idle:
                cur_patient.Init();
                NextState();
                break;
            case ManagerState.FirstCheckpoint:
                if(cur_patient.isFirstCheckpoint()){
                    NextState();
                }
                break;
            case ManagerState.SecondCheckpoint:
                if(cur_patient.isSecondCheckpoint()){
                    NextState();
                }
                break;
            case ManagerState.ThirdCheckpoint:
                if(cur_patient.isThirdCheckpoint()){
                    NextState();
                }
                break;
            case ManagerState.Complete:
                SceneManager.LoadScene(next_scene.name);
                break;
            default:
                throw new System.Exception("Error: Reached manager state that's not implemented: " + state);
        }
    }
}
