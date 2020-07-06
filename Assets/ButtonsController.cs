using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    [SerializeField]
    GameObject obj;

    [SerializeField]
    GameObject treePanel;

    [SerializeField]
    GameObject InventoryPanel;

    public List<SkillButtonController> skillButtons;

    [SerializeField]
    SkillController playerController;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<SkillController>().OnSkillUsed.AddListener(new UnityEngine.Events.UnityAction<int>(HandleSkillUsed));
    }

    public void ChangeTreeActiveState()
    {
        bool active = treePanel.activeSelf;


        if (active)
            treePanel.SetActive(false);
        else
            treePanel.SetActive(true);

    }

    public void ChangeInventoryActiveState()
    {
        bool active = InventoryPanel.activeSelf;


        if (active)
            InventoryPanel.SetActive(false);
        else
            InventoryPanel.SetActive(true);

    }

    void HandleSkillUsed(int index)
    {
        skillButtons[index].HandleCooldownStarted();
    }

    public void AddSkill(Skill skill)
    {
        for (int i=0; i<skillButtons.Count; i++)
        {
            if (skillButtons[i].skill == null)
            {
                skillButtons[i].ChangeSkill(skill);
                skillButtons[i].skill = skill;

                break;
            }
        }
    }

    public void ChangeActiveState()
    {
        bool active = obj.activeSelf;

        
            
        if (active)
            obj.SetActive(false);
        else
            obj.SetActive(true);
    }

}
