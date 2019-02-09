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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController.lives -= 1;
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
