using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float playerSpeed;
    public float left;
    public float up;
    public float right;
    public float down;
    public GameObject bullet;
    public Text guiLives;
    public Text guiScore;
    public Text guiLevel;
    public Text guiCurLevel;
    public GameObject explosion;
    [HideInInspector]
    public int lives = 3;
    [HideInInspector]
    public int score = 0;
    [HideInInspector]
    public bool isRespawning;

    private void Awake()
    {
        score = 0;
        if (Level.curLevel < 1) Level.curLevel = 1;
        guiCurLevel.text = "LEVEL " + Level.curLevel;
        StartCoroutine(DisplayLevel(guiCurLevel));
    }

    IEnumerator DisplayLevel(Text level)
    {
        yield return new WaitForSeconds(0.2f);
        level.enabled = true;
        yield return new WaitForSeconds(0.2f);
        level.enabled = false;
        yield return new WaitForSeconds(0.2f);
        level.enabled = true;
        yield return new WaitForSeconds(0.2f);
        level.enabled = false;
        yield return new WaitForSeconds(0.2f);
        level.enabled = true;
        yield return new WaitForSeconds(0.2f);
        level.enabled = false;
        yield return new WaitForSeconds(0.2f);
        level.enabled = true;
        yield return new WaitForSeconds(0.2f);
        level.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Shoot();
        }
        guiLevel.text = "LVL " + Level.curLevel;
        guiLives.text = "Lives: " + lives;
        guiScore.text = "Score:\n" + score;
        if (lives < 1 && !Framework.areWeFading) Framework.GameOver();
        if ((score >= Level.curLevel * 1500 && Level.curLevel <= 5) || (score >= Level.curLevel * 1000 && Level.curLevel > 5 && EnemySpawner.bossDestroyed))
        {
            Framework.NextLevel();
        }
    }

    private void Shoot() {
        GameObject b = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        Bullet b2 = b.GetComponent<Bullet>();
        b2.friendly = true;
        b2.shooter = this.gameObject;
    }

    int i;
    private void FixedUpdate()
    {
        if (!Framework.areWeFading || !isRespawning) { 
            i++;
            if (i >= 10)
            {
                score++;
                i = 0;
            }
        }
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        GetComponent<Rigidbody2D>().velocity = targetVelocity * playerSpeed;

        if (transform.position.y <= down)
        {
            transform.position = new Vector2(transform.position.x, down);
        }
        else if (transform.position.y >= up)
        {
            transform.position = new Vector2(transform.position.x, up);
        }

        if (transform.position.x <= left)
        {
            transform.position = new Vector2(left, transform.position.y);
        }
        else if (transform.position.x >= right)
        {
            transform.position = new Vector2(right, transform.position.y);
        }
    }

    public void RespawnPlayer()
    {
        if (lives > 0)
        {
            isRespawning = true;
            gameObject.transform.position = new Vector2(0f, -4f);
            StartCoroutine(ToggleRenderer());
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies) Destroy(enemy);
            GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (GameObject proj in projectiles) Destroy(proj);
            lives--;
        }
        else
        {
            Framework.SetHighScore(Level.curLevel, score);
            Framework.GameOver();
        }
    }

    IEnumerator ToggleRenderer()
    {
        Instantiate(explosion, gameObject.transform.position, new Quaternion(1.0f, 0.0f, 0.0f, 1.5708f));
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        isRespawning = false;
    }
    
}