// Author: JOHN LEE
// This will be merged into PlayerController later.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillManager : MonoBehaviour
{
    public Image[] skillIcons = new Image[2];
    public float skillDuration = 8f;
    public float skill2_AddHpPeriod = 0.7f;
    public float skill3_DropHpPeriod = 0.7f;
    private int[] skills = new int[2];
    private Coroutine[] skillCoroutines = new Coroutine[2];
    private bool isSkill2Adding = false;
    private bool isSkill3Dropping = false;

    // Start is called before the first frame update
    void Start()
    {
        this.skills[0] = 0;
        this.skills[1] = 0;
        this.isSkill2Adding = false;
        this.isSkill3Dropping = false;
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
        if (isSkill3Dropping)
        {
            if (Timers.IsTimerFinished("skill3DropHpCooldown"))
            {
                Timers.SetTimer("skill3DropHpCooldown", skill2_AddHpPeriod);
                GetComponent<PlayerController>().DropHP(1);
            }
        }
        //print(Physics.GetIgnoreLayerCollision(7, 8));
        if (this.skills[0] != -1 && Timers.IsTimerFinished("Skill0")) // If the skill0 is finished, clear the skill effect
        {
            ClearSkillEffect(skills[0]);
            this.skills[0] = 0;
            print(Resources.Load<Sprite>("Icons/0"));
            skillIcons[0].sprite = Resources.Load<Sprite>("Icons/0");
        }
        if (this.skills[1] != -1 && Timers.IsTimerFinished("Skill1")) // If the skill1 is finished, clear the skill effect
        {
            ClearSkillEffect(skills[1]);
            this.skills[1] = 0;
            skillIcons[1].sprite = Resources.Load<Sprite>("Icons/0");
        }
    }
    public void AddSkill() // Adding order: skill1 -> skill2 -> The skill which lasts for the least time.
    {
        if (skills[0] == 0)
        {
            if (this.skillCoroutines[0] != null)
            {
                StopCoroutine(skillCoroutines[0]);
            }
            this.skillCoroutines[0] = StartCoroutine(DrawSkill(0));
        }
        else if (skills[1] == 0)
        {
            if (this.skillCoroutines[1] != null)
            {
                StopCoroutine(skillCoroutines[1]);
            }
            this.skillCoroutines[1] = StartCoroutine(DrawSkill(1));
        }
        else if (skills[0] > 0 && skills[1] == -1)
        {
            if (this.skillCoroutines[0] != null)
            {
                StopCoroutine(skillCoroutines[0]);
            }
            this.skillCoroutines[0] = StartCoroutine(DrawSkill(0));
        }
        else if (skills[0] == -1 && skills[1] > 0)
        {
            if (this.skillCoroutines[1] != null)
            {
                StopCoroutine(skillCoroutines[1]);
            }
            this.skillCoroutines[1] = StartCoroutine(DrawSkill(1));
        }
        else if (skills[0] > 0 && skills[1] > 0)
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
    private IEnumerator DrawSkill(int slotNo)
    {
        ClearSkillEffect(skills[slotNo]);
        this.skills[slotNo] = -1;
        float waitSeconds = 0f;
        int lastTimeDraw = 0; // Avoid that the same icon runs two times
        for (int i = 0; i < 15; i++)
        {
            int tempDrawingSkill = Random.Range(1, 4);
            while (tempDrawingSkill == lastTimeDraw)
            {
                tempDrawingSkill = Random.Range(1, 4);
            }
            lastTimeDraw = tempDrawingSkill;
            //Debug.Log("Drawing Skill: " + tempDrawingSkill);
            skillIcons[slotNo].sprite = Resources.Load<Sprite>("Icons/" + tempDrawingSkill);
            waitSeconds += 0.05f;
            yield return new WaitForSeconds(waitSeconds);
        }
        int resultSkill = Random.Range(1, 4);
        while (true) // Check whether skill0 and skill1 has the same skill No. If same, redraw.
        {
            bool isSkillConflict = false;
            for (int i = 0; i < 2; i++)
            {
                if (i != slotNo && skills[i] == resultSkill)
                {
                    isSkillConflict = true;
                    break;
                }
            }
            if (isSkillConflict)
            {
                resultSkill = Random.Range(1, 4);
            }
            else
            {
                break;
            }
        }

        //Debug.Log("Resulting Skill: " + resultSkill);
        skillIcons[slotNo].sprite = Resources.Load<Sprite>("Icons/" + resultSkill);
        this.skills[slotNo] = resultSkill;
        AddSkillEffect(resultSkill);
        Timers.SetTimer("Skill" + slotNo, skillDuration);
    }

    private void AddSkillEffect(int no)
    {
        switch (no)
        {
            case 1: // add skill no. 1
                Physics.IgnoreLayerCollision(7, 8, true);
                break;
            case 2: // add skill no. 2
                this.isSkill2Adding = true;
                Timers.SetTimer("skill2AddHpCooldown", skill2_AddHpPeriod);
                break;
            case 3:
                this.isSkill3Dropping = true;
                Timers.SetTimer("skill3DropdHpCooldown", skill2_AddHpPeriod);
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
            case 1: // clear skill no. 1
                Physics.IgnoreLayerCollision(7, 8, false);
                break;
            case 2: // clear skill no. 2
                this.isSkill2Adding = false;
                break;
            case 3:
                this.isSkill3Dropping = false;
                break;
            default:
                break;
        }
    }
}
