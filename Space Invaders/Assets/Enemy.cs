using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2.0f;
    public float downSpeed = 10.0f;
    public static bool incr = true;
    public static bool moveDown = true;
    public static int score = 0;

    public static bool down = false;



    public int x;
    public int y;
    // Start is called before the first frame update

    void Start()
    {
        speed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {   
        if (incr)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
            transform.position -= Vector3.right * speed * Time.deltaTime;
        if (down)
        {
            MoveDown();
        }
    }

    public void Kill()
    {
        //Debug.Log(x.ToString() + " " + y.ToString());
        if (y == 0)
        {
            score += 10;
        }
        else if (y <= 2)
        {
            score += 20;
        }
        else
        {
            score += 40;
        }

        GameManager.enemiesAlive[x, y] = false;
        //Debug.Log(score);
        Destroy(gameObject);
    }

    // not used
    public void MoveDown()
    {
        transform.position += Vector3.down * 20 * Time.deltaTime;
    }

    public void SetCoords(int i, int j)
    {
        x = i;
        y = j;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            Debug.Log("won by ground");
            GameManager.gameWon = true;
            //Debug.Log("won by ground");
        }
    }

}
