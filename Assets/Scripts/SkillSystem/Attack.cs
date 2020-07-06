using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Skill
{
    
    // Start is called before the first frame update
    public override bool ValidateSkillCast(SkillController controller)
    {
        return controller.target != null;
    }

    public override void Initialize(SkillController controller)
    {
        base.Initialize(controller);
        var distance = target.transform.position - user.transform.position;


        if (distance.magnitude <= controller.attackRange)
        {
            
            OnHit(target);            
        }

        OnSkillCompleted();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
