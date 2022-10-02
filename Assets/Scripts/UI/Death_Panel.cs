using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Panel : MonoBehaviour
{

    public void Revive()
    {
        GameController.Instance.SpawnPlayer();
        this.gameObject.SetActive(false);
    }

}
