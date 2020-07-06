using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEnableDisableObject:MonoBehaviour
{
    [SerializeField]
    GameObject obj;

    public void Enable()
    {
        obj.SetActive(true);
    }

    public void Disable()
    {
        obj.SetActive(false);
    }
}
