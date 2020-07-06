using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action
{
    bool setup = false;
    Vector3 previousDestination;
    Vector3 currentDestination;

    public override void Act(StateMachine state_machine)
    {
        Patrol(state_machine);
    }

    private void Patrol(StateMachine state_machine)
    {
        //currentDestination = new Vector3(0,0);

        //if (currentDestination != previousDestination)
        //{
            //setup navigation
            //state_machine.CalculatePath(state_machine.wayPointList[state_machine.nextWayPoint]);
            //state_machine.SetupPath();
        //}

        //state_machine.MoveAlongPath();

        //previousDestination = currentDestination;


        

        //handle destination set
        state_machine.navMeshAgent.destination = state_machine.wayPointList[state_machine.nextWayPoint];
        state_machine.OnMoved.Invoke();

        //handle destination reached
        if (state_machine.navMeshAgent.remainingDistance <= state_machine.navMeshAgent.stoppingDistance && !state_machine.navMeshAgent.pathPending)
        {
            state_machine.OnMovementStopped.Invoke();

            if (state_machine.CheckIfCountDownElapsed(Random.Range(1,30)))
            {
                state_machine.nextWayPoint = (state_machine.nextWayPoint + 1) % state_machine.wayPointList.Count;
                state_machine.stateTimeElapsed = 0;
            }
        }
    }
}