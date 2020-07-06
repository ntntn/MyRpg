using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkillController : MonoBehaviour
{    
    public List<Skill> skills;

    public string enemyTag;

    public List<float> cooldowns;

    public Skill skill;

    public Transform handTransform;

    public float castStartedTime;
    public float castProgressTime;

    public FloatEvent OnCastStarted;
    public FloatEvent OnCastFinished;
    public UnityEvent OnCastCanceled;

    public FloatEvent OnBlinkUsed;

    //current target (can be changed by OnMouseEnter on other characters)
    public GameObject target;
    //real casting skill target
    public GameObject skillTarget;

    [SerializeField]
    public Vector3 mouseTargetPos;

    public float attackRange;

    public bool Casting;

    public IntEvent OnSkillUsed;

    public void AddSkill(Skill skill)
    {
        this.skills.Add(skill);
        this.cooldowns.Add(0);
    }

    public void HandleDeath()
    {
        CancelCasting();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (this.tag == "Player")
        {
            this.enemyTag = "Enemy";
        }
        else
        {
            this.enemyTag = "Player";
        }


        for (int i = 0; i<skills.Count; i++)
        {
            cooldowns.Add(0);
        }

        var character = GetComponent<Character>();

        character.OnCastingDisabled.AddListener(new UnityAction(CancelCasting));
    }

    // Update is called once per frame
    void Update()
    {     
        if (skill != null)        
        {
            UpdateCasting();
        }

        HandleCooldowns();


        /*mouseTargetPos = Input.mousePosition;
        mouseTargetPos -= new Vector3(Screen.width / 2,0);
        mouseTargetPos -= new Vector3(0,Screen.height / 2);*/
    }

    void UpdateCasting()
    {
        if (Time.time < castStartedTime + skill.castTime)
        {
            HandleCastProgress();            
        }

        if (Time.time>=castStartedTime+skill.castTime)
        {
            
            HandleCastFinished();
        }     
    }

    public bool IsOnCooldown(Skill skill)
    {
        return cooldowns[skills.IndexOf(skill)] > 0;
    }

    void HandleCooldowns()
    {
        for (int i=0; i<cooldowns.Count; i++)
        {
            if (cooldowns[i]>0)
            {
                cooldowns[i] -= Time.deltaTime;
            }
        }
    }

    void HandleCastProgress()
    {
        castProgressTime += Time.deltaTime;
    }
    void HandleCastFinished()
    {
        skill.Trigger(this);
        var skillIndex = skills.IndexOf(skill);
        cooldowns[skillIndex] = skill.Cooldown;
        skill = null;
        Casting = false;
        OnCastFinished.Invoke(Time.time);
        OnSkillUsed.Invoke(skillIndex);
    }


    public void HandleMoved()
    {
        if (skill == null) return;
         
        if (!skill.CastWhileMoving)
        {
            CancelCasting();
        }
    }

    public void CancelCasting()
    {
        this.skill = null;
        Casting = false;
        OnCastCanceled.Invoke();
    }

    public void OnSkillPressed(int id)
    {
        if (id >= skills.Count) return;

        TryCasting(skills[id]);
    }

    public void TryCasting(Skill skill)
    {
        if (Casting && this.skill == skill) return;

        //if (Time.time>(castStartedTime + skill.castTime)/2)

        if (ValidateSkillCast(skill))
        {            
            BeginCasting(skill);
        }
    }

    bool ValidateSkillCast(Skill skill)
    {
        return cooldowns[skills.IndexOf(skill)] <= 0 && skill.ValidateSkillCast(this);
    }

    public void BeginCasting(Skill skill)
    {
        if (!GetComponent<Character>().CastingEnabled) return;

        if (skill.skillType == SkillType.Attack)
        {
            rotate_towards(2, this.gameObject, target);
        }

        CancelCasting();
        Casting = true;

        skillTarget = target;
        this.mouseTargetPos = Input.mousePosition;
        this.skill = skill;

        castStartedTime = Time.time;
        OnCastStarted.Invoke(skill.castTime);
    }


    public Vector3 GetTargetPos()
    {
        if (this.tag == "Player")
            return GetComponent<CharacterController>().GetTargetPos();
        else
        {
            return skillTarget.transform.position;
        }
    }

    public Vector3 GetMovementDirection() { return transform.forward; }

    void rotate_towards(float speed, GameObject obj, GameObject target)
    {
        obj.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(obj.transform.forward, new Vector3(target.transform.position.x, 0, target.transform.position.z) - new Vector3(obj.transform.position.x, 0, obj.transform.position.z), speed, 0));
    }
}


