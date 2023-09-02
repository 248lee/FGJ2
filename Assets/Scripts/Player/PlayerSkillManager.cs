// Author: JOHN LEE
// This will be merged into PlayerController later.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSkillManager : MonoBehaviour
{
    public TextMeshProUGUI[] skillsNoText = new TextMeshProUGUI[2];
    public float skillDuration = 8f;
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
        if (this.skills[0] != -1 && Timers.IsTimerFinished("Skill0")) // If the skill0 is finished, clear the skill effect
        {
            ClearSkillEffect(skills[0]);
            this.skills[0] = 0;
            skillsNoText[0].SetText("0");
        }
        if (this.skills[1] != -1 && Timers.IsTimerFinished("Skill1")) // If the skill1 is finished, clear the skill effect
        {
            ClearSkillEffect(skills[1]);
            this.skills[1] = 0;
            skillsNoText[1].SetText("0");
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
            if (Timers.GetTimerPrgress("Skill0") > Timers.GetTimerPrgress("Skill1"))
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
        float waitSeconds = 0f;
        int lastTimeDraw = 0; // Avoid that the same icon run two times
        for (int i = 0; i < 15; i++)
        {
            int tempDrawingSkill = Random.Range(1, 3);
            while (tempDrawingSkill == lastTimeDraw)
            {
                tempDrawingSkill = Random.Range(1, 3);
            }
            lastTimeDraw = tempDrawingSkill;
            //Debug.Log("Drawing Skill: " + tempDrawingSkill);
            skillsNoText[no].SetText(tempDrawingSkill.ToString());
            waitSeconds += 0.05f;
            yield return new WaitForSeconds(waitSeconds);
        }
        int resultSkill = Random.Range(1, 3);
        //Debug.Log("Resulting Skill: " + resultSkill);
        skillsNoText[no].SetText(resultSkill.ToString());
        this.skills[no] = resultSkill;
        AddSkillEffect(resultSkill);
        Timers.SetTimer("Skill" + no, skillDuration);
    }
    
    private void AddSkillEffect(int no)
    {
        for (int i = 1; i < 3; i++)
        {
            if (i != no)
            {
                ClearSkillEffect(i);
            }
        }
        switch (no)
        {
            case 1: // add skill no. 0
                Physics.IgnoreLayerCollision(7, 8, true);
                break;
            case 2:
                GetComponent<CharacterController>().enabled = false;
                break;
            default:
                break;
        }
    }
    private void ClearSkillEffect(int no)
    {
        /* Clear skill effects here :) */
        switch (no)
        {
            case 1: // clear skill no. 0
                Physics.IgnoreLayerCollision(7, 8, false);
                break;
            case 2:
                GetComponent<CharacterController>().enabled = true;
                break;
            default:
                break;
        }
    }
}
