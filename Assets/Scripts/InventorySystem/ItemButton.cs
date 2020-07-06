using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemButton : MonoBehaviour
{
    public UnityEvent leftClick;
    public UnityEvent middleClick;
    public UnityEvent rightClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Left click");
            leftClick.Invoke();
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            Debug.Log("Middle click");
            middleClick.Invoke();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Right click");
            rightClick.Invoke();
        }
    }
}
