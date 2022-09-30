using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Entity_Data : ScriptableObject
{
    private float life;
    public float damage;
    public float attaqueDelay;
    public float attaqueReload;
    public float speed;
    public float jumpHeight;
    public bool canJump;

}