using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillTreeController : MonoBehaviour
{
    public List<SkillContainer> skillContainers;

    [SerializeField]
    SkillController skillController;

    [SerializeField]
    ButtonsController buttonsController;

    [SerializeField]
    float skillPoints;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var s in skillContainers)
        {
            s.controller = this;
            s.GetComponent<Button>().onClick.AddListener(new UnityAction(s.TrySkillAcquire));
            s.acquired = false;
        }
    }

    public void AddSkillPoint()
    {
        skillPoints += 1;
    }

    public bool TrySkillAcquire(Skill skill)
    {
        //acquired then
        if (skillPoints >= skill.skillPointsCost)
        { 
            skillPoints -= skill.skillPointsCost;
            skillController.AddSkill(skill);
            buttonsController.AddSkill(skill);
            return true;
        }
        return false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
