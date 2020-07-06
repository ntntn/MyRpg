using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : CharacterController
{
    [SerializeField]
    GameObject target;

    float time1;
    float time2;
    bool flag;


    private void Update()
    {
        if (Time.time>=time1+3)
        {
            time1 = Time.time;
            OnSkillPressed.Invoke(0);
        }

    }

    public override Vector3 GetTargetPos()
    {
        return target.transform.position;
    }
}
