using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    public float playerSpeed;
    public float left;
    public float up;
    public float right;
    public float down;
    public GameObject bullet;
    [HideInInspector]
    public int lives = 3;
    [HideInInspector]
    public int score;
    [HideInInspector]
    public bool isRespawning;


    void Update() {
        if (Input.GetKeyDown("space"))
        {
            GameObject b = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            Bullet b2 = b.GetComponent<Bullet>();
            b2.friendly = true;
        }
    }

    void FixedUpdate() {
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        GetComponent<Rigidbody2D>().velocity = targetVelocity * playerSpeed;

        if (transform.position.y <= down) {
            transform.position = new Vector2(transform.position.x, down);
        } else if (transform.position.y >= up) {
            transform.position = new Vector2(transform.position.x, up);
        }

        if (transform.position.x <= left) {
            transform.position = new Vector2(left, transform.position.y);
        } else if (transform.position.x >= right)  {
            transform.position = new Vector2(right, transform.position.y);
        }        
    }

    public void RespawnPlayer() {
        if (lives > 0)
        {
            isRespawning = true;
            gameObject.SetActive(false);
            gameObject.transform.position = new Vector2(0f, -4f);
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies) Destroy(enemy);
            GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
            foreach (GameObject proj in projectiles) Destroy(proj);
            lives--;
            gameObject.SetActive(true);
            isRespawning = false;
        }
        else Framework.GameOver();
    }
}