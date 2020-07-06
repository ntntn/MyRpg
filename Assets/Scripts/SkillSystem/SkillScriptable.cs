using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SkillScriptable : ScriptableObject
{
    public float castTime;
    
    [SerializeField]    
    public List<SkillEffects> onTriggerEffects;

    public virtual Skill GetSkill()
    {
        return new Skill();
    }

    [System.Serializable]
    public struct SkillEffects
    {
        ConditionalHideAttribute atr;
        public SkillEffectType skillEffectType;
        [ConditionalHide("skillEffectType",SkillEffectType.ChangeHealth)]
        public ChangeHealth changeHealth;
        [ConditionalHide("skillEffectType", SkillEffectType.Debuff)]
        public SkillEffect debuff;
    }
}
