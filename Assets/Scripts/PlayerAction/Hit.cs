using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{

    public Player_Entity player;
    private List<IA_Entity> _currentTriggers = new List<IA_Entity>();

    public float attaqueDelay = 1f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(_currentTriggers.Count);

        player.attaqueReload -= Time.deltaTime;

        if (player.attaqueReload < 0) {

            player.attaqueReload = this.attaqueDelay;
            Debug.Log("player can attack");

            foreach (IA_Entity ennemy in _currentTriggers.ToArray()) {
                Debug.Log("player prepare attack");


                if (ennemy) {
                    Debug.Log("player attack");
                    player.Attaque(ennemy);
                }
            }
        }
        
    }

    private void ForgetAboutEnnemy(Entity ennemy)
    {
        if (ennemy is IA_Entity ia)
        {
            ennemy.OnDead -= ForgetAboutEnnemy;
            _currentTriggers.Remove(ia);
        }
    }

    // Called when a trigger enters
    void OnTriggerEnter(Collider other)
    {

        IA_Entity ennemy = other.gameObject.GetComponent<IA_Entity>();

        if(!ennemy) {
            return;
        }

        if (!_currentTriggers.Contains(ennemy)) {
            Debug.Log(other.gameObject.name);
            Debug.Log("trigger add");

            ennemy.OnDead += ForgetAboutEnnemy;
            _currentTriggers.Add(ennemy);
            
        }

    }

    void OnTriggerExit(Collider other)
    {
        IA_Entity ennemy = other.gameObject.GetComponent<IA_Entity>();
        ForgetAboutEnnemy(ennemy);

        Debug.Log("trigger remove");
        Debug.Log(_currentTriggers.Count);
    }
    
}
