using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDOT : Skill
{
    [SerializeField]
    float Duration;

    public override bool ValidateSkillCast(SkillController controller)
    {
        return controller.target != null;
    }

    public override void Initialize(SkillController controller)
    {
        base.Initialize(controller);
        transform.position = target.transform.position;
        transform.SetParent(target.transform);
        OnHit(target);
        Invoke("OnSkillCompleted", Duration);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
