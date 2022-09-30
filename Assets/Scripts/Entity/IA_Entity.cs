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

    // move entity
    protected override void EntityMovement()
    {
        Vector3 diff = GetGameObjectPostition(target) - GetGameObjectPostition(this.gameObject);
        diff.Normalize();

        float x = diff.x * speed * Time.deltaTime;
        float y = diff.z * speed * Time.deltaTime;

        transform.position += diff * speed * Time.deltaTime;
    }

    // Rotation to the target
    protected override void EntityRotation()
    {
        Debug.Log("rotate");
        this.transform.LookAt(target.transform);
        this.transform.localRotation = Quaternion.Euler(0, this.transform.localRotation.eulerAngles.y, 0);
        /*Vector2 lookDirection = new Vector2(GetGameObjectPostition(target).x, GetGameObjectPostition(target).z);
        float angle = Mathf.Tan(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0, -angle, 0);*/
    }

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
