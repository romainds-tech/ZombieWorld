using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaceholder : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        Player_Entity player_entity = GameController.Instance.player;
        if (!player_entity) { return; }

        GameObject player = player_entity.gameObject;
        GameObject planet = GameController.Instance.planet;
 
        //POSITION
        transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.1f);
        Vector3 gravDirection = (transform.position - planet.transform.position).normalized;
 
        //ROTATION
        Quaternion toRotation = Quaternion.FromToRotation(transform.up, gravDirection) * transform.rotation;
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 0.1f);
 
    }
 
 
}
