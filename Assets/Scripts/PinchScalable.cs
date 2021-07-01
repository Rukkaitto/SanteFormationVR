using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PinchScalable : MonoBehaviour
{
    private OVRGrabbable _grabbable;
    public TextMeshProUGUI textMeshPro;
    private List<OVRGrabber> grabbers = new List<OVRGrabber>();
    private float scale;
    public float scaleFactor = 1;
    void Start()
    {
        _grabbable = GetComponent<OVRGrabbable>();
        scale = transform.localScale.x;
    }

    void Update()
    {
        GetGrabbers();
        Scale();
    }

    void GetGrabbers()
    {
        if (_grabbable.isGrabbed)
        {
            OVRGrabber grabber = _grabbable.grabbedBy;
            if (grabbers.Contains(grabber))
            {
                grabbers.Remove(grabber);
            }
            grabbers.Add(grabber);
        }
        else
        {
            //grabbers.Clear();
        }
    }

    void Log(String str)
    {
        String oldText = textMeshPro.text;
        textMeshPro.SetText(str + '\n' + oldText);
    }

    void Scale()
    {
        if (grabbers.Count == 2)
        {
            float newScale = scaleFactor * Vector3.Distance(grabbers[0].transform.position, grabbers[1].transform.position) + scale;
            Vector3 scaleVector = new Vector3(newScale, newScale, newScale);
            transform.localScale = scaleVector;
            Log(scaleVector.ToString());
        }
    }

}
