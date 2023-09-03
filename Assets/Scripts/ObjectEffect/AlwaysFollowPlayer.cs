using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysFollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlayerController player;
    [SerializeField] float cameraOffset;
    void Start()
    {
        player=FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position+(Vector3.up* cameraOffset);
    }
}
