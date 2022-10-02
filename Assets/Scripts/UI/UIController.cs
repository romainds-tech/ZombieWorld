using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public GameObject playerPanel;
    public GameObject deathPanel;

    // Start is called before the first frame update
    void Start()
    {
        Player_Entity player = GameController.Instance.player;
        player.OnDead += ShowPanelOnDeath;

        deathPanel.SetActive(false);
    }

    void ShowPanelOnDeath(Entity e)
    {
        deathPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
