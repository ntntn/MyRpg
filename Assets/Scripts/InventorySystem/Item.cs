using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TargetType
{
    selfOnly,
    target
}

public enum ItemType
{
    Weapon,
    Armor,
    Item
}


[CreateAssetMenu]
public class Item : ScriptableObject
{
    public List<SkillEffect> effects;
    public TargetType targetType;

    public Sprite sprite;

    public ItemType itemType;

    public virtual void Use(Inventory inventory) 
    {
        GameObject target = default;

        switch (targetType)
        {
            case TargetType.selfOnly:
                target = inventory.User;
                break;
            case TargetType.target:
                target = inventory.Target;
                break;
        }

        if (target != null)
        {
            foreach (var e in effects)
            {
                e.Apply(null, target);
            }
        }        
    }

    public virtual bool TryEquip(Character character) { return false; }
}
