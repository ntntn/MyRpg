using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu(menuName = "PluggableAI/Actions/UseSkill")]
public class UseSkillAction : Action
{
    public override void Act(StateMachine controller)
    {

        controller.NavMeshIsStopped(true);

        controller.TryUseSkill();

    }

    private void RotateTowards(float speed, GameObject obj, GameObject target)
    {
        obj.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(obj.transform.forward, new Vector3(target.transform.position.x, 0, target.transform.position.z) - new Vector3(obj.transform.position.x, 0, obj.transform.position.z), speed, 0));
    }
}

class Cooldown
{
    public bool OnCooldown = false;

    float timeStarted;
    float timePassed;
    float cooldownTime;

    public void Initialize(float timeStarted, float cooldownTime)
    {
        this.timeStarted = timeStarted;
        this.cooldownTime = cooldownTime;
        this.OnCooldown = true;
        this.timePassed = 0;
    }
    
    public void Tick(float time)
    {
        if (timePassed >= cooldownTime)
        {
            this.OnCooldown = false;
        }

        timePassed += time;
    }
}