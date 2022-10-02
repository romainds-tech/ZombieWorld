using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{

    public Player_Entity player;
    private List<IA_Entity> _currentTriggers = new List<IA_Entity>();

    // Update is called once per frame
    void Update()
    {

        player.attaqueReload -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0)) {

            Debug.Log("player try attack");

            if (player.attaqueReload < 0) {

                Debug.Log("can attack");

                player.attaqueReload = player.entityData.attaqueDelay;

                Debug.Log("player attack");

                foreach (IA_Entity ennemy in _currentTriggers.ToArray()) {

                    if (ennemy) {
                        player.Attaque(ennemy);
                    }
                }
            }
        }
        
    }

    // remove ennemies in hit box
    private void ForgetAboutEnnemy(Entity ennemy)
    {
        if (ennemy is IA_Entity ia)
        {
            ennemy.OnDead -= ForgetAboutEnnemy;
            _currentTriggers.Remove(ia);
        }
    }

    // Called when trigger enters
    void OnTriggerEnter(Collider other)
    {

        IA_Entity ennemy = other.gameObject.GetComponent<IA_Entity>();

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
        IA_Entity ennemy = other.gameObject.GetComponent<IA_Entity>();
        ForgetAboutEnnemy(ennemy);
    }
    
}
