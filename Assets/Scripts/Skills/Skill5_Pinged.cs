using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill5_Pinged : Skill
{
    public float periodMinSecond = 1.1f;
    public float periodMaxSecond = 4f;
    public float playAfterRecordSecond = 1f;
    private bool isSkill5Pinging = false;
    private Vector3 recordedPosition;
    private bool isReadyToPlay = false;
    // Start is called before the first frame update
    void Start()
    {
        this.isSkill5Pinging = false;
        this.isReadyToPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSkill5Pinging)
        {
            if (Timers.IsTimerFinished("PingRecordPosition"))
            {
                // perform record position
                recordedPosition = transform.position;
                Timers.SetTimer("PlayRecordedPosition", playAfterRecordSecond);
                this.isReadyToPlay = true;

                float recordPeriod = Random.Range(periodMinSecond, periodMaxSecond);
                Timers.SetTimer("PingRecordPosition", recordPeriod);
            }
        }
    }
    private void LateUpdate()
    {
        if (isReadyToPlay && Timers.IsTimerFinished("PlayRecordedPosition"))
        {
            // perform back to the recorded position
            transform.position = recordedPosition;
            this.isReadyToPlay = false;
        }
    }
    public override void CastSkill()
    {
        this.isSkill5Pinging = true;
    }
    public override void ClearSkill()
    {
        this.isSkill5Pinging = false;
    }
}
