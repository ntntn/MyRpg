using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    public GameObject player;

    [SerializeField]
    GameObject selectionCircle;

    SkillController skillController;

    private void Start()
    {
        if (player != null)
        {
            skillController = player.GetComponent<SkillController>();
        }
    }

    private void OnMouseEnter()
    {
        if (player != null)
        {
            skillController.target = this.gameObject;
        }    
        
        selectionCircle.SetActive(true);
    }
    private void OnMouseExit()
    {
        if (player != null)
        {
            skillController.target = null;
        }

        selectionCircle.SetActive(false);
    }
}
