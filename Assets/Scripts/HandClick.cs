using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class HandClick : XRBaseInteractable
{
    [SerializeField] private float treshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;

    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    public UnityEvent onPressed, onReleased;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }


    // Update is called once per frame
    void Update()
    {
        if(!_isPressed && GetValue() + treshold >= 1)
        {
            Pressed();
        }

        if(_isPressed && GetValue() - treshold <= 0)
        {
            Released();
        }
    }

    private void Pressed()
    {
        _isPressed = true;
        onPressed.Invoke();
    }
    
    private void Released()
    {
        _isPressed = false;
        onReleased.Invoke();
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if(Math.Abs(value) < deadZone)
        {
            value = 0;
        }

        return Mathf.Clamp(value, -1f, 1f);
    }
}
