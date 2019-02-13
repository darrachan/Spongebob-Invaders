using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCommands : MonoBehaviour
{
    public GameObject menu;
    public GameObject HowToPlayScreen;
    public GameObject Back;


    public void GoToButtonScreen(){
        Debug.Log("Clicked");
        GameObject.Find("KrustyKrew").SetActive(false);
        GameObject.Find("Text").SetActive(false);
        GameObject.Find("face").SetActive(false);
        GameObject.Find("Button").SetActive(false);
        LoadScreen();
    }

    public void LoadScreen(){
        menu.SetActive(true);
    }

    public void Quit(){
        Application.Quit();
    }

    public void goToGame(){
        Application.LoadLevel("Game");
    }

    public void goToHowToPlay(){
        menu.SetActive(false);
        HowToPlayScreen.SetActive(true);
        Back.SetActive(true);
    }

    public void goBack(){
        HowToPlayScreen.SetActive(false);
        Back.SetActive(false);
        menu.SetActive(true);
    }
}
