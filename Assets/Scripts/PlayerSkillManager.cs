// Author: JOHN LEE
// This will be merged into PlayerController later.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillManager : MonoBehaviour
{
    private int[] skills = new int[2];

    // Start is called before the first frame update
    void Start()
    {
        this.skills[0] = 0;
        this.skills[1] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timers.IsTimerFinished("Skill1"))
        {
            this.skills[0] = 0;
        }
        if (Timers.IsTimerFinished("Skill2"))
        {
            this.skills[1] = 0;
        }
    }
    public void AddSkill() // Adding order: skill1 -> skill2 -> The skill which lasts for the least time.
    {
        if (skills[0] == 0)
        {
            StartCoroutine(DrawSkill(0));
        }
        else if (skills[1] == 0)
        {
            StartCoroutine(DrawSkill(1));
        }
        else
        {
            if (Timers.GetTimerPrgress("Skill1") < Timers.GetTimerPrgress("Skill2"))
            {
                StartCoroutine(DrawSkill(0));
            }
            else
            {
                StartCoroutine(DrawSkill(1));
            }
        }
    }
    private IEnumerator DrawSkill(int no)
    {
        this.skills[no] = -1;
        int lastTimeDraw = 0; // Avoid that the same icon run two times
        for (int i = 0; i < 15; i++)
        {
            int tempDrawingSkill = Random.Range(1, 10);
            while (tempDrawingSkill == lastTimeDraw)
            {
                tempDrawingSkill = Random.Range(1, 10);
            }
            Debug.Log("Drawing Skill: " + tempDrawingSkill);
            yield return new WaitForSeconds(0.5f);
        }
        int resultSkill = Random.Range(1, 10);
        Debug.Log("Resulting Skill: " + resultSkill);
        this.skills[no] = resultSkill;
    }
}
