using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPageControll : MonoBehaviour
{
    [SerializeField] GameObject StartBtn;
    [SerializeField] GameObject SettingsBtn;
    [SerializeField] GameObject QuitBtn;
    [SerializeField] GameObject IntroBtn;

    [SerializeField] GameObject SettingPage;
    [SerializeField] GameObject IntroPage;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartGame(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SwithSetting()
    {
        SettingPage.SetActive(!SettingPage.activeSelf);

        StartBtn.SetActive(!StartBtn.activeSelf);
        SettingsBtn.SetActive(!SettingsBtn.activeSelf);
        QuitBtn.SetActive(!QuitBtn.activeSelf);
        IntroBtn.SetActive(!IntroBtn.activeSelf);
    }

    public void SwithIntro()
    {
        IntroPage.SetActive(!IntroPage.activeSelf);

        StartBtn.SetActive(!StartBtn.activeSelf);
        SettingsBtn.SetActive(!SettingsBtn.activeSelf);
        QuitBtn.SetActive(!QuitBtn.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
