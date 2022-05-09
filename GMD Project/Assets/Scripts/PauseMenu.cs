using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Play()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }
}