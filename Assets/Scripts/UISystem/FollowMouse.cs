using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowMouse : MonoBehaviour
{
    private Vector2 velocity;

    public float smooth = 2;

    public void RectFollowMouse(RectTransform rectTransform)
    {
        Debug.Log("Following...");
        Vector2 mousePos = Input.mousePosition;

        rectTransform.localPosition = Vector2.SmoothDamp(
            rectTransform.localPosition,
            mousePos,
            ref velocity,
            smooth);     
    }
}
