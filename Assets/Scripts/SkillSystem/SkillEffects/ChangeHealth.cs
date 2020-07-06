using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChangeHealth : SkillEffect
{
        
    public float minValue;
    
    public float maxValue;

    public override void Apply(GameObject user, GameObject entity)
    {
        var character = entity.GetComponent<Character>();
        var value = Random.Range(minValue, maxValue);
        character.TakeDamage(user, value);
    }
}
