using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysFollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlayerController player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }
}
