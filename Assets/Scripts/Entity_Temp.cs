using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity_Temp : MonoBehaviour
{

    public Entity_Data playerData;

    protected Rigidbody r;
    protected Vector2 rotation = Vector2.zero;

    public bool canJump = true;
    protected bool grounded = false;

    protected float maxVelocityChange = 10.0f;
    protected Vector3 targetVelocity;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
        r.freezeRotation = true;
        r.useGravity = false;
        r.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rotation.y = transform.eulerAngles.y;
    }

    protected void FixedUpdate()
    {
        if (!grounded)
        {
            return;
        }

        calculSpeed();

        Vector3 velocity = transform.InverseTransformDirection(r.velocity);
        velocity.y = 0;
        velocity = transform.TransformDirection(velocity);
        Vector3 velocityChange = transform.InverseTransformDirection(targetVelocity - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;
        velocityChange = transform.TransformDirection(velocityChange);

        r.AddForce(velocityChange, ForceMode.VelocityChange);

        if (Input.GetButton("Jump") && canJump)
        {
            r.AddForce(transform.up * playerData.jumpHeight, ForceMode.VelocityChange);
        }

        grounded = false;
    }

    protected abstract void calculSpeed();

    void OnCollisionStay()
    {
        grounded = true;
    }
}
