using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabeledButton : MonoBehaviour
{
    public string labelText;
    void Start()
    {
        SetText(labelText);
    }

    public void SetText(string txt)
    {
        GetComponentInChildren<TextMesh>().text = txt;
    }
}