using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreThenLoadBack : MonoBehaviour
{
    GameStateSystem gameStateSystem;
    StateSystem stateSystem;
    int score = 0;

    public float wait_time = 3f;
    private float timer;

    public Animator animator;

    void Start()
    {
        gameStateSystem = SystemCache.Instance.gameStateSystem;
        stateSystem = SystemCache.Instance.stateSystem;

        score = ScorePlayer();
        timer = wait_time;
    }

    public int ScorePlayer(){
        int score = 0;
        if(stateSystem.IsFlag(GGJ2020.Utility.FlagEnum.Checkpoint2)){
            score++;
        }
        if(stateSystem.IsFlag(GGJ2020.Utility.FlagEnum.Checkpoint3)){
            score++;
        }
        return score;
    }

    void Update(){
        if(timer <= 0){
            if(score == 0){
                animator.SetTrigger("BadScore");
            }
            else if(score == 1){
                animator.SetTrigger("NeutralScore");
            }
            else{
                animator.SetTrigger("GoodScore");
            }
        }
        else{
            timer -= Time.deltaTime;
        }
    }

    public void LoadBack(){
        gameStateSystem.ResetDict();
        stateSystem.ResetDict();
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += UnloadScene;
    }

    public void UnloadScene(Scene scene, LoadSceneMode mode){
        SceneManager.sceneLoaded -= UnloadScene;
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
        SceneManager.UnloadScene(SceneManager.GetSceneByBuildIndex(3));
    }
}
