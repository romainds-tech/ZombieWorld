using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Entity_Temp : Entity_Temp { 

    protected override void calculSpeed()
    {
        /* // Calculate how fast we should be moving
         Vector3 forwardDir = Vector3.Cross(transform.up, -playerCamera.transform.right).normalized;
         Vector3 rightDir = Vector3.Cross(transform.up, playerCamera.transform.forward).normalized;
         targetVelocity = (forwardDir * Input.GetAxis("Vertical") + rightDir * Input.GetAxis("Horizontal")) * playerData.speed;*/
    }

}
