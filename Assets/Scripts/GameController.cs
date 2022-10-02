using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private static GameController _instance;
    public static GameController Instance
    {
        get
        {
            // initialize gamecontroller if not set yet
            if (_instance == null) {
                _instance = FindObjectOfType<GameController>();
            }
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }

    public Player_Entity playerModel;
    public IA_Entity ZombieModel;

    public Player_Entity player;
    public Vector3 player_spawn_point = new Vector3(0, 32, 0);

    public IA_Entity zombie;
    public Vector3 zombie_spawn_point;

    public GameObject planet;

    // Start is called before the first frame update
    void Awake()
    {
        player_spawn_point  = new Vector3(0, 32, 0);
        zombie_spawn_point = new Vector3(3, 32, 3);
        EntityController.Instance.SpawnPlayer();
        EntityController.Instance.SpawnZombie();
    }

}