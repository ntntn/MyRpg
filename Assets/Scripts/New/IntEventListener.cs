using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntEventListener : MonoBehaviour
{
    public IntGameEvent Event;
    public IntEvent Response;

    private void OnEnable()
    { Event.RegisterListener(this); }

    private void OnDisable()
    { Event.UnregisterListener(this); }

    public void OnEventRaised(int value)
    { Response.Invoke(value); }
}
