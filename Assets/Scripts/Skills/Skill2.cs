using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2 : Skill
{
    public float skill2_AddHpPeriod = 0.7f;
    private bool isSkill2Adding = false;
    // Start is called before the first frame update
    void Start()
    {
        this.isSkill2Adding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSkill2Adding)
        {
            if (Timers.IsTimerFinished("skill2AddHpCooldown"))
            {
                Timers.SetTimer("skill2AddHpCooldown", skill2_AddHpPeriod);
                GetComponent<PlayerController>().AddHP(1);
            }
        }
    }
    public override void CastSkill()
    {
        this.isSkill2Adding = true;
        Timers.SetTimer("skill2AddHpCooldown", skill2_AddHpPeriod);
    }
    public override void ClearSkill()
    {
        this.isSkill2Adding = false;
    }
}
