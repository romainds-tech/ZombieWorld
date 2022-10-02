using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{

    private static EntityController _instance;
    public static EntityController Instance
    {
        get
        {
            // initialize EntityController if not set yet
            if (_instance == null) {
                _instance = FindObjectOfType<EntityController>();
            }
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }

    public bool created = true;

    void Awake()
    {
        
    }

    public void SpawnPlayer()
    {
        GameController.Instance.player = Instantiate(
            GameController.Instance.playerModel, 
            GameController.Instance.player_spawn_point,
            new Quaternion(0, 0, 0, 0)
        );
        GameController.Instance.player.gameObject.SetActive(true);
        GameController.Instance.player.TriggerCreation(GameController.Instance.player);
    }

    public void SpawnZombie()
    {
        GameController.Instance.zombie = Instantiate(
            GameController.Instance.ZombieModel,
            GameController.Instance.zombie_spawn_point,
            new Quaternion(0, 0, 0, 0)
        );
        GameController.Instance.zombie.gameObject.SetActive(true);
    }

}
