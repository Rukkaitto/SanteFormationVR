using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabeledButton : MonoBehaviour
{
    public string labelText;
    void Start()
    {
        GetComponentInChildren<TextMesh>().text = labelText;
    }
}