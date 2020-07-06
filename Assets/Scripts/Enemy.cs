using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField]
    GameObject player;

    public float chaseRange;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (this.movespeed == 0)
        {
            this.movespeed = 3;
        }
    }

    private void OnMouseOver()
    {
        player.GetComponent<Character>().target = this.gameObject;
    }

    private void OnMouseExit()
    {
        player.GetComponent<Character>().target = null;
    }
}
