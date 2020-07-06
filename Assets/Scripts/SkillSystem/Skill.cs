using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ExactSkillType
{
    Attack,
    Blink,
    Nova,
    AOE
}

public enum SkillType
{
    Spell,
    Attack
}

public class Skill : MonoBehaviour
{
    public float castTime;
    public GameObject user;
    public GameObject target;

    public ExactSkillType exactSkillType;

    public Sprite Sprite;

    public SkillType skillType;

    public bool CastWhileMoving;


    public List<SkillEffects> OnHitEffects;

    public float Cooldown;

    public float minRangeToTarget;

    public float skillPointsCost = 1;

    public string enemyTag;



    IDestroyableMonobehaviour mono;
    IPoolObject poolObject;

    public virtual void Initialize(SkillController controller)
    {
        this.target = controller.skillTarget;
        this.user = controller.gameObject;
        this.enemyTag = controller.enemyTag;
    }

    void Start()
    {
        poolObject = GetComponent<IPoolObject>();
    }

    public void OnHit(List<GameObject> targets)
    {
        foreach (var e in OnHitEffects)
        {
            foreach (var t in targets)
            {
                //e.Apply(t);
            }            
        }
    }

    //Apply
    public void OnHit(GameObject target)
    {
        foreach (var e in OnHitEffects)
        {
            switch (e.skillEffectType)
            {
                case SkillEffectType.ChangeHealth:
                    e.changeHealth.Apply(user, target);
                    break;

                case SkillEffectType.ChangeHealthOverTime:
                    e.changeHealthOverTime.Apply(user, target);
                    break;

                case SkillEffectType.Frozen:
                    e.frozen.Apply(user, target);
                    break;

                default:
                    break;
            }
        }
    }
    public void EffectsTick(Character target, List<SkillEffects> skillEffects)
    {
        foreach (var e in skillEffects)
        {
            SkillEffect effect = default;

            switch (e.skillEffectType)
            {
                case SkillEffectType.ChangeHealth:
                    effect = e.changeHealth;
                    break;
                        
                case SkillEffectType.ChangeHealthOverTime:
                    effect = e.changeHealthOverTime;
                    break;

                case SkillEffectType.Frozen:
                    effect = e.frozen;
                    break;

                default:
                    break;
            }

            effect.user = this.user;
            effect.Tick(target);

            Debug.Log($"EffectsTick: {effect}");
        }
    }

    protected SkillEffect GetSkillEffectByType(SkillEffects e)
    {
        SkillEffect effect = default; ;

        switch (e.skillEffectType)
        {
            case SkillEffectType.ChangeHealth:
                effect = e.changeHealth;
                break;

            case SkillEffectType.ChangeHealthOverTime:
                effect = e.changeHealthOverTime;
                break;

            case SkillEffectType.Frozen:
                effect = e.frozen;
                break;

            default:
                break;
        }

        return effect;
    }


    public void Trigger(SkillController controller)
    {
        var skillObject = PoolManager.GetObject(this.gameObject.name, Vector3.zero, Quaternion.identity).GetComponent<Skill>();
        //var skillObject = GameObject.Instantiate(this);
        skillObject.Initialize(controller);
        skillObject.enabled = true;
        //skillObject.test();
    }

    public virtual bool ValidateSkillCast(SkillController controller)
    {
        return true;
    }

    public virtual void OnSkillCompleted()
    {
        this.enabled = false;
        GetComponent<IPoolObject>().ReturnToPool();

        ResetSkillEffectsDuration(onTriggerEffects);


        //Destroy(this.gameObject,0.15f);
    }

    public void ResetSkillEffectsDuration(List<SkillEffects> effects)
    {
        foreach (var e in effects)
        {
            var effect = GetSkillEffectByType(e);
            effect.currentDuration = 0;
            effect.currentTickTime = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    [SerializeField]
    public List<SkillEffects> onTriggerEffects;

    public virtual Skill GetSkill()
    {
        return new Skill();
    }

    [System.Serializable]
    public struct SkillEffects
    {
        public SkillEffectType skillEffectType;
        [ConditionalHide("skillEffectType", SkillEffectType.ChangeHealth)]
        public ChangeHealth changeHealth;
        [ConditionalHide("skillEffectType", SkillEffectType.Debuff)]
        public SkillEffect debuff;
        [ConditionalHide("skillEffectType", SkillEffectType.ChangeHealthOverTime)]
        public ChangeHealthOverTime changeHealthOverTime;
        [ConditionalHide("skillEffectType", SkillEffectType.Frozen)]
        public Frozen frozen;
    }

}
