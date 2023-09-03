using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1_WrapWall : Skill
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void CastSkill()
    {
        Physics.IgnoreLayerCollision(7, 8, true);
    }
    public override void ClearSkill()
    {
        Physics.IgnoreLayerCollision(7, 8, false);
    }
}
