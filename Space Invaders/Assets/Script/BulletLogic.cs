using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    public float speed = 17.0F;
    private bool hitAnEnemy = false;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") && !hitAnEnemy)
        {
            Enemy en = (Enemy)collision.gameObject.GetComponent(typeof(Enemy));
            en.Kill();
            hitAnEnemy = true;
            PlayerController.canShoot = true;
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.y > 15)
        {
            PlayerController.canShoot = true;
            Destroy(gameObject);
        }
    }

}
