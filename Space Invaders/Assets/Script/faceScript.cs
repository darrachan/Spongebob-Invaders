using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class faceScript : MonoBehaviour
{
    public float speed = 2.5f;
    public bool stop = false;
    public Text text;
    public Text text2;
    public bool runOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(transform.position.y);
        if(transform.position.y < -0.25){
            transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
        }

        if(transform.position.y >= -0.25 && !runOnce){
            StartCoroutine(startText());
            text.enabled = true;
            runOnce = true;
        }
    }

    IEnumerator startText(){
        yield return new WaitForSeconds(1);
        text2.enabled = true;
    }
}
