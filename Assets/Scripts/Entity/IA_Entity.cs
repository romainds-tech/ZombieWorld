using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Entity : Entity { 

    public GameObject target;
    private Entity targetEntity;

    private bool targetIsDead = false;

    float dist = 0;
    public float targetMinDistance = 1f;
    public float targetMaxDistance = 30f;

    // ---------------------------------------------------------------
    // Entity utils
    // ---------------------------------------------------------------

    // Start is called before the first frame update
    protected new void Start()
    {
        base.Start();
        this.target = GameController.Instance.player.gameObject;
        Debug.Log(GameController.Instance.player.Life);
        targetEntity = GameController.Instance.player;
        targetEntity.OnDead += TargetIsDead;
        // NewTarget(GameController.Instance.player);
        // GameController.Instance.player.OnSpawn += NewTarget;
    }

    // Update is called once per frame
    protected new void FixedUpdate()
    {

        if (targetIsDead)
        {
            return;
        }

        base.FixedUpdate();

        dist = Vector3.Distance(GetGameObjectPostition(target), GetGameObjectPostition(this.gameObject));

        // if arround, attaque
        if (dist < this.targetMinDistance)
        {
            this.TryAttaque();
        }

    }

    private void NewTarget(Entity e)
    {
        Debug.Log("new target");
        this.target = GameController.Instance.player.gameObject;
        targetEntity = GameController.Instance.player as Entity;
        targetEntity.OnDead += TargetIsDead;

    }

    // ---------------------------------------------------------------
    // Entity moving
    // ---------------------------------------------------------------

    protected override void calculMovement()
    {

        // if out of range, nothing
        if (dist > this.targetMaxDistance) { return; }

        // if to far, run to target
        if (dist < this.targetMinDistance) { return; }

        // position
        Vector3 diff = GetGameObjectPostition(target) - GetGameObjectPostition(this.gameObject);
        diff.Normalize();

        float x = diff.x;
        float y = diff.z;

        transform.position += diff * entityData.speed * Time.deltaTime;

    }

    protected override void calculRotation()
    {
        // if out of range, nothing
        if (dist > this.targetMaxDistance) { return; }

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

        this.attaqueReload -= Time.deltaTime;

        if (this.attaqueReload < 0)
        {
            this.attaqueReload = this.entityData.attaqueDelay;
            this.Attaque(targetEntity);
        }
    }

    // set targetIsDead true to not update target anymore 
    private void TargetIsDead(Entity e)
    {
        targetIsDead = true;
    }

}
