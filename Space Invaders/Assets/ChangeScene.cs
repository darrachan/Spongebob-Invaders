using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void ChangeSceneToMainMenu(){
        Application.LoadLevel("Main Menu");
    }

    public void ChangeToGameScene(){
        Application.LoadLevel("Game");
    }
}
