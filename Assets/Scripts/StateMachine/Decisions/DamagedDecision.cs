using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/DamagedChase")]
public class DamagedChase : Decision
{
    float hp;

    public override bool Decide(StateMachine controller)
    {
        return controller.damaged;
    }
}