using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
    public virtual Vector3 GetTargetPos()
    {
        return Vector3.zero;
    }

    public UnityEvent OnPlayerMoved;
    public UnityEvent OnMovementStopped;

    public IntEvent OnSkillPressed;



    void Start()
    {
        this.OnSkillPressed.AddListener(GetComponent<SkillController>().OnSkillPressed);
    }


}
