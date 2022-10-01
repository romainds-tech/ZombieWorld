using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Entity_Data : ScriptableObject
{
    public float maxLife;
    public float damage;
    public float attaqueDelay;
    public float speed;
    public float jumpHeight;
    public bool canJump;

}
