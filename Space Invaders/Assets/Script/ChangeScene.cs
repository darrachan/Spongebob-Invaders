using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void ChangeSceneToMainMenu(){
        Application.Quit();
        
        //Debug.Log("GoToMainMenuClicked");
        //Application.LoadLevel("Main Menu");
    }

    public void ChangeToGameScene(){
        Debug.Log("RestartClicked");

        if (GameObject.Find("Restart"))
        {
            GameObject.Find("Restart").SetActive(false);
        }
       
        if (GameObject.Find("MainMenu"))
        {
            GameObject.Find("MainMenu").SetActive(false);
        }
        

        if (GameObject.Find("YouWin"))
        {
            GameObject.Find("YouWin").SetActive(false);
        }
        if (GameObject.Find("LoseText"))
        {
            GameObject.Find("LoseText").SetActive(false);
        }

        if (GameObject.Find("Life3"))
        {
            GameObject.Find("Life3").SetActive(true);
        }

        if (GameObject.Find("Life2"))
        {
            GameObject.Find("Life2").SetActive(true);
        }

        if (GameObject.Find("Life1"))
        {
            GameObject.Find("Life1").SetActive(true);
        }

        GameObject.Find("Cube").GetComponent<GameManager>().Restart();
        GameObject.Find("spongebob").GetComponent<PlayerController>().Restart();
        GameObject.Find("EnemyRestartLogic").GetComponent<Enemy>().Restart();
        //GameObject.Find("EnemyRestartLogic").GetComponent<EnemyBulletLogic>().Restart();
        //Application.LoadLevel("Game");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        if (GameObject.Find("MainMenuRestartLogic").GetComponent<SwitchAndLoad>().fromMainMenu)
        {
            GameObject.Find("MainMenuRestartLogic").GetComponent<SwitchAndLoad>().fromMainMenu = false;
            ChangeToGameScene();
        }

    }
}
