using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectState : MonoBehaviour
{
    [SerializeField]
    GameObject obj;

    bool objEnabled = false;

    public void ChangeState()
    {
        if (objEnabled)
        {
            obj.SetActive(false);
            objEnabled = false;
        }
        else
        {
            obj.SetActive(true);
            objEnabled = true;
        }
    }
}
