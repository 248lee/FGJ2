// Author: JOHN LEE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillboxController : MonoBehaviour
{
    public float triggerDistance = .5f;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        Debug.Log(Vector3.Distance(transform.position, player.transform.position));
        if (Vector3.Distance(transform.position, player.transform.position) < triggerDistance) // if the player is closed enough to the skillbox
        {
            player.GetComponent<PlayerSkillManager>().AddSkill();
            Destroy(gameObject);
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
