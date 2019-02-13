using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCommands : MonoBehaviour
{

    public GameObject pauseMenu;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
