// Author: JOHN LEE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillboxController : MonoBehaviour
{
    public float triggerDistance = .5f;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < triggerDistance) // if the player is closed enough to the skillbox
        {
            // code here
        }
    }
    
}
