using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum HandedType
{
    OneHanded,
    TwoHanded
}


[CreateAssetMenu]
public class Weapon : Item
{
    public HandedType handedType;
    public GameObject prefab;

    public override bool TryEquip(Character character)
    {
        switch (handedType)
        {
            case HandedType.OneHanded:

                if (character.Weapon1 == null)
                {
                    character.EquipWeapon1(this);
                    return true;
                }

                if (character.Weapon2 == null)
                {
                    character.EquipWeapon2(this);
                    return true;
                }

                break;

            case HandedType.TwoHanded:
                break;
        }

        return false;
    }
}
