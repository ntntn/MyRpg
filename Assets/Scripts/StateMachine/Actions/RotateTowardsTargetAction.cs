using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu (menuName = "PluggableAI/Actions/RotateTowardsTarget")]
public class RotateTowardsTargetAction : Action
{
    public override void Act(StateMachine controller)
    {
        if (!controller.character.RotationEnabled) return;

        /*if (controller.skillController.Casting)
        {
            if (controller.skill.skillType != SkillType.Attack) return;
        }*/

        rotate_towards(Time.deltaTime*4, controller.gameObject, controller.target);
    }

    void rotate_towards(float speed, GameObject obj, GameObject target)
    {
        obj.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(obj.transform.forward, new Vector3(target.transform.position.x, 0, target.transform.position.z) - new Vector3(obj.transform.position.x, 0, obj.transform.position.z), speed, 0));
    }
}
