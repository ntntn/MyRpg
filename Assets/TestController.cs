using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    [SerializeField]
    Lightning lightning;

    private void Start()
    {
        lightning.test = 15;
    }
}
