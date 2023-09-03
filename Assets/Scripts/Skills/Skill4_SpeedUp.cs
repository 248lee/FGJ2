using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill4_SpeedUp : Skill
{
    public float skill4PlayerSpeed = 4f;
    float originalSpeed;
    // Start is called before the first frame update
    void Start()
    {
        this.originalSpeed = GetComponent<PlayerController>().playerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void CastSkill()
    {
        GetComponent<PlayerController>().playerSpeed = skill4PlayerSpeed;
    }
    public override void ClearSkill()
    {
        GetComponent<PlayerController>().playerSpeed = originalSpeed;
    }
}
