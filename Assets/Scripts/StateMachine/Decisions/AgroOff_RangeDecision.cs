using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/AgroOff_Range")]
public class AgroOff_RangeDecision : Decision
{
    float hp;

    public override bool Decide(StateMachine controller)
    {
        //return ((controller.target.transform.position - controller.character.transform.position).magnitude > controller.GetComponent<FieldOfView>().viewRadius * 2);
        return false;
    }
}