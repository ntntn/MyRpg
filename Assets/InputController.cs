using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject cameraTarget;
    public float initialMagnitude;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 movement = cameraTarget.transform.position - transform.position;
        initialMagnitude = movement.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnPlayerMoved()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        transform.position = transform.position + movement * Time.deltaTime * 6f;
    }

    public void OnPlayerBlinkUsed(float blinkRange)
    {
        transform.position += cameraTarget.transform.forward * blinkRange;
    }
}
