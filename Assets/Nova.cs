using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Nova : Skill
{
    [SerializeField]
    float Duration;

    [SerializeField]
    List<GameObject> appliedObjects;

    public float radius;

    private void Awake()
    {
        this.exactSkillType = ExactSkillType.Nova;
        radius = GetComponent<SphereCollider>().radius;
    }

    public override void Initialize(SkillController controller)
    {
        base.Initialize(controller);
        transform.position = user.transform.position;
        Invoke("OnSkillCompleted", Duration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == enemyTag)
        {
            if (!appliedObjects.Contains(other.gameObject))
            {
                OnHit(other.gameObject);
            }
            
            appliedObjects.Add(other.gameObject);
        }
    }

    public override void OnSkillCompleted()
    {
        base.OnSkillCompleted();
        appliedObjects = new List<GameObject>();
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
