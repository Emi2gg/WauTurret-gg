using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Settings.IsMuted = PlayerPrefs.GetInt("Mute",0) == 1;
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Mute()
    {
        AudioListener.volume = Settings.IsMuted ? 0 : 1;
    }
}
