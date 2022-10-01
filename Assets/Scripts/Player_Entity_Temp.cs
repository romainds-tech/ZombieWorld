using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class Player_Entity_Temp : Entity_Temp
{

    public Camera playerCamera;

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
        // player rotation
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * entityData.speed, 0), Space.Self) ;

        // player translation
        Vector3 forwardDir = Vector3.Cross(transform.up, -playerCamera.transform.right).normalized;
        Vector3 rightDir = Vector3.Cross(transform.up, playerCamera.transform.forward).normalized;
        targetVelocity = (forwardDir * Input.GetAxis("Vertical") + rightDir * Input.GetAxis("Horizontal")) * entityData.speed;
    }

}