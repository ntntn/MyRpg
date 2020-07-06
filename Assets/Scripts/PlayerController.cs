using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : CharacterController
{
    Character character;



    public override Vector3 GetTargetPos()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float dist;
        if (plane.Raycast(ray, out dist))
        {
            return ray.GetPoint(dist);
        }
        return Vector3.zero;
    }

    private void Start()
    {
        character = GetComponent<Character>();
        OnPlayerMoved.AddListener(character.HandleMoved);
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            //UpdateRotation();
            //Move();

            OnPlayerMoved.Invoke();
        }
        else
        {
            OnMovementStopped.Invoke();
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.OnSkillPressed.Invoke(0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.OnSkillPressed.Invoke(2);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            this.OnSkillPressed.Invoke(3);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (!IsPointerOverUIElement())
                this.OnSkillPressed.Invoke(1);
        }
    }

    public bool IsPointerOverUIElement()
    {
        var eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        transform.position = transform.position + movement * Time.deltaTime * 6f;
    }

    void UpdateRotation()
    {
        if ((Input.GetAxisRaw("Horizontal") < 0)) { transform.rotation = Quaternion.Euler(0, -90, 0); }
        if (Input.GetAxisRaw("Horizontal") > 0) { transform.rotation = Quaternion.Euler(0, 90, 0); }
        if (Input.GetAxisRaw("Vertical") > 0) { transform.rotation = Quaternion.Euler(0, 0, 0); }
        if (Input.GetAxisRaw("Vertical") < 0) { transform.rotation = Quaternion.Euler(0, 180, 0); }
        if (Input.GetAxisRaw("Horizontal") > 0 && Input.GetAxisRaw("Vertical") > 0) { transform.rotation = Quaternion.Euler(0, 45, 0); }
        if (Input.GetAxisRaw("Horizontal") > 0 && Input.GetAxisRaw("Vertical") < 0) { transform.rotation = Quaternion.Euler(0, 135, 0); }
        if (Input.GetAxisRaw("Horizontal") < 0 && Input.GetAxisRaw("Vertical") < 0) { transform.rotation = Quaternion.Euler(0, -135, 0); }
        if (Input.GetAxisRaw("Horizontal") < 0 && Input.GetAxisRaw("Vertical") > 0) { transform.rotation = Quaternion.Euler(0, -45, 0); }
    }

}
