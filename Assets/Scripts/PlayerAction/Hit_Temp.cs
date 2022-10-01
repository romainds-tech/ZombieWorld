using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Temp : MonoBehaviour
{

    public Player_Entity_Temp player;
    private List<IA_Entity_Temp> _currentTriggers = new List<IA_Entity_Temp>();

    public float attaqueDelay = 1f;

    // Update is called once per frame
    void Update()
    {

        player.attaqueReload -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0)) {

            if (player.attaqueReload < 0) {

                player.attaqueReload = player.entityData.attaqueDelay;

                Debug.Log("player attack");

                foreach (IA_Entity_Temp ennemy in _currentTriggers.ToArray()) {

                    if (ennemy) {
                        player.Attaque(ennemy);
                    }
                }
            }
        }
        
    }

    // remove ennemies in hit box
    private void ForgetAboutEnnemy(Entity_Temp ennemy)
    {
        if (ennemy is IA_Entity_Temp ia)
        {
            ennemy.OnDead -= ForgetAboutEnnemy;
            _currentTriggers.Remove(ia);
        }
    }

    // Called when trigger enters
    void OnTriggerEnter(Collider other)
    {

        IA_Entity_Temp ennemy = other.gameObject.GetComponent<IA_Entity_Temp>();

        if(!ennemy) {
            return;
        }

        if (!_currentTriggers.Contains(ennemy)) {
            ennemy.OnDead += ForgetAboutEnnemy;
            _currentTriggers.Add(ennemy);
        }

    }

    // call when trigger exit
    void OnTriggerExit(Collider other)
    {
        IA_Entity_Temp ennemy = other.gameObject.GetComponent<IA_Entity_Temp>();
        ForgetAboutEnnemy(ennemy);
    }
    
}
