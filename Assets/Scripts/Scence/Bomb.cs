using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public bool winSwitch=true;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player=FindObjectOfType<PlayerController>().GameObject().GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (winSwitch == true)
        {
            if (player.playerHP<=0) {
                Win();
            }
        }
    }
     void Win()
    {

    }
    void Lose()
    {

    }
    public void Bombed()
    {
        
        winSwitch=!winSwitch;
    }
}
