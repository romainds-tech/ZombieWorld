using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_Panel : MonoBehaviour
{
    
    void ShowOnDeath(Entity e)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Revive()
    {
        GameController.Instance.SpawnPlayer();
    }

}
