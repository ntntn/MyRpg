using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : Skill
{
    [SerializeField]
    float duration;

    [SerializeField]
    List<SkillEffects> updatingOnCollisionEffects;

    [SerializeField]
    List<GameObject> targets;


    public override void Initialize(SkillController controller)
    {
        base.Initialize(controller);
        targets = new List<GameObject>();

        /*RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(controller.mouseTargetPos);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            transform.position = new Vector3(hit.point.x,1,hit.point.z);
        }*/

        transform.position = controller.GetTargetPos();

        Invoke("OnSkillCompleted", this.duration);
    }


    public override void OnSkillCompleted()
    {
        base.OnSkillCompleted();

        ResetSkillEffectsDuration(updatingOnCollisionEffects);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == enemyTag)
        {
            targets.Add(other.gameObject);
            OnHit(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var c = other.gameObject;
        if (targets.Contains(c))
        {
            var ch = c.GetComponent<Character>();

            Debug.Log("RemoveEffect");

            foreach (var e in updatingOnCollisionEffects)
            {
                ch.RemoveEffect(GetSkillEffectByType(e).effectInstance);
            }
 
            targets.Remove(c);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (targets.Count == 0) return;
        foreach (var t in targets)
        {
            EffectsTick(t, updatingOnCollisionEffects);
            Debug.Log("tick");
        }*/
    }
}
