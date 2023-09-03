using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPageControll : MonoBehaviour
{
    [SerializeField]string startPage;
    [SerializeField] GameObject SettingPage;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(startPage);
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
