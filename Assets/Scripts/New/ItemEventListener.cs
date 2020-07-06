using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemEventListener : MonoBehaviour
{
    public ItemGameEvent Event;
    public ItemEvent Response;

    private void OnEnable()
    { Event.RegisterListener(this); }

    private void OnDisable()
    { Event.UnregisterListener(this); }

    public void OnEventRaised(Item value)
    { Response.Invoke(value); }
}
