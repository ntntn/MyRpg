using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillEffect
{
    public GameObject user;

    public float tickCooldown;

    public float duration;

    public float lastTickTime;
    public float currentTickTime;

    public float currentDuration;

    public SkillEffect effectInstance;


    // Start is called before the first frame update
    public virtual void Apply(GameObject user, GameObject entity) { }

    public virtual bool Tick(Character character) 
    {
        if (currentDuration>duration)
        {
            OnDurationFinished(character);
            return false;
        }

        currentDuration += Time.deltaTime;

        if (Time.time < lastTickTime + tickCooldown) return false;


        lastTickTime = Time.time;
        

        return true;

    }

    public virtual void OnDurationFinished(Character character)
    {
        character.RemoveEffect(this);
    }
}

public enum SkillEffectType
{
    ChangeHealth,
    ChangeHealthOverTime,
    Frozen,
    ChangeStat,
    Knockback,
    Stun,
    Debuff
}

