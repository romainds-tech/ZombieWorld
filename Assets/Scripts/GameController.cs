using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private static GameController _instance;
    public static GameController Instance {
        get {
            // initialize gamecontroller if not set yet
            if (_instance == null)
                _instance = FindObjectOfType<GameController>();
            return _instance;
        }
        private set {
            _instance = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
