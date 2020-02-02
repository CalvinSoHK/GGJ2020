using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PullValue))]
public class SetText : MonoBehaviour
{
    private Text text;
    private PullValue pull;

    void Start(){
        text = GetComponent<Text>();
        pull = GetComponent<PullValue>();
    }

    void Update(){
        text.text = (Mathf.Round(pull.value * 10f) / 10f).ToString();
    }
}
