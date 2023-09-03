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
    public Canvas resultUI;
    public Canvas playerUI;
    public bool isEnded;
    private bool state;

    // Start is called before the first frame update
    void Start()
    {
        player=FindObjectOfType<PlayerController>();
        Bombed();
        isEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == true)
        {
            winConditionText.text = "活下去！\n再稱" + (int)(this.winTime * (1 - Timers.GetTimerPrgress("WinTimer")));
            winConditionBGImage.color = Color.green;
        }
        else
        {
            winConditionText.text = "自殺吧！\n努力在" + (int)(this.winTime * (1 - Timers.GetTimerPrgress("WinTimer"))) + "秒內死吧";
            winConditionBGImage.color = Color.red;
        }
        if (isEnded) return;

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
        //Debug.Log(Timers.GetTimerPrgress("WinTimer"));
    }
    void Win()
    {
        isEnded = true;
        playerUI.gameObject.SetActive(false);
        resultUI.gameObject.SetActive(true);
        GameObject.FindWithTag("FailedUI").SetActive(false);
        GameObject.FindWithTag("SuccessedUI").SetActive(true);
        //Debug.Log("Win");
    }
    void Lose()
    {
        isEnded = true;
        playerUI.gameObject.SetActive(false);
        resultUI.gameObject.SetActive(true);
        GameObject.FindWithTag("FailedUI").SetActive(true);
        GameObject.FindWithTag("SuccessedUI").SetActive(false);
        //Debug.Log("Lose");
    }
    public void Bombed()
    {
        winSwitch=!winSwitch;
        if(winSwitch) 
        {
            this.state = true;
        }
        else
        {
            this.state = false;
        }
        Timers.AddTime("WinTimer", winTime);
    }
}
