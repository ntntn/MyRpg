using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class StateMachine : MonoBehaviour
{
    
    public string EnemyTag;
    public float ChaseRadius;

    public State currentState, remainState, idleState, previousState; 
    public Character character;

    public GameObject target, previous_target; 
    public Character targetchar;

    public List<Vector3> wayPointList; 
    public float patrolRadius; 
    public NavMeshAgent navMeshAgent; 
    public int nextWayPoint;

    public float stateTimeElapsed; 
    public bool stateStarted;

    public float range;

    public float attackRange, attackCastTime;

    public UnityEvent OnMoved;
    public UnityEvent OnMovementStopped;

    public Skill skill;
    public int skillId;

    public bool damaged;

    [SerializeField]
    State chaseState;
    [SerializeField]
    State patrolState;
    [SerializeField]
    State deathState;

    public SkillController skillController;



    private void Awake()
    {
        character = GetComponent<Character>();
        character.OnMovementDisabled.AddListener(new UnityAction(HandleMovementDisabled));
        

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void HandleMovementDisabled()
    {
        navMeshAgent.SetDestination(transform.position);
        navMeshAgent.isStopped = true;
    }

    private void Start()
    {

        skillController = GetComponent<SkillController>();

        if (wayPointList.Count == 0)
            InitializeWaypoints();

        navMeshAgent.speed = character.movespeed;
        //navMeshAgent.SetDestination(new Vector3(40,0,28));
    }

    public void TryUseSkill()
    {
        if (character.CastingEnabled == false) return;

        skillController.target = this.target;
        skillController.TryCasting(this.skill);
    }

    private void FixedUpdate()
    {
        currentState.UpdateState(this);
    }

    public void HandleDamaged(GameObject damager)
    {

        if (currentState == idleState || currentState == patrolState)
        {
            this.target = damager;
            currentState = chaseState;
        }        
    }


    void InitializeWaypoints()
    {
        for (int i=0; i<Random.Range(1,20); i++)
        {
            wayPointList.Add(Random.insideUnitCircle*patrolRadius);
            wayPointList[i] += transform.position;
        }
    }

    public void HandleStateChanged()
    {
        navMeshAgent.isStopped = true;
    }


    public void NavMeshIsStopped(bool flag)
    {
        if (navMeshAgent.isStopped == flag)
        {
            return;
        }
        else
        {            
            navMeshAgent.isStopped = flag;
            OnMovementStopped.Invoke();
        }
    }


    private void OnEnable()
    {
    }


    public void HandleDeath()
    {
        OnMovementStopped.Invoke();
        skillController.HandleDeath();
        navMeshAgent.isStopped = true;
        currentState = deathState;
    }

    public void HandleMovementToPostiion(Vector3 pos)
    {
        
        navMeshAgent.destination = pos;
        //OnMoved.Invoke();
    }

    void OnDrawGizmos()
    {
        if (currentState != null)
        {
            Gizmos.color = currentState.GizmoColor;
            Gizmos.DrawWireSphere(transform.position, 0.5f);
        }
    }

    public void TransitionToState(State nextState)
    {
        if (nextState!=currentState)
        {
            currentState = nextState;
            OnExitState();
        }
    }
   

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
        stateStarted = false;
    }
}
