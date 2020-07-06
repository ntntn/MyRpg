using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreateEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.AddComponent<AnimationController>();
        this.gameObject.AddComponent<Enemy>();
        this.gameObject.AddComponent<SkillController>();
        this.gameObject.AddComponent<StateMachine>();
        this.gameObject.AddComponent<UiController>();
        this.gameObject.AddComponent<SelectionController>();
        this.gameObject.AddComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
