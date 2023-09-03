using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsDebug : MonoBehaviour
{
    private PlayerSkillManager skillManager;

    // Start is called before the first frame update
    void Start()
    {
        skillManager = GetComponent<PlayerSkillManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (skillManager)
        {
            for (int i = 1; i <= skillManager.skillDataset.Length; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha0 + i))
                {
                    skillManager.DrawSkill_ForDebug(0, i);
                }
            }
        }
    }
}
