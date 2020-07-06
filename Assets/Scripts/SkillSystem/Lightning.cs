using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Lightning : Skill
{
    [SerializeField]
    public float test;

    [SerializeField]
    GameObject rawPrefab;

    [SerializeField]
    float skillUsedTime;

    [SerializeField]
    float destroyDelay;

    public override void Initialize(SkillController controller)
    {
        base.Initialize(controller);
        this.skillUsedTime = Time.time;

        transform.position = user.transform.position;
        var lightningTransform = GetComponent<LightningRotController>().lightningTransform;
        lightningTransform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, new Vector3(target.transform.position.x, 0, target.transform.position.z) - new Vector3(transform.position.x, 0, transform.position.z), 5, 0));
        lightningTransform.localScale = new Vector3((target.transform.position - transform.position).magnitude / 10, transform.localScale.y, transform.localScale.z);

        Invoke("OnSkillCompleted", destroyDelay);
    }

    void Start()
    {
        //AssignPrefabTransform(this.gameObject, user, target);
        /*transform.position = user.transform.position;
        var lightningTransform = GetComponent<LightningRotController>().lightningTransform;
        lightningTransform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, new Vector3(target.transform.position.x, 0, target.transform.position.z) - new Vector3(transform.position.x, 0, transform.position.z), 5, 0));
        lightningTransform.localScale = new Vector3((target.transform.position - transform.position).magnitude / 10, transform.localScale.y, transform.localScale.z);*/
    }

    private void FixedUpdate()
    {
        /*if (Time.time >= skillUsedTime + destroyDelay)
        {
            OnSkillCompleted();
        }*/
    }


    public override bool ValidateSkillCast(SkillController controller)
    {
        return controller.target != null;
    }


    void AssignPrefabTransform(GameObject prefab, GameObject user, GameObject target)
    {
        prefab.transform.position = user.transform.position;
        var lightningTransform = prefab.GetComponent<LightningRotController>().lightningTransform;
        lightningTransform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, new Vector3(target.transform.position.x, 0, target.transform.position.z) - new Vector3(transform.position.x, 0, transform.position.z), 5, 0));
        lightningTransform.localScale = new Vector3((target.transform.position - transform.position).magnitude / 10, transform.localScale.y, transform.localScale.z);
    }

    void Update()
    {
        
    }
}
