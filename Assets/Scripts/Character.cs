using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Character : MonoBehaviour
{
    public UnityEvent OnZeroHealth;

    public delegate void MethodContainer(string[] names, float[] values);
    public event MethodContainer OnStatsChanged; 

    public GameObject target;

    public float AttackRange;

    //Stats
    [SerializeField]
    float health;
    [SerializeField]
    float maxHealth;
    /*[SerializeField]
    float strength;
    [SerializeField]
    float intelligence;
    [SerializeField]
    float dexterity;
    [SerializeField]
    float spellDamage;
    [SerializeField]
    float fireDamage;
    [SerializeField]
    float lightningDamage;*/


    [SerializeField]
    Transform weapon1Holder;

    [SerializeField]
    Transform weapon2Holder;

    private Weapon weapon1;
    private Weapon weapon2;
    private Armor body;
    private Armor shoulders;
    private Armor hands;
    private Armor belt;
    private Armor legs;
    private Armor boots;

    [SerializeField]
    private bool movementEnabled;
    [SerializeField]
    private bool rotationEnabled;
    [SerializeField]
    private bool castingEnabled;
    [SerializeField]
    private bool animationEnabled;

    public UnityEvent OnMovementDisabled;
    /*public UnityEvent OnMovementEnabled;
    public UnityEvent OnCastingEnabled;*/
    public UnityEvent OnCastingDisabled;
    public UnityEvent OnAnimationDisabled;
    public UnityEvent OnAnimationEnabled;


    public void Start()
    {
        this.movementEnabled = true;
        this.rotationEnabled = true;
        this.castingEnabled = true;
        this.animationEnabled = true;

        var animator = GetComponent<AnimationController>();
        OnAnimationEnabled.AddListener(new UnityAction(animator.HandleAnimationEnabled));
        OnAnimationDisabled.AddListener(new UnityAction(animator.HandleAnimationDisabled));
    }
    public void HandleMoved()
    {
        if (movementEnabled)
        {
            Move();
        }

        if (RotationEnabled)
        {
            UpdateRotation();
        }
    }

    void UpdateRotation()
    {
        if ((Input.GetAxisRaw("Horizontal") < 0)) { transform.rotation = Quaternion.Euler(0, -90, 0); }
        if (Input.GetAxisRaw("Horizontal") > 0) { transform.rotation = Quaternion.Euler(0, 90, 0); }
        if (Input.GetAxisRaw("Vertical") > 0) { transform.rotation = Quaternion.Euler(0, 0, 0); }
        if (Input.GetAxisRaw("Vertical") < 0) { transform.rotation = Quaternion.Euler(0, 180, 0); }
        if (Input.GetAxisRaw("Horizontal") > 0 && Input.GetAxisRaw("Vertical") > 0) { transform.rotation = Quaternion.Euler(0, 45, 0); }
        if (Input.GetAxisRaw("Horizontal") > 0 && Input.GetAxisRaw("Vertical") < 0) { transform.rotation = Quaternion.Euler(0, 135, 0); }
        if (Input.GetAxisRaw("Horizontal") < 0 && Input.GetAxisRaw("Vertical") < 0) { transform.rotation = Quaternion.Euler(0, -135, 0); }
        if (Input.GetAxisRaw("Horizontal") < 0 && Input.GetAxisRaw("Vertical") > 0) { transform.rotation = Quaternion.Euler(0, -45, 0); }
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        transform.position = transform.position + movement * Time.deltaTime * 6f;
    }

    [SerializeField]
    private List<SkillEffect> skillEffects;

    public void AddEffect(SkillEffect effect)
    {
        if (skillEffects.Contains(effect)) return;

        skillEffects.Add(effect);
    }
    public void RemoveEffect(SkillEffect effect)
    {
        Debug.Log("remove effect");
        Debug.Log(skillEffects.Contains(effect));
        skillEffects.Remove(effect);
    }

    public float movespeed;

    public Dictionary<Stats, float> statStringDict;


    public float Health { get => health; }
    public float MaxHealth { get => maxHealth; }
    public Weapon Weapon1 { get => weapon1; set => weapon1 = value; }
    public Weapon Weapon2 { get => weapon2; set => weapon2 = value; }
    public bool MovementEnabled
    {
        get => movementEnabled;
        set
        {
            if (value == false) OnMovementDisabled.Invoke();
            movementEnabled = value;
        }
    }
    public bool CastingEnabled
    {
        get => castingEnabled;
        set
        {
            if (value == false) OnCastingDisabled.Invoke();
            castingEnabled = value;
        }
    }

    public bool RotationEnabled { get => rotationEnabled; set => rotationEnabled = value; }
    public bool AnimationEnabled { get => animationEnabled;
        set
        {
            if (value == false) OnAnimationDisabled.Invoke(); else OnAnimationEnabled.Invoke();
            animationEnabled = value;
        }
    }

    public void EquipWeapon1(Weapon weapon)
    {
        this.weapon1 = weapon;
        EquipGameObject(weapon.prefab.name, weapon1Holder);
    }
    public void EquipWeapon2(Weapon weapon)
    {
        this.weapon2 = weapon;
        EquipGameObject(weapon.prefab.name, weapon2Holder);
    }

    void EquipGameObject(string name, Transform transform)
    {
        PoolManager.GetObject(name, transform.position - new Vector3(0, 0.15f, 0), transform.rotation).transform.SetParent(transform);
    }

    [SerializeField]
    public FloatEvent OnDamaged;

    public Vector3 direction;

    [SerializeField]
    public ObjEvent OnDamagedGO;

    [SerializeField]
    public ObjObjEvent OnDamagedFullParams;

    
    public void TakeDamage(float damage)
    {
        health -= damage;
        OnDamaged.Invoke(damage);

        if (health <= 0)
            OnZeroHealth.Invoke();        
    }

    public void TakeDamage(GameObject damager, float damage)
    {
        TakeDamage(damage);
        OnDamagedGO.Invoke(damager);
    }
    void OnEnable()
    {
        if (health == 0)
            health = 100;
        if (maxHealth == 0)
            maxHealth = 100;
    }


    void Update()
    {
        for (int i=0; i<skillEffects.Count; i++)
        {
            skillEffects[i].Tick(this);
        }
    }

}
