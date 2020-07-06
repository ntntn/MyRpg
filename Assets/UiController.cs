using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField]
    Slider castbar;
    [SerializeField]
    Slider healthbar;

    public bool updateCastbar;
    public bool updateHealthbar;
    void Start()
    {
        Character character = GetComponent<Character>();
        healthbar.maxValue = character.MaxHealth;
        healthbar.value = character.Health;

        var skillController = GetComponent<SkillController>();

        if (skillController)
        {
            skillController.OnCastStarted.AddListener(new UnityAction<float>(OnCastStarted));
            skillController.OnCastCanceled.AddListener(new UnityAction(OnCastStopped));
            skillController.OnCastFinished.AddListener(new UnityAction<float>(OnCastStopped));
        }


    }

    // Update is called once per frame
    void Update()
    {
        UpdateCastbar();
    }

    void UpdateCastbar()
    {
        if (!updateCastbar)
            return;

        if (castbar.value < castbar.maxValue)
            castbar.value += Time.deltaTime;
        else
        {
            castbar.value = 0;
            updateCastbar = false;
        }
    }

    public void OnDamaged(float value)
    {
        healthbar.value -= value;
    }

    public void OnCastStarted(float time)
    {
        castbar.maxValue = time;
        updateCastbar = true;
    }

    public void OnCastStopped()
    {
        castbar.value = 0;
        updateCastbar = false;
    }

    public void OnCastStopped(float v)
    {
        castbar.value = 0;
        updateCastbar = false;
    }
}
