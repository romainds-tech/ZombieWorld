using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{

    // Entity data 
    public Entity_Data entityData;

    public float life;
    public float Life
    {
        get => GetLife();
        set => SetLife(value);
    }

    private float GetLife()
    {
        return this.life;
    }

    private void SetLife(float life)
    {
        this.life = life;

        if (this.Life <= 0)
        {
            this.life = 0;
            this.Die();
        }

    }

    public float attaqueReload = 0;

    // Entity event
    public delegate void EntityEvent(Entity e);
    public event EntityEvent OnSpawn;
    public event EntityEvent OnTakeDamage;
    public event EntityEvent OnDead;
    
    // Entity moving
    public Transform planet;

    protected Vector3 targetVelocity;
    protected float maxVelocityChange = 10.0f;
    protected Vector2 rotation = Vector2.zero;

    protected Rigidbody r;

    protected bool grounded = false;
    float gravityConstant = 9.8f;

    // ---------------------------------------------------------------
    // Entity utils
    // ---------------------------------------------------------------

    // Start is called before the first frame update
    protected void Start()
    {
        this.Life = entityData.maxLife;
        r = GetComponent<Rigidbody>();
        r.freezeRotation = true;
        r.useGravity = false;
        r.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rotation.y = transform.eulerAngles.y;

        // OnSpawn.Invoke(this);
    }

    protected void FixedUpdate()
    {
        Move();
    }

    // get object position
    public Vector3 GetGameObjectPostition(GameObject o)
    {

        Vector3 pos = new Vector3(
            o.transform.position.x,
            o.transform.position.y,
            o.transform.position.z
        );

        return pos;
    }

    // ---------------------------------------------------------------
    // Entity moving
    // ---------------------------------------------------------------

    protected void Move()
    {
        
        calculRotation();
        calculMovement();

        ProcessGravity();

        applyMovement();
        Jump();

        grounded = false;
    }

    protected void ProcessGravity()
    {
        Vector3 toCenter = planet.position - transform.position;
        toCenter.Normalize();

        r.AddForce(toCenter * gravityConstant, ForceMode.Acceleration);

        Quaternion q = Quaternion.FromToRotation(transform.up, -toCenter);
        q = q * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, q, 1);

    }

    protected abstract void calculMovement();
    protected abstract void calculRotation();

    protected void applyMovement()
    {
        Vector3 velocity = transform.InverseTransformDirection(r.velocity);
        velocity.y = 0;
        velocity = transform.TransformDirection(velocity);

        Vector3 velocityChange = transform.InverseTransformDirection(targetVelocity - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;
        velocityChange = transform.TransformDirection(velocityChange);

        r.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    protected void Jump()
    {
        if (Input.GetButton("Jump") && entityData.canJump)
        {
            r.AddForce(transform.up * entityData.jumpHeight, ForceMode.VelocityChange);
        }
    }

    void OnCollisionStay()
    {
        grounded = true;
    }

    // ---------------------------------------------------------------
    // Entity actions
    // ---------------------------------------------------------------

    // attaque entity action
    public void Attaque(Entity e)
    {
        e.Life = e.Life - this.entityData.damage;
        if(e.Life > 0) {
            e.OnTakeDamage.Invoke(e);
        }
        this.entityData.attaqueDelay = 1;
    }

    // die action
    private void Die()
    {
        this.OnDead.Invoke(this);
        Destroy(this.gameObject);
    }

}
