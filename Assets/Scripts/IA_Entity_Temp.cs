using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Entity_Temp : Entity_Temp { 

    public GameObject target;
    private Entity_Temp targetEntity;

    private bool targetIsDead = false;

    public float targetMinDistance = 1f;
    public float targetMaxDistance = 30f;

    // Start is called before the first frame update
    protected new void Start()
    {
        base.Start();
        targetEntity = target.GetComponent("Entity_Temp") as Entity_Temp;
        targetEntity.OnDead += TargetIsDead;
    }

    // Update is called once per frame
    protected new void FixedUpdate()
    {

        if (targetIsDead) {
            return;
        }

        float dist = Vector3.Distance(GetGameObjectPostition(target), GetGameObjectPostition(this.gameObject));

        // if out of range, nothing
        if (dist > this.targetMaxDistance) {
            return;
        }

        // if to far, run to target
        if (dist > this.targetMinDistance) {
            base.FixedUpdate();
        }

        // if arround, attaque
        if (dist < this.targetMinDistance) {
            this.TryAttaque();
        }

    }

    // ---------------------------------------------------------------
    // Entity moving
    // ---------------------------------------------------------------

    protected override void calculMovement()
    {
        /* // Calculate how fast we should be moving
         Vector3 forwardDir = Vector3.Cross(transform.up, -playerCamera.transform.right).normalized;
         Vector3 rightDir = Vector3.Cross(transform.up, playerCamera.transform.forward).normalized;
         targetVelocity = (forwardDir * Input.GetAxis("Vertical") + rightDir * Input.GetAxis("Horizontal")) * playerData.speed;*/
    }

    // ---------------------------------------------------------------
    // Entity actions
    // ---------------------------------------------------------------


    // try to inflict damage to the target 
    private void TryAttaque()
    {

        this.entityData.attaqueReload -= Time.deltaTime;

        if (this.entityData.attaqueReload < 0)
        {
            this.entityData.attaqueReload = this.entityData.attaqueDelay;
            this.Attaque(targetEntity);
        }
    }

    // set targetIsDead true to not update target anymore 
    private void TargetIsDead(Entity_Temp e)
    {
        targetIsDead = true;
    }

}
