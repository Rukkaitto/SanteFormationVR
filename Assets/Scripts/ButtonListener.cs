using System.Collections;
using System.Collections.Generic;
using OculusSampleFramework;
using UnityEngine;
using UnityEngine.Events;

public class ButtonListener : MonoBehaviour
{
    public UnityEvent proximityEvent;
    public UnityEvent contactEvent;
    public UnityEvent actionEvent;
    public UnityEvent defaultEvent;
    
    void Start()
    {
        GetComponent<ButtonController>().InteractableStateChanged.AddListener(InitiateEvent);
    }

    void InitiateEvent(InteractableStateArgs state)
    {
        if (state.NewInteractableState == InteractableState.ProximityState)
        {
            print("proximity");
            proximityEvent.Invoke();
        } else if (state.NewInteractableState == InteractableState.ContactState)
        {
            print("contact");
            contactEvent.Invoke();
        } else if (state.NewInteractableState == InteractableState.ActionState)
        {
            print("action");
            actionEvent.Invoke();
        }
        else
        {
            defaultEvent.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
