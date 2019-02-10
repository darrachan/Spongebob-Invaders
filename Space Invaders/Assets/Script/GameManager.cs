using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[,] enemies;
    public static bool[,] enemiesAlive;
    public GameObject enemy;
    public GameObject projectile;
    public GameObject player;
    public bool happenedOnce;

    public static bool gameWon = false;

    private GameObject furthestLeft;
    private GameObject furthestRight;

    public GameObject LoserText;
    public GameObject WinText;
    public GameObject btn1;
    public GameObject btn2;


    //private GameObject[] bottomEnemies;

    private int x = 0;
    private int y = 0;

    void Start()
    {
        Enemy.incr = true;
        enemies = new GameObject[11, 5];
        enemiesAlive = new bool[11, 5];
        InitializeEnemies();
        Invoke("Shoot", 0.5f);
        happenedOnce = false;

    }

    void Restart(){
        x = 0;
        y = 0;
        gameWon = false;
        Enemy.incr = true;
        enemies = new GameObject[11, 5];
        enemiesAlive = new bool[11, 5];
        InitializeEnemies();
        Invoke("Shoot", 0.5f);
        happenedOnce = false;      
    }

    // instantiates the block of enemies
    void InitializeEnemies()
    {
        for(int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                enemies[i,j] = Instantiate(enemy, new Vector3(-7.4f + i,j -1f, 0), Quaternion.identity);
                Enemy en = (Enemy)enemies[i, j].GetComponent(typeof(Enemy));
                en.SetCoords(i, j);
                enemiesAlive[i, j] = true;
               
            }
        }
    }
 
    // finds the enemies at the bottom of their row 
    GameObject[] FindBottomEnemies()
    {
        GameObject[] bottomEnemies = new GameObject[11];
        int count = 0;
        for (int i = 0; i < 11; i++)
        {
            int j = 0;
            bool found = false;
            while (j < 5 && !found)
            {
                if (enemiesAlive[i, j] == true)
                {
                    bottomEnemies[count] = enemies[i, j];
                    count++;
                    j++;
                    found = true;
                }
                else if (j == 4)
                {
                    bottomEnemies[count] = null;
                    count++;
                    found = true;
                }
                else
                {
                    j++;
                }
            }
        }
        return bottomEnemies;
    }

    // finds the enemy furthest to the left
    GameObject FindFurthestLeft()
    {
        int lowestISoFar = 10;
        int[] lowestLocation = new int[2] { 10, 4 };
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (enemiesAlive[i, j] && i < lowestISoFar)
                {
                    lowestISoFar = i;
                    lowestLocation[0] = i;
                    lowestLocation[1] = j;
                }
            }
        }
        return enemies[lowestLocation[0], lowestLocation[1]];
    }

    // finds the enemy furthest to the right
    GameObject FindFurthestRight()
    {
        int highestISoFar = 0;
        int[] lowestLocation = new int[2] { 0, 0 };
        for (int i = 10; i != 0; i--)
        {
            for (int j = 0; j < 5; j++)
            {
                if (enemiesAlive[i, j] && i > highestISoFar)
                {
                    highestISoFar = i;
                    lowestLocation[0] = i;
                    lowestLocation[1] = j;
                }
            }
        }   
        return enemies[lowestLocation[0], lowestLocation[1]];
    }


    // Update is called once per frame
    void Update()
    {
        
        GameObject[] existingEnemy = GameObject.FindGameObjectsWithTag("enemy");
        if (existingEnemy.Length == 0 && !gameWon)
        {
            gameWon = true;
            Debug.Log("no more enemies");
            ShowWinText();
            happenedOnce = true;
            ShowButtons();
        }
        if (PlayerController.lives <= 0 && !gameWon)  // can combine this in an or statement with the above if statement. just had it separate to show me why the game was lost
        {
            Debug.Log("lost all lives");
            gameWon = true;
        }
        if (!gameWon)   // while the game is still going, keep moving the jellyfish
        {
            SwapDirections();   
        }
        else  // game is lost. switch scenes? game over scene? or overlay?
        {
            if (!happenedOnce){
                DisableCharacters();
                ShowLoseText();
                happenedOnce = true;
                ShowButtons();
            }
        }
    }

    void ShowWinText(){
        WinText.SetActive(true);
       
    }

    void ShowLoseText(){
        LoserText.SetActive(true);
    }

    void ShowButtons(){
        btn1.SetActive(true);
        btn2.SetActive(true);
    }

    // picks a random enemy from the bottom enemies 
    GameObject PickRandomEnemy()
    {
        GameObject[] bottomEnemies = FindBottomEnemies();
        GameObject[] aliveBottomEnemies = new GameObject[11];
        int count = 0;
        for (int i = 0; i < 11; i++)
        {
            if (bottomEnemies[i] != null)
            {
                aliveBottomEnemies[count] = bottomEnemies[i];
                count++;
            }
        }
        return aliveBottomEnemies[Random.Range(0, count)];
    }

    // changes the directions the enemies are going by seeing if the furthest
    // left or right enemy has hit a certain coordinate, and then changes 
    // some variables in Enemy.cs that cause each enemy to change direction
    // and moves the enemy down
    void SwapDirections()
    {
        furthestLeft = FindFurthestLeft();
        furthestRight = FindFurthestRight();
        if (furthestLeft.transform.position.x < -7.45 && !Enemy.moveDown)
        {
            Enemy.incr = !Enemy.incr;
            MoveDown();
            Enemy.moveDown = !Enemy.moveDown;
        }

        if (furthestRight.transform.position.x > 7.45 && Enemy.moveDown)
        {
            Enemy.incr = !Enemy.incr;
            MoveDown();
            Enemy.moveDown = !Enemy.moveDown;
        }
    }


    // moves the enemies down
    // **** i feel like this should be moved to Enemy.cs to be more organized
    // and persistent (and instead of going through the list of enemies, just 
    // call it individual enemy.tried it and it makes the enemies just fall,
    // if any of you guys can fix that go for it, otherwise this works.
    void MoveDown()
    {
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (enemiesAlive[i, j])
                {
                    enemies[i, j].transform.position += Vector3.down * 20 * Time.deltaTime;
                    if (enemies[i, j].transform.position.y < -5.0f)
                    {
                        gameWon = true;
                        Debug.Log("lost by touching ground");
                    }
                }
            }
        }
    }

    // causes the random enemy to shoot in a random interval
    void Shoot()
    {
        float randomInterval = Random.Range(1.0f, 4.0f);  // can change this random time interval

        GameObject shootingEnemy = PickRandomEnemy();
        Instantiate(projectile, shootingEnemy.transform.position, shootingEnemy.transform.rotation);
       
        Invoke("Shoot", randomInterval);
    }

    // invokes Shoot()
    void ShootRandomly()
    {
        float randomInterval = Random.Range(2.0f, 10.0f);
        Invoke("Shoot", randomInterval);
    }

    // disables Spongebob and the jellyfish, was thinking about calling this when the game is over
    // but might not be needed if we change scenes or something
    void DisableCharacters()
    {
        player.SetActive(false);
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (enemiesAlive[i, j])
                {
                    Destroy(enemies[i, j]);
                }
            }
        }
    }

}
