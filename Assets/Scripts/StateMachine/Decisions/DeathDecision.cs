using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Death")]

public class DeathDecision : Decision
{
    public override bool Decide(StateMachine controller)
    {
        /*if (controller.character.health_bar.value<=0)
        {
            return true;
        }

        else

        {
            return false;
        }*/
        return false;
    }
    void rotate_towards(float speed, GameObject obj, GameObject target)
    {
        obj.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(obj.transform.forward, new Vector3(target.transform.position.x, 0, target.transform.position.z) - new Vector3(obj.transform.position.x, 0, obj.transform.position.z), speed, 0));
    }
}
