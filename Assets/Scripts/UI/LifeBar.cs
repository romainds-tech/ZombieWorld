using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{

    public Entity_Temp player;
    private Slider lifeBar;

    // Start is called before the first frame update
    void Start()
    {
        player.OnTakeDamage += UpdateLife;
        lifeBar = this.gameObject.GetComponent<Slider>() as Slider;
    }

    void UpdateLife(Entity_Temp e)
    {
        this.lifeBar.value = player.Life / player.entityData.maxLife;
    }
}