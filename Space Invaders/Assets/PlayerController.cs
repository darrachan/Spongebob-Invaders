using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    Rigidbody2D rb;
    public GameObject projectile;
    public Transform projectileLocation;
    public LineRenderer bullet;
    public static bool canShoot = true;
    public static int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
            Debug.Log("game over");
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.right * -playerSpeed * Time.deltaTime;
        }

        if (canShoot && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            Instantiate(projectile, new Vector3(projectileLocation.transform.position.x, projectileLocation.transform.position.y, 1), projectileLocation.rotation); //projectileLocation.position
            canShoot = false;
        }
    }



    private void FixedUpdate()
    {
        Move();
    }
}
