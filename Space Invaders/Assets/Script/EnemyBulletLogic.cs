using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletLogic : MonoBehaviour
{
    public float speed = 2.0F;
   // private bool hitAnEnemy = false;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = -transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Restart(){
        GameObject.Find("Life3").SetActive(true);
        GameObject.Find("Life2").SetActive(true);
        GameObject.Find("Life1").SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController.lives -= 1;

            if (PlayerController.lives == 2){
                GameObject.Find("Life3").SetActive(false);
            } else if (PlayerController.lives == 1){
                GameObject.Find("Life2").SetActive(false);
            } else if (PlayerController.lives == 0){
                GameObject.Find("Life1").SetActive(false);
            }

            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.y < -4.4f)
        {
            Destroy(gameObject);
        }
    }

}
