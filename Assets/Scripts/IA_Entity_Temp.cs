using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Entity_Temp : Entity_Temp { 

    public GameObject target;
    private Entity_Temp targetEntity;

    private bool targetIsDead = false;

    public float targetMinDistance = 1f;
    public float targetMaxDistance = 30f;

    // ---------------------------------------------------------------
    // Entity utils
    // ---------------------------------------------------------------

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
        // position
        Vector3 diff = GetGameObjectPostition(target) - GetGameObjectPostition(this.gameObject);
        diff.Normalize();

        float x = diff.x;
        float y = diff.z;

        transform.position += diff * entityData.speed * Time.deltaTime;

        // rotation
        this.transform.LookAt(target.transform);
        this.transform.localRotation = Quaternion.Euler(0, this.transform.localRotation.eulerAngles.y, 0);
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
