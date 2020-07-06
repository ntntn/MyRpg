using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    public Item item;

    [SerializeField]
    ItemGameEvent OnItemEquipped;

    private void Start()
    {
        //playerCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            OnItemEquipped.Raise(item);
        }
    }
}
