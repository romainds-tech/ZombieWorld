using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class Player_Entity_Temp : Entity_Temp
{

    private Vector2 mousePos;
    // ---------------------------------------------------------------
    // Entity utils
    // ---------------------------------------------------------------

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    protected override void calculMovement()
    {
        float speed = entityData.speed * Time.deltaTime;

        Vector3 forward = Vector3.Cross(-transform.up, transform.right).normalized * Input.GetAxis("Vertical") * speed;
        Vector3 right = Vector3.Cross(transform.up, transform.forward).normalized * Input.GetAxis("Horizontal") * speed;

        transform.position += forward + right;
    }

    protected override void calculRotation()
    {
        float angle = Input.GetAxis("Mouse X");
        transform.Rotate(0, angle * 10, 0);
    }

}