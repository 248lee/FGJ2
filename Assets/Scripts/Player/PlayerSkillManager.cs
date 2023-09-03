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
    private int[] skillSlots = new int[2];
    private Coroutine[] skillCoroutines = new Coroutine[2];
    public Skill[] skillDataset = new Skill[9];

    // Start is called before the first frame update
    void Start()
    {
        this.skillSlots[0] = 0;
        skillIcons[0].sprite = Resources.Load<Sprite>("Icons/0");
        this.skillSlots[1] = 0;
        skillIcons[1].sprite = Resources.Load<Sprite>("Icons/0");
        this.skillSlots[1] = 0;
        skillDataset[1] = GetComponent<Skill1_WrapWall>();
        skillDataset[2] = GetComponent<Skill2_AddHP>();
        skillDataset[3] = GetComponent<Skill3_DropHP>();
        skillDataset[4] = GetComponent<Skill4_SpeedUp>();
        skillDataset[5] = GetComponent<Skill5_Pinged>();
        skillDataset[6] = GetComponent<Skill6_ReverseDamage>();
        skillDataset[7] = GetComponent<Skill7_Absorb>();
        skillDataset[8] = GetComponent<Skill8_Float>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //print(Physics.GetIgnoreLayerCollision(7, 8));
        if (this.skillSlots[0] > 0 && Timers.IsTimerFinished("Skill0")) // If the skill0 is finished, clear the skill effect
        {
            ClearSkillEffect(skillSlots[0]);
            this.skillSlots[0] = 0;
            skillIcons[0].sprite = Resources.Load<Sprite>("Icons/0");
        }
        if (this.skillSlots[1] > 0 && Timers.IsTimerFinished("Skill1")) // If the skill1 is finished, clear the skill effect
        {
            ClearSkillEffect(skillSlots[1]);
            this.skillSlots[1] = 0;
            skillIcons[1].sprite = Resources.Load<Sprite>("Icons/0");
        }
    }
    public void AddSkill() // Adding order: skill1 -> skill2 -> The skill which lasts for the least time.
    {
        if (skillSlots[0] == 0)
        {
            if (this.skillCoroutines[0] != null)
            {
                StopCoroutine(skillCoroutines[0]);
            }
            this.skillCoroutines[0] = StartCoroutine(DrawSkill(0));
        }
        else if (skillSlots[1] == 0)
        {
            if (this.skillCoroutines[1] != null)
            {
                StopCoroutine(skillCoroutines[1]);
            }
            this.skillCoroutines[1] = StartCoroutine(DrawSkill(1));
        }
        else if (skillSlots[0] > 0 && skillSlots[1] == -1)
        {
            if (this.skillCoroutines[0] != null)
            {
                StopCoroutine(skillCoroutines[0]);
            }
            this.skillCoroutines[0] = StartCoroutine(DrawSkill(0));
        }
        else if (skillSlots[0] == -1 && skillSlots[1] > 0)
        {
            if (this.skillCoroutines[1] != null)
            {
                StopCoroutine(skillCoroutines[1]);
            }
            this.skillCoroutines[1] = StartCoroutine(DrawSkill(1));
        }
        else if (skillSlots[0] > 0 && skillSlots[1] > 0)
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
        if (skillSlots[slotNo] > 0)
            ClearSkillEffect(skillSlots[slotNo]);
        this.skillSlots[slotNo] = -1;
        float waitSeconds = 0f;
        int lastTimeDraw = 0; // Avoid that the same icon runs two times
        for (int i = 0; i < 15; i++) // show random get skills effect
        {
            int tempDrawingSkill = Random.Range(1, skillDataset.Length);
            while (tempDrawingSkill == lastTimeDraw)
            {
                tempDrawingSkill = Random.Range(1, skillDataset.Length);
            }
            lastTimeDraw = tempDrawingSkill;
            //Debug.Log("Drawing Skill: " + tempDrawingSkill);
            skillIcons[slotNo].sprite = Resources.Load<Sprite>("Icons/" + tempDrawingSkill);
            waitSeconds += 0.05f;
            yield return new WaitForSeconds(waitSeconds);
        }

        int resultSkill = Random.Range(7, skillDataset.Length);
        while (true) // Check whether skill0 and skill1 has the same skill No. If same, redraw.
        {
            bool isSkillConflict = false;
            for (int i = 0; i < 2; i++)
            {
                if (i != slotNo && skillSlots[i] == resultSkill)
                {
                    isSkillConflict = true;
                    break;
                }
            }
            if (isSkillConflict)
            {
                resultSkill = Random.Range(7, skillDataset.Length);
            }
            else
            {
                break;
            }
        }

        //Debug.Log("Resulting Skill: " + resultSkill);
        skillIcons[slotNo].sprite = Resources.Load<Sprite>("Icons/" + resultSkill);
        this.skillSlots[slotNo] = resultSkill;
        AddSkillEffect(resultSkill);
        Timers.SetTimer("Skill" + slotNo, skillDuration);
    }

    public void DrawSkill_ForDebug(int slotNo, int skill)
    {
        if (skillSlots[slotNo] > 0)
            ClearSkillEffect(skillSlots[slotNo]);
        this.skillSlots[slotNo] = -1;

        //Debug.Log("Resulting Skill: " + resultSkill);
        skillIcons[slotNo].sprite = Resources.Load<Sprite>("Icons/" + skill);
        this.skillSlots[slotNo] = skill;
        AddSkillEffect(skill);
        Timers.SetTimer("Skill" + slotNo, skillDuration);
    }

    private void AddSkillEffect(int no)
    {
        this.skillDataset[no].CastSkill();
        //switch (no)
        //{
           
        //    case 2: // add skill no. 2
        //        
        //        break;
        //    case 3:
        //        
        //        break;
        //    default:
        //        break;
        //}
    }
    private void ClearSkillEffect(int no)
    {
        /* Clear skill effects here :) */
        this.skillDataset[no].ClearSkill();
        //switch (no)
        //{
        //    case 1: // clear skill no. 1
        //        Physics.IgnoreLayerCollision(7, 8, false);
        //        break;
        //    case 2: // clear skill no. 2
        //        
        //        break;
        //    case 3:
        //        
        //        break;
        //    default:
        //        break;
        //}
    }
}
