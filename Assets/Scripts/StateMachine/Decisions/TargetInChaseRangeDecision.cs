using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/TargetInChaseRange")]
public class TargetInChaseRangeDecision : Decision
{

    public override bool Decide(StateMachine controller)
    {
        Debug.DrawRay(controller.transform.position, controller.transform.forward.normalized * controller.GetComponent<Enemy>().chaseRange, Color.red);

        if ((controller.target.transform.position - controller.character.transform.position).magnitude <= controller.GetComponent<Enemy>().chaseRange)
            return true;
        else return false;
    }
}
