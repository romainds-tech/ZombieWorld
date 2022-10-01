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
        // player translation with Vector3.Cross
        
        Vector3 forward = Vector3.Cross(transform.up, -transform.right).normalized;
        Vector3 right = Vector3.Cross(transform.up, transform.forward).normalized;
        
        targetVelocity = (forward * Input.GetAxis("Vertical") + right * Input.GetAxis("Horizontal")) * entityData.speed;
    }
    
    protected override void calculRotation()
    {
        Quaternion q;
        Vector3 toCenter = planet.position - transform.position;
        toCenter.Normalize();
        
        q = Quaternion.FromToRotation(transform.up, -toCenter);
        q = q * transform.rotation;
        
        transform.rotation = q;
        
        mousePos = Input.mousePosition;
        Vector2 lookDirection = mousePos - new Vector2(Screen.width / 2, Screen.height / 2);
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90;

        Vector3 currentrotate = transform.rotation.eulerAngles;
        
        
        Debug.Log("CUR"+ currentrotate.y);
        Debug.Log("ANG"+ angle);
        Debug.Log("DIFF"+ (angle - currentrotate.y));

        currentrotate = new Vector3(currentrotate.x, currentrotate.y - angle, currentrotate.z);
        
        Quaternion q2 = Quaternion.Euler(currentrotate);
        
        currentrotate = new Vector3(currentrotate.x, q2.y - q.y, currentrotate.z);

        transform.rotation = Quaternion.Euler(currentrotate);
    
        // transform.rotation = Quaternion.Euler(currentrotate.x, q.y+angle, currentrotate.z);
        // transform.rotation = Quaternion.Slerp(transform.rotation, q, 1);
         
        // transform.rotation = Quaternion.Euler(transform.rotation.x, -angle, transform.rotation.z);
        // transform.rotation = Quaternion.Slerp(transform.rotation, q, 1);
        // transform.Rotate(new Vector3(0, - angle,0));
    }

}