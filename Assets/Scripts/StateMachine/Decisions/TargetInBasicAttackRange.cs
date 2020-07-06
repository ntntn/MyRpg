using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/TargetInBasicAttackRange")]
public class TargetInBasicAttackRange : Decision
{
    public override bool Decide(StateMachine controller)
    {
        if (controller.range <= controller.attackRange)
        {
            controller.navMeshAgent.isStopped = true;
            return true;
        }

        else

        {
            return false;
        }
    }
    void rotate_towards(float speed, GameObject obj, GameObject target)
    {
        obj.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(obj.transform.forward, new Vector3(target.transform.position.x, 0, target.transform.position.z) - new Vector3(obj.transform.position.x, 0, obj.transform.position.z), speed, 0));
    }
}
