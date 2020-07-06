using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EffectType
{
    buff,
    debuff
}

[CreateAssetMenu]
public class StatusEffect : ScriptableObject
{
    public float duration;
    public bool stackable;
    public float maxStacks;
    public bool scalable;
}

public enum StatusEffectType
{
    StatChange,
    HealthChange,
    Stun,
    Blind,
    Size
}

public enum BuffEnum
{
    Buff,
    Debuff
}

public class Buff: ScriptableObject
{
    public BuffEnum BuffEnum;
    public List<StatusEffect> statusEffects;
    public GameObject effectPrefab;
}

public class BuffController: MonoBehaviour
{
    public delegate void MethodContainer(StatusEffect effect);
    event MethodContainer OnStatusEffectGained;

    public delegate void BuffContainer(Buff buff);
    event BuffContainer OnBuffGained;

    [SerializeField]
    List<Buff> buffs;

    private void OnEnable()
    {
        //OnStatusEffectGained += GetComponent<StatusController>().OnStatusEffectAdded;
    }
    public void AddBuff(Buff buff)
    {
        buffs.Add(buff);
        OnBuffGained(buff);

        foreach (var effect in buff.statusEffects)
        {
            OnStatusEffectGained(effect);
        }
    }

    private void Update()
    {
        
    }

}



[System.Serializable]
public struct StatScale
{
    public string name;
    public float modifier;
}
