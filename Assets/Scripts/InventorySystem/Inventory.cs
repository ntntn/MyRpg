using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    List<Item> items;
    List<ItemContainer> itemContainers;

    GameObject inventory;
    GameObject user;
    GameObject target;

    Character character;

    public ItemEvent OnItemAddedToInventory;


    private void Start()
    {
        character = GetComponent<Character>();
        items = new List<Item>();
    }

    public void HandleLootboxItemClicked(Item item)
    {
        if (!item.TryEquip(character))
        {
            items.Add(item);
            OnItemAddedToInventory.Invoke(item);
        }
    }

    public GameObject User { get => user; set => user = value; }
    public GameObject Target { get => target; set => target = value; }

    public void OnItemPressed(Item item)
    {
        item.Use(this);
    }

    public void Open()
    {
        if (!inventory.activeSelf)
            inventory.SetActive(true);
        else inventory.SetActive(false);
    }
}
