using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Frozen : SkillEffect
{
    Character character;

    IPoolObject prefabEffect;

    public Frozen(float duration, IPoolObject prefabEffect)
    {
        this.duration = duration;
        this.prefabEffect = prefabEffect;
    }


    public override void Apply(GameObject user, GameObject entity)
    {
        this.user = user;
        character = entity.GetComponent<Character>();

        var poolObj = PoolManager.GetObject("Frozen", new Vector3(character.transform.position.x, 0, character.transform.position.z)).GetComponent<IPoolObject>();
        character.AddEffect(new Frozen(duration,poolObj));
        
        poolObj.ReturnToPoolWithDelay(duration);

        character.OnDamaged.AddListener(new UnityAction<float>(HandleDamaged));

        character.MovementEnabled = false;
        character.RotationEnabled = false;
        character.CastingEnabled = false;
        character.AnimationEnabled = false;
        Tick(character);
    }



    public override void OnDurationFinished(Character character)
    {
        base.OnDurationFinished(character);

        prefabEffect.ReturnToPool();
        character.MovementEnabled = true;
        character.RotationEnabled = true;
        character.CastingEnabled = true;
        character.AnimationEnabled = true;
    }

    void HandleDamaged(float value)
    {
        if (Random.Range(0,100)<=50)
        {
            OnDurationFinished(character);
        }
    }

    public override bool Tick(Character character)
    {
        if (base.Tick(character) == false) return false;

        return true;
    }
}
