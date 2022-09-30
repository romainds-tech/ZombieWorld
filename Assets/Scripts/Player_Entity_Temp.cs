using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class Player_Entity_Temp : Entity_Temp
{

    public Camera playerCamera;
    
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Player rotation
        /*playerCamera.transform.localRotation = Quaternion.Euler(rotation.x, 0, 0);*/
    }

    protected override void calculSpeed()
    {
        // Calculate how fast we should be moving
        Vector3 forwardDir = Vector3.Cross(transform.up, -playerCamera.transform.right).normalized;
        Vector3 rightDir = Vector3.Cross(transform.up, playerCamera.transform.forward).normalized;
        targetVelocity = (forwardDir * Input.GetAxis("Vertical") + rightDir * Input.GetAxis("Horizontal")) * playerData.speed;
    }

}