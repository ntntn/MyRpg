using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/UseSkillInRange")]
public class UseSkillInRangeDecision : Decision
{
    public override bool Decide(StateMachine controller)
    {
        if (controller.skillController.Casting) return true;

        var skills = controller.skillController.skills;
        var distance = controller.target.transform.position - controller.transform.position;

        List<int> availableSkillsId = new List<int>();

        Blink blink = null;
        Nova nova = null;

        for (int i=0; i < skills.Count; i++)
        {
            if (controller.skillController.cooldowns[i] <= 0)
            {

                if (distance.magnitude <= skills[i].minRangeToTarget || skills[i].minRangeToTarget == 0)
                {

                    availableSkillsId.Add(i);
                }

                if (skills[i].exactSkillType == ExactSkillType.Nova)
                {
                    nova = (Nova)skills[i];
                    availableSkillsId.Remove(i);
                }

                if (skills[i].exactSkillType == ExactSkillType.Blink)
                {
                    blink = (Blink)skills[i];
                    availableSkillsId.Remove(i);
                }
            }
        }

        if (nova != null)
        {
            if (distance.magnitude <= nova.radius)
            {
                controller.skill = nova;
                return true;
            }
        }

        if (blink != null)
        {
            float blinkRange = (controller.transform.position.normalized + controller.transform.forward.normalized * blink.rangeMultiplier).magnitude;
            Debug.Log(blinkRange);

            if (distance.magnitude >= blinkRange)
            {
                controller.skill = blink;
                return true;
            }
        }


        if (availableSkillsId.Count>0)
        {
            int randomIndex = availableSkillsId[Random.Range(0, availableSkillsId.Count)];
            controller.skill = skills[randomIndex];

            return true;
        }

        

        return false;
    }
}
