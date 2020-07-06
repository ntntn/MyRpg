using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Chase")]
public class ChaseDecision : Decision
{

    public override bool Decide(StateMachine controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;
    }

    public Vector3 DirFromAngle(float angleInDegrees)
    {
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    private bool Look(StateMachine controller)
    {
        var colliders = Physics.OverlapSphere(controller.transform.position, controller.ChaseRadius);
        
        foreach (var c in colliders)
        {
            if (c.tag == controller.EnemyTag)
            {
                controller.target = c.gameObject;
                
                return true;
            }
        }

        return false;
    }
}