using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonsController : MonoBehaviour
{
    Button[] buttons;
    void Start()
    {
        buttons = GetComponentsInChildren<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
