﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveScreenPanels : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public enum PanelStates { Idle, Clicked, Moving, CheckPosition, Stop }; //The states that could occur for the moving of the object
    public PanelStates currentPanelState;
 
    private Vector3 offset;

    float timeOnStateChange = 0.0f;

    //This should be a state manager
    private bool offsetCalculated = false;
    private bool movePanel = false;


    // Update is called once per frame
    void Update()
    { 
        switch(currentPanelState)
        {
            case PanelStates.Idle:

                break;

            case PanelStates.Clicked:
                CalculateOffset();
                setCurrentState(PanelStates.Moving);
                break;

            case PanelStates.Moving:
                MoveObject();
                break;

            case PanelStates.CheckPosition:
                this.RepositionObject();
                this.setCurrentState(PanelStates.Stop);
                break;

            case PanelStates.Stop:
                setCurrentState(PanelStates.Idle);
                break;


        }
        if (movePanel)
        {
            MoveObject();
        }
    }

    /// <summary>
    /// update the current Typing State.
    /// </summary>
    /// <param name="newState"></param>
    public void setCurrentState(PanelStates newState)
    {
        currentPanelState = newState;
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

    /// <summary>
    /// When the player clicks down on the object
    /// </summary>
    /// <param name="eventData">Event data.</param>
    public void OnPointerDown(PointerEventData eventData)
    {
        setCurrentState(PanelStates.Clicked);
    }

    //When the player releases the object
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("How many times here");
        setCurrentState(PanelStates.CheckPosition);
    }

    //If the panel ends up off screen we need to recenter it
    public void RepositionObject()
    {
        Vector2 panelPosition = this.transform.position;
        Vector2 panelDimensions = new Vector2(this.GetComponent<RectTransform>().sizeDelta.x, this.GetComponent<RectTransform>().sizeDelta.y);
        Vector2 screenDimensions = new Vector2(Screen.width, Screen.height);

        Vector2 sizeDelta = GetComponent<RectTransform>().sizeDelta;
        Vector2 canvasScale = new Vector2(this.GetComponentInParent<Canvas>().transform.localScale.x, this.GetComponentInParent<Canvas>().transform.localScale.y);

        Vector2 finalScale = new Vector2(sizeDelta.x * canvasScale.x, sizeDelta.y * canvasScale.y);

        float x = panelPosition.x, y = panelPosition.y;

        if (panelPosition.x + (panelDimensions.x / 2) > screenDimensions.x)
        {
            x = screenDimensions.x - (panelDimensions.x / 2);
        }
        else if(panelPosition.x - (panelDimensions.x / 2) < 0)
        {
            x = panelDimensions.x / 2;
        }

        if (panelPosition.y + (panelDimensions.y / 2) > screenDimensions.y)
        {
            y = screenDimensions.y - (panelDimensions.y / 2);
        }
        else if (panelPosition.y - (panelDimensions.y / 2) < 0)
        {
            y = panelDimensions.y / 2;
        }
        this.transform.position = new Vector2(x, y);
    }

    public void CalculateOffset()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 currentPanelPosition = transform.position;

        offset.x = (mousePosition.x - currentPanelPosition.x);
        offset.y = (mousePosition.y - currentPanelPosition.y);
        offset.z = (mousePosition.z - currentPanelPosition.z);
    }

    public void MoveObject()
    {
        transform.position = (Input.mousePosition - offset) ;
    }
}
