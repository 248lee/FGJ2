using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bomb : MonoBehaviour
{
    public bool winSwitch = false;
    PlayerController player;
    [SerializeField] float winTime;

    public TextMeshProUGUI winConditionText;
    public Image winConditionBGImage;

    // Start is called before the first frame update
    void Start()
    {
        player=FindObjectOfType<PlayerController>();
        Bombed();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.playerHP <= 0)
        {
            if (winSwitch)
            {
                Lose();
            }
            else
            {
                Win();
            }
        }
        if (Timers.IsTimerFinished("WinTimer") && winSwitch)
        {
            Win();
        }
        
    }
     void Win()
    {
        Debug.Log("Win");
    }
    void Lose()
    {
        Debug.Log("Lose");
    }
    public void Bombed()
    {
        winSwitch=!winSwitch;
        if(winSwitch) 
        {
            winConditionText.text = "活下去！";
            winConditionBGImage.color = Color.green;
            Timers.SetTimer("WinTimer", winTime);
        }
        else
        {
            winConditionText.text = "自殺吧！";
            winConditionBGImage.color = Color.red;
        }
    }
}
