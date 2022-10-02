using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Panel : MonoBehaviour
{

    public void Revive()
    {
        EntityController.Instance.SpawnPlayer();
        this.gameObject.SetActive(false);
    }

}
