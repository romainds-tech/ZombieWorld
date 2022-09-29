using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public delegate void EntityEvent();
    public event EntityEvent OnDead;

    private float _life = 20f;
    public float damage = 1.5f;
    public float attaqueDelay = 1f;

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

    // get object position
    public Vector3 GetGameObjectPostition(GameObject o) {

        Vector3 pos = new Vector3(
            o.transform.position.x,
            o.transform.position.y,
            o.transform.position.z
        );

        return pos;
    }

    public void Attaque(Entity e) {
        e.Life = e.Life - this.damage;
        this.attaqueDelay = 1;
        Debug.Log(e.Life);
    } 

    private void Die() {
        this.OnDead.Invoke();
        Destroy(this.gameObject);
    }

}
