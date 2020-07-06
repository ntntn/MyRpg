using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{
    [SerializeField]
    private float health;

    public UnityEvent OnZeroHealth;

    public FloatEvent OnHealthChanged;

    public float Health { get => health; protected set { } }

    public void Damage(float value)
    {
        Health -= value;
        OnHealthChanged.Invoke(value);

        if (Health <= 0)
        {
            OnZeroHealth.Invoke();
            return;
        }
    }

    public void TakeDamage(float value)
    {
        Health -= value;
        OnHealthChanged.Invoke(value);

        if (Health <= 0)
        {
            OnZeroHealth.Invoke();
            return;
        }
    }
}
