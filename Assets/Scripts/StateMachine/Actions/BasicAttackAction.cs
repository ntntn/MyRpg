using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Attack")]
public class BasicAttackAction : Action
{
    private float casttime = 0;

    private float time = 0; private bool started;

    public override void Act(StateMachine controller)
    {
        controller.navMeshAgent.isStopped = true;


            Attack(controller);

        RotateTowards(1.5f * Time.deltaTime, controller.gameObject, controller.character.target);
    }
    
    private void Attack(StateMachine controller)
    {
    }

    private void RotateTowards(float speed, GameObject obj, GameObject target)
    {
        obj.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(obj.transform.forward, new Vector3(target.transform.position.x, 0, target.transform.position.z) - new Vector3(obj.transform.position.x, 0, obj.transform.position.z), speed, 0));
    }
}
