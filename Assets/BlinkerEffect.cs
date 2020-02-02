using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkerEffect : MonoBehaviour
{
    [SerializeField]
    Image image;

    private float timer;
    private float time_per_state = 0.75f;
    private bool isOn = true;

    void Update()
    {
        if(timer <= 0)
        {
            if (isOn)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
            }
            else
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
            }
            isOn = !isOn;
            timer = time_per_state;
        }
        else
        {
            timer -= Time.deltaTime;
        }

    }
}
