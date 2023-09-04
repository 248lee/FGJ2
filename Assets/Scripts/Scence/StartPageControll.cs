using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPageControll : MonoBehaviour
{
    [SerializeField] GameObject SettingPage;
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
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
