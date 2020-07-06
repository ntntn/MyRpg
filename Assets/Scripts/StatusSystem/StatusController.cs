using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusController : MonoBehaviour
{
    public delegate void OnStatsChanged(string[] statNames, float[] values);
    //public delegate void OnStateChanged(State state);
    public event OnStatsChanged OnStatsChangedEvent;
    //public event OnStateChanged OnStateChangedEvent;

    public delegate void Method(StatusEffect effect);
    public event Method OnEffectApplyEvent;
    public event Method OnEffectTickEvent;
    public event Method OnEffectExitEvent;

    float tickTime;
    float startTickTime;
    float lastTickTime;

    List<StatusEffect> statusEffects;

    void OnEnable()
    {
        //OnEffectApplyEvent += GetComponent<UiController>().OnEffectApply;
        //OnEffectTickEvent += GetComponent<Character>().OnStatsChanged;
        //OnEffectExitEvent += GetComponent<StateController>().OnStateChanged;
    }

    //public void OnStatusEffectAdded(StatusEffect effect)
    //{
    //    statusEffects.Add(effect);
    //    effect.OnApply(this);
    //}

    //public void Update()
    //{
    //    foreach (var effect in statusEffects)
    //    {
    //        if (effect.duration <= 0)
    //        {
    //            statusEffects.Remove(effect);
    //            effect.OnExit(this);
    //            continue;
    //        }

    //        effect.duration -= Time.deltaTime;
    //    }

    //    if (Time.time >= lastTickTime + tickTime)
    //    {
    //        foreach (var effect in statusEffects)
    //        {
    //            effect.OnTick(this);
    //            OnEffectTickEvent(effect);
    //            //OnStatsChangedEvent()
    //        }
    //    }
    //}
}
