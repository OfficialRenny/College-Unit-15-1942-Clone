using UnityEngine;

public class Enemy : MonoBehaviour {

    public float enemySpeed;
    public float maxShotLength = 2f;
    public GameObject bullet;
    public GameObject player;
    public GameObject spawner;
    public GameObject explosion;
    public bool isBoss;
    public bool canBeDestroyed;
    public float health = 100;
    private Quaternion quat;
    private Bullet b2;
    private float turnSpeed;
    public AudioClip flyby;
    AudioSource audioSource;
    private bool playedAudio = false;


    void Start() {
        audioSource = GetComponent<AudioSource>();
        if (isBoss) {
            turnSpeed = 5f;
            SetHealth();
            SpawnBoss();
        } else
        {
            turnSpeed = 0.5f;
            SetHealth();
            Vector3 dir = player.transform.position - transform.position;
            quat = Quaternion.FromToRotation(Vector3.up, dir);
            transform.rotation = quat;
            Invoke("Shoot", 0f);
            GetComponent<Rigidbody2D>().velocity = Vector3.Normalize(dir) * enemySpeed;
        }
    }

    void SpawnBoss() {
        this.enemySpeed /= 10;
        Vector3 dir = player.transform.position - transform.position;
        quat = Quaternion.FromToRotation(Vector3.up, dir);
        transform.rotation = quat;
        Invoke("Shoot", 0f);
        GetComponent<Rigidbody2D>().velocity = Vector3.Normalize(dir) * (enemySpeed);
        gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
    }

    void SetHealth()
    {
        health = 50;
        if (isBoss)
        {
            this.health = (Level.curLevel * health) + 1000;
        } else
        {
            this.health = Level.curLevel * health;
        }
        canBeDestroyed = true;
    }

    void Shoot() {
        GameObject b = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        b2 = b.GetComponent<Bullet>();
        b2.speed = this.enemySpeed + b2.speed + 1f;
        b2.shooter = this.gameObject;
        Invoke("Shoot", (Random.value + 1) * maxShotLength);
    }

    private void Update()
    {
        Quaternion current = transform.rotation;
        Vector3 dir = player.transform.position - transform.position;
        Quaternion target = Quaternion.FromToRotation(Vector3.up, dir);

        transform.rotation = Quaternion.Lerp(current, target, Mathf.Min(1.0f, Time.deltaTime * turnSpeed));
        Vector3 lerpedDir = transform.rotation * Vector3.up;

        GetComponent<Rigidbody2D>().velocity = Vector3.Normalize(lerpedDir) * enemySpeed;

        if (this.transform.position.y < player.transform.position.y && !playedAudio)
        {
            audioSource.PlayOneShot(flyby, 0.7F);
            this.playedAudio = true;
            Debug.Log("Played Flyby Sound");
        }

        if (health < 0)
        {
            Explode();
        }
    }
    
    void Explode()
    {
        player.GetComponent<Player>().score += 100;
        Instantiate(explosion, transform.position, new Quaternion(1.0f, 0.0f, 0.0f, Mathf.Deg2Rad * 90f));
        Destroy(gameObject);
    }

    void FixedUpdate() {
        if ((transform.position.y < -12) || (transform.position.y > 7) || (transform.position.x < -3) || (transform.position.x > 3)) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Instantiate(explosion, col.gameObject.transform.position, new Quaternion(1.0f, 0.0f, 0.0f, 1.5708f));
            Destroy(gameObject);
            if (!col.gameObject.GetComponent<Player>().isRespawning) col.gameObject.GetComponent<Player>().RespawnPlayer();
        }
    }
}
