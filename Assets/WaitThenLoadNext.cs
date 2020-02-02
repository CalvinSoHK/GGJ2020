using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitThenLoadNext : MonoBehaviour
{
    float timer;
    public float time_to_wait;

    void Start()
    {
        timer = time_to_wait;
    }

    void Update()
    {
        if(timer <= 0)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
