using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufoScript : MonoBehaviour
{
    public float speed = 1.5f;
    public bool onLeft = false;
    // Start is called before the first frame update
    void Start()
    {
        // random #
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            transform.position = new Vector3(-6.73f, 3.4f, 0f);
            this.onLeft = true;
        } else
        {
            transform.position = new Vector3(6.73f, 3.4f, 0f);
            this.onLeft = false;
        }
        
    }

    void MoveRight()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    void MoveLeft()
    {
        transform.position -= Vector3.right * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (onLeft)
        {
            MoveRight();
        }
        else
        {
            MoveLeft();
        }
        if (transform.position.x > 9 || transform.position.x < -9)
        {
            Destroy(gameObject);
        }
        if (GameObject.Find("Cube").GetComponent<GameManager>().getGameWon())
        {
            Destroy(gameObject);
        }
    }
}
