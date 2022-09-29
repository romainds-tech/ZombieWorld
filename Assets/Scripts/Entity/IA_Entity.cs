using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Entity : Entity
{

    public UnityEngine.AI.NavMeshAgent agent;

    public GameObject target;
    private Entity targetEntity;
    private bool targetIsDead = false;

    public float targetMinDistance = 1f;

    // Start is called before the first frame update
    void Start()
    {
        this.MoveToTarget();
        targetEntity = target.GetComponent("Entity")  as Entity;
        targetEntity.OnDead += TargetIsDead; 
    }

    // Update is called once per frame
    void Update() {
        if(!targetIsDead) {
            this.ManageTarget();
        }
    }

    public void ManageTarget() {
        float dist = Vector3.Distance(this.transform.position, target.transform.position);

        // move entity when it is distant to taget
        if(dist > this.targetMinDistance) {
            this.MoveToTarget();
        }

        this.attaqueDelay -= Time.deltaTime;

        // stop entity when it is next to target
        if(dist < this.targetMinDistance) {
            this.Stop();
            this.TryAttaque();
        }
    }

    // move entity to taget
    private void MoveToTarget() {
        agent.SetDestination(
            this.GetGameObjectPostition(this.target)
        );
    }

    // stop entity
    private void Stop() {
        agent.SetDestination(
            this.GetGameObjectPostition(this.gameObject)
        );
    }

    // try to inflict damage to the target 
    private void TryAttaque() {
        if(this.attaqueDelay < 0) {
            this.Attaque(targetEntity);
        }
    }

    // set targetIsDead true to not update target anymore 
    private void TargetIsDead() {
        targetIsDead = true;
    }

}
