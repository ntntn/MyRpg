using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillContainer : MonoBehaviour
{
    public Skill skill;

    public SkillTreeController controller;

    public bool acquired = false;
    private bool spriteSet = false;

    Image image;

    private void Start()
    {
        if (!spriteSet)
        {
            image = GetComponent<Image>();
            image.sprite = skill.Sprite;
            spriteSet = true;
        }
        
    }

    public void TrySkillAcquire()
    {
        Debug.Log("onclick");   
        if (!acquired)
            if (controller.TrySkillAcquire(skill))
            {
                acquired = true;

                var tempColor = image.color;
                tempColor.a = 255;
                image.color = tempColor;
            }
    }
}
