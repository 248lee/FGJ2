using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3 : Skill
{
    public float skill3_DropHpPeriod = 0.7f;
    private bool isSkill3Dropping = false;
    // Start is called before the first frame update
    void Start()
    {
        this.isSkill3Dropping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSkill3Dropping)
        {
            if (Timers.IsTimerFinished("skill3DropHpCooldown"))
            {
                Timers.SetTimer("skill3DropHpCooldown", skill3_DropHpPeriod);
                GetComponent<PlayerController>().DropHP(1);
            }
        }
    }
    public override void CastSkill()
    {
        this.isSkill3Dropping = true;
        Timers.SetTimer("skill3DropdHpCooldown", skill3_DropHpPeriod);
    }
    public override void ClearSkill()
    {
        this.isSkill3Dropping = false;
    }
}
