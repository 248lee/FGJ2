using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill7_Absorb : Skill
{
    private bool isSkill7_Absorbing = false;
    private bool hitPlayerSignal = false;
    // Start is called before the first frame update
    void Start()
    {
        isSkill7_Absorbing = false;
        hitPlayerSignal = false;
    }

    // Update is called once per frame
    void Update()
    {
        print(isSkill7_Absorbing);
        if (isSkill7_Absorbing)
        {
            if (hitPlayerSignal)
            {
                GetComponent<PlayerController>().AddHP(2);
                this.hitPlayerSignal = false;
            }
        }
        else
        {
            this.hitPlayerSignal = false;
        }
    }
    public void SetHitPlayerSignal()
    {
        this.hitPlayerSignal = true;
    }
    public override void CastSkill()
    {
        this.isSkill7_Absorbing = true;
    }
    public override void ClearSkill()
    {
        this.isSkill7_Absorbing = false;
    }
}
