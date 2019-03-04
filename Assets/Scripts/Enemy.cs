using UnityEngine;

public class Enemy : MonoBehaviour {

    public float enemySpeed;
    public float maxShotLength = 2f;
    public GameObject bullet;
    public GameObject player;
    public GameObject spawner;
    public bool isBoss;
    public float health = 100;
    private Quaternion quat;
    private Bullet b2;

    void Start() {
        if (isBoss) {
            SpawnBoss();
        } else
        {
            SetHealth();
            Vector3 dir = player.transform.position - transform.position;
            quat = Quaternion.FromToRotation(Vector3.up, dir);
            transform.rotation = quat;
            Invoke("Shoot", 0f);
            GetComponent<Rigidbody2D>().velocity = Vector3.Normalize(dir) * enemySpeed;
        }
    }

    void SpawnBoss() {
        Vector3 dir = player.transform.position - transform.position;
        quat = Quaternion.FromToRotation(Vector3.up, dir);
        transform.rotation = quat;
        Invoke("Shoot", 0f);
        GetComponent<Rigidbody2D>().velocity = Vector3.Normalize(dir) * enemySpeed;
    }

    void SetHealth()
    {
        if (isBoss)
        {
            this.health = (Level.curLevel * health) + 1000;
        } else
        {
            this.health = Level.curLevel * health;
        }
    }

    void Shoot() {
        GameObject b = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        b2 = b.GetComponent<Bullet>();
        b2.speed = this.enemySpeed + b2.speed + 1f;
        b2.shooter = this.gameObject;
        Invoke("Shoot", (Random.value + 1) * maxShotLength);
    }

    void FixedUpdate() {
        if (transform.position.y < -12) {
            Destroy(gameObject);
        }
    }
}
