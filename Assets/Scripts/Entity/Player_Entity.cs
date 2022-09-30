using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Entity: Entity
{

    public GameObject PlayerPlaceholder;
    private Vector2 mousePos;

    // Movement of the player
    protected override void EntityMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 diff = new Vector3(x, 0, z);

        transform.position += diff * speed * Time.deltaTime;
    }

    // Rotation of the player to the mouse
    protected override void EntityRotation()
    {
        mousePos = Input.mousePosition;
        Vector2 lookDirection = mousePos - new Vector2(Screen.width / 2, Screen.height / 2);
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0, -angle, 0);
    }
}
