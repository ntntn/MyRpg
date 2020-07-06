using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Chase")]
public class ChaseAction : Action
{
    public override void Act(StateMachine controller)
    {
        if (!controller.character.MovementEnabled) return;

        if (controller.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Casting"))
        {
            Debug.Log("casting");
        }

        controller.NavMeshIsStopped(false);

        Chase(controller);  
    }

    private void Chase(StateMachine controller)
    {
        controller.HandleMovementToPostiion(controller.target.transform.position);
        controller.OnMoved.Invoke();
        

        if (DestinationReached(controller))
        {
            controller.OnMovementStopped.Invoke();
        }
    }

    bool DestinationReached(StateMachine controller)
    {
        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance)
        {
            return true;
        }

        return false;

    }

    void rotate_towards(float speed, GameObject obj, GameObject target)
    {
        obj.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(obj.transform.forward, new Vector3(target.transform.position.x, 0, target.transform.position.z) - new Vector3(obj.transform.position.x, 0, obj.transform.position.z), speed, 0));
    }
}
