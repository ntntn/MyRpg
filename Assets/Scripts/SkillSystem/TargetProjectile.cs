using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetProjectile : Skill
{
    [SerializeField]
    float speed;

    bool hit = false;
    bool completed = false;
    public override void Initialize(SkillController controller)
    {
        base.Initialize(controller);

        this.user = controller.gameObject;
        this.target = controller.skillTarget;

        var handTransform = controller.handTransform;
        if (handTransform == null)
        {
            transform.position = user.transform.position;
        }
        else
        {
            transform.position = handTransform.position;
        }
        
    }

    public override bool ValidateSkillCast(SkillController controller)
    {
        return controller.target != null;
    }

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = user.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (target.transform.position - transform.position);
        direction = new Vector3(direction.x, 0, direction.z);


        if (direction.normalized.magnitude >=direction.magnitude)
        {
            if (!hit)
            {
                OnHit(target);
                hit = true;
            }
            OnSkillCompleted();
        }

        transform.position += direction.normalized * speed * Time.deltaTime;
    }
}
