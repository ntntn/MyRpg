using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationController : MonoBehaviour
{

    Animator animator;

    float animSpeed;

    void Awake()
    {
        animator = GetComponent<Animator>();
        var skillController = GetComponent<SkillController>();
        var stateController = GetComponent<StateMachine>();
        var character = GetComponent<Character>();

        if (skillController)
        {
            skillController.OnCastStarted.AddListener(new UnityAction<float>(OnCastStarted));
            skillController.OnCastCanceled.AddListener(new UnityAction(OnCastStopped));
            skillController.OnCastFinished.AddListener(new UnityAction<float>(OnCastStopped));
        }

        if (stateController)
        {
            stateController.OnMoved.AddListener(new UnityAction(OnMoved));
            stateController.OnMovementStopped.AddListener(new UnityAction(OnMovementStopped));
        }

        if (character)
        {
            character.OnZeroHealth.AddListener(new UnityAction(OnDeath));
        }
    }

    public void HandleAnimationEnabled()
    {
        animator.speed = animSpeed;
    }

    public void HandleAnimationDisabled()
    {
        animSpeed = animator.speed;
        animator.speed = 0;
    }

    public void HandleCastCanceled()
    {
        OnCastStopped();
    }

    public void OnAttack()
    {
        animator.SetTrigger("Attack");
    }

    public void OnCastStarted()
    {
        animator.SetBool("Casting", true);
    }

    public void OnCastStarted(float v)
    {
        animator.SetBool("Casting", true);
    }

    public void OnCastStopped()
    {
        animator.SetBool("Casting", false);
    }

    public void OnCastStopped(float v)
    {
        animator.SetBool("Casting", false);
    }

    public void OnDeath()
    {
        animator.SetBool("OnDeath",true);
    }

    public void OnMoved()
    {
        animator.SetBool("Running",true);
    }

    public void OnMovementStopped()
    {
        animator.SetBool("Running", false);
    }

}
