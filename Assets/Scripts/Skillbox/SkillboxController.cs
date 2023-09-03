// Author: JOHN LEE

using System.Collections;
using System.Collections.Generic;
using SupSystem;
using UnityEngine;

public class SkillboxController : MonoBehaviour
{
    public float triggerDistance = .5f;
    private GameObject player;
    private SoundController sControl;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Character");
        sControl = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundController>();
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(Vector3.Distance(transform.position, player.transform.position));
        if (Vector3.Distance(transform.position, player.transform.position) < triggerDistance) // if the player is closed enough to the skillbox
        {
            sControl.PlayAudio("技能箱", SoundController.AudioType.SE, false);
            player.GetComponent<PlayerSkillManager>().AddSkill();
            player.GetComponent<PlayerController>().AddHP(1);
            Object.Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        // Set the gizmo color
        Gizmos.color = Color.blue;

        // Draw a wireframe sphere gizmo around the GameObject's position
        Gizmos.DrawWireSphere(transform.position, triggerDistance);
    }
}
