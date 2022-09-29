using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{

    private GameObject player;
    private List<Collider> _currentTriggers = new List<Collider>();

    public float attaqueDelay = 1f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called when a trigger enters
    void OnTriggerEnter(Collider other)
    {
        if (!_currentTriggers.Contains(other)) {
            _currentTriggers.Add(other);
        }

        Debug.Log("trigger add");
        Debug.Log(_currentTriggers.Count);
    }

    void OnTriggerExit(Collider other)
    {
        _currentTriggers.Remove(other);
        Debug.Log("trigger remove");
        Debug.Log(_currentTriggers.Count);
    }
    
}
