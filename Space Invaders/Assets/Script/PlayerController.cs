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
    public Transform pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // none
        if (canShoot && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            Instantiate(projectile, new Vector3(projectileLocation.transform.position.x, projectileLocation.transform.position.y, 1), projectileLocation.rotation); //projectileLocation.position
            canShoot = false;
        }

        if ((Input.GetKeyDown(KeyCode.Escape)))
        {
            Pause();
        }
    }

    void Restart(){
        lives = 3;
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

        // moved this because it wasn't registering space inputs all the time (downside of using FixedUpdate)
        /*
        if (canShoot && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            Instantiate(projectile, new Vector3(projectileLocation.transform.position.x, projectileLocation.transform.position.y, 1), projectileLocation.rotation); //projectileLocation.position
            canShoot = false;
        }
        */
    }

    private void Pause()
    {
        if (pauseMenu.gameObject.activeInHierarchy == false)
        {
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }


    //We should try and not use FixedUpdate because it processes frames in different ways (no frames, many, or few frames per second)
    private void FixedUpdate()
    {
        Move();
    }
}
