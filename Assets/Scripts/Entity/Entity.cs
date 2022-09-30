using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Entity : MonoBehaviour
{

    // Entity event
    public delegate void EntityEvent(Entity e);
    public event EntityEvent OnDead;

    // Entity movement
    public GameObject Planet;
    Vector3 Groundnormal;
    bool OnGround = false;
    float distanceToGround;
    float gravity = 10;
    protected Rigidbody rb;

    // Entity stats 
    private float _life = 20f;
    public float speed = 4;
    public float jumpHeight = 1.2f;
    public float damage = 1.5f;
    public float attaqueDelay = 1f;
    public float attaqueReload = 0f;

    public float Life {
        get => GetLife();
        set => SetLife(value);
    }

    private float GetLife() {
        return this._life;
    }

    private void SetLife(float life) {

        this._life = life;

        if(this.Life < 0) {
            this._life = 0;
            this.Die();
        }
        
    }

    // ---------------------------------------------------------------
    // Entity utils
    // ---------------------------------------------------------------

    // Start is called before the first frame update
    protected void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    protected void Update()
    {
        
    }

    // get object position
    public Vector3 GetGameObjectPostition(GameObject o) {

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



    // ---------------------------------------------------------------
    // Entity actions
    // ---------------------------------------------------------------

    // attaque entity action
    public void Attaque(Entity e) {
        e.Life = e.Life - this.damage;
        this.attaqueDelay = 1;
    }

    // die action
    private void Die() {
        this.OnDead.Invoke(this);
        Destroy(this.gameObject);
    }

}
