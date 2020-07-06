using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    public Skill skill;

    [SerializeField]
    GameObject tooltip;

    [SerializeField]
    GameObject player;

    [SerializeField]
    Text text;

    [SerializeField]
    int index;

    [SerializeField]
    IntGameEvent OnSkillPressed;

    float time;

    float coolDownTimeLeft;
    float cooldownTime;
    Text coolDownTextDisplay;
    Image image;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        text = tooltip.GetComponentInChildren<Text>();
        GetComponent<Button>().onClick.AddListener(new UnityAction(HandleClick));
        image = GetComponent<Image>();
        coolDownTextDisplay = GetComponentInChildren<Text>();
        cooldownFinished = true;
    }

    private void CoolDown()
    {
        coolDownTimeLeft -= Time.deltaTime;
        float roundedCd = Mathf.Round(coolDownTimeLeft);
        coolDownTextDisplay.text = roundedCd.ToString();
        image.fillAmount = (coolDownTimeLeft / cooldownTime);
        //image.fillAmount = (1/coolDownTimeLeft);
    }


    public void ChangeSkill(Skill skill)
    {
        this.skill = skill;
        image.sprite = skill.Sprite;
        coolDownTextDisplay.text = skill.Cooldown.ToString();
    }

    public void HandleCooldownStarted()
    {
        coolDownTimeLeft = skill.Cooldown;
        cooldownTime = skill.Cooldown;
        cooldownFinished = false;
    }

    bool cooldownFinished;

    private void Update()
    {
        if (coolDownTimeLeft>0)
        {
            CoolDown();
        }
        else if (!cooldownFinished)
        {
            image.fillAmount = 1;
            coolDownTextDisplay.text = skill.Cooldown.ToString();
            cooldownFinished = true;
        }
    }




    void HandleClick()
    {
        if (skill == null)
        {
            //ShowAvailableSkillsPanel();
        }

        if (skill != null)
        {
            OnSkillPressed.Raise(index);
        }
    }

  

    public void OnPointerEnter(PointerEventData eventData)
    {
        //text.text = skill.name + "  "+ DamageSystem.CalculateDamage(player.GetComponent<Character>(), skill).ToString();
        tooltip.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.SetActive(false);
    }
}
