using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Entity : Entity
{
    public GameObject target;
    private Entity targetEntity;

    private bool targetIsDead = false;

    public float targetMinDistance = 1f;
    public float targetMaxDistance = 30f;

    // Start is called before the first frame update
    protected new void Start()
    {
        /*this.MoveToTarget();*/
        base.Start();
        targetEntity = target.GetComponent("Entity") as Entity;
        targetEntity.OnDead += TargetIsDead;
    }

    // Update is called once per frame
    protected new void Update()
    {

        if(targetIsDead) {
            return;
        }

        float dist = Vector3.Distance(GetGameObjectPostition(target), GetGameObjectPostition(this.gameObject));

        // if out of range, nothing
        if (dist > this.targetMaxDistance)
        {
            return;
        }

        // if to far, run to target
        if(dist > this.targetMinDistance)
        {
            base.Update();
        }

        // if arround, attaque
        if (dist < this.targetMinDistance)
        {
            this.TryAttaque();
        }

    }

    // ---------------------------------------------------------------
    // Entity moving
    // ---------------------------------------------------------------


    // ---------------------------------------------------------------
    // Entity actions
    // ---------------------------------------------------------------


    // try to inflict damage to the target 
    private void TryAttaque()
    {

        this.attaqueReload -= Time.deltaTime;

        if (this.attaqueReload < 0)
        {
            this.attaqueReload = this.attaqueDelay;
            this.Attaque(targetEntity);
        }
    }

    // set targetIsDead true to not update target anymore 
    private void TargetIsDead(Entity e)
    {
        targetIsDead = true;
    }

}
