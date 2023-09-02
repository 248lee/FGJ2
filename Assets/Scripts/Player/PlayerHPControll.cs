using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPControll : MonoBehaviour
{
    // Start is called before the first frame update
    int playerHP;
    private void Start()
    {
        playerHP=transform.GetComponent<PlayerController>().playerHP;
    }
   
}
