using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Applies a Hover effect to UI as long as it's enabled.
/// <summary>
public class UIHoverEffect : MonoBehaviour
{
    public bool hoverEnabled = true;

    public Vector2 original_pos;
    private Vector2 target_pos;
    private Vector2 damp_velocity;

    public float smooth = 1.5f;
    public float hover_strength = 50f;

    void Start(){
        original_pos = transform.GetComponent<RectTransform>().localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(hoverEnabled){
            target_pos = new Vector2(
                Random.Range(-hover_strength, hover_strength) + original_pos.x, 
                Random.Range(-hover_strength, hover_strength) + original_pos.y);

            transform.GetComponent<RectTransform>().localPosition = Vector2.SmoothDamp(
                transform.GetComponent<RectTransform>().localPosition,
                target_pos,
                ref damp_velocity,
                smooth
                );
        }
    }

    public void SetHover(bool value)
    {
        hoverEnabled = value;
    }

    ///<summary>
    ///Needs to be called after being moved by player
    ///<summary>
    public void ResetOriginalPos(){
        original_pos = transform.GetComponent<RectTransform>().localPosition;
    }
}
