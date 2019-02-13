using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchAndLoad : MonoBehaviour
{

    public bool fromMainMenu = true;

    void Awake()
    {
        //Ensure the script is not deleted while loading
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
            //Destroy any copies
            Destroy(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            fromMainMenu = true;
            //Debug.Log("At Main Menu");
        }
    }
}
