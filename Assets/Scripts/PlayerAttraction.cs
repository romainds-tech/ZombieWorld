using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttraction: MonoBehaviour
{
    public Transform planet;
    public bool alignToPlanet = true;

    float gravityConstant = 9.8f;
    Rigidbody r;

    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 toCenter = planet.position - transform.position;
        toCenter.Normalize();

        r.AddForce(toCenter * gravityConstant, ForceMode.Acceleration);

        if (alignToPlanet)
        {
            Quaternion q = Quaternion.FromToRotation(transform.up, -toCenter);
            q = q * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, q, 1);
        }
    }
}