using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{

    private Slider lifeBar;

    // Start is called before the first frame update
    void Start()
    {
        Player_Entity player = GameController.Instance.player;
        player.OnTakeDamage += UpdateLife;
        lifeBar = this.gameObject.GetComponent<Slider>() as Slider;
    }

    void UpdateLife(Entity e)
    {
        this.lifeBar.value = e.Life / e.entityData.maxLife;
    }
}
