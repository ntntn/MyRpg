using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChangeHealthOverTime : SkillEffect
{        
    public float minValue;
    
    public float maxValue;

    

    public ChangeHealthOverTime(float tickCooldown, float duration, float minValue, float maxValue)
    {
        this.minValue = minValue;
        this.maxValue = maxValue;
        this.tickCooldown = tickCooldown;
        this.duration = duration;
    }


    public override void Apply(GameObject user, GameObject entity)
    {
        this.user = user;
        var character = entity.GetComponent<Character>();

        if (effectInstance == null)
        {
            effectInstance = new ChangeHealthOverTime(tickCooldown, duration, minValue, maxValue);
        }
        
        character.AddEffect(effectInstance);
        Tick(character);
    }

    public override bool Tick(Character character)
    {
        if (base.Tick(character) == false) return false;

        var value = Random.Range(minValue, maxValue);
        character.TakeDamage(user, value);

        return true;
    }
}
