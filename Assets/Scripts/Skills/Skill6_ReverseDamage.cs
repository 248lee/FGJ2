using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill6_ReverseDamage : Skill
{
    private bool isSkill6_ReversingDamage = false;
    private bool hitEnemySignal = false;
    // Start is called before the first frame update
    void Start()
    {
        this.isSkill6_ReversingDamage = false;
        this.hitEnemySignal = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSkill6_ReversingDamage)
        {
            if (hitEnemySignal)
            {
                print("Damage");
                GetComponent<PlayerController>().DropHP(1);
                this.hitEnemySignal = false;
            }
        }
        else
        {
            this.hitEnemySignal = false;
        }
    }
    public void SetHitEnemySignal()
    {
        this.hitEnemySignal = true;
    }
    public override void CastSkill()
    {
        this.isSkill6_ReversingDamage = true;
    }
    public override void ClearSkill()
    {
        this.isSkill6_ReversingDamage = true;
    }
}
