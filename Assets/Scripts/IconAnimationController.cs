using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconAnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(Timers.GetTimerPrgress("Skill0"));
        if (!Timers.IsTimerFinished("Skill0") && Timers.GetTimerPrgress("Skill0") > 0.7f)
        {
            GetComponent<Animator>().SetBool("isShining", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isShining", false);
        }
    }
}
