using UnityEngine;

public class Enemy : MonoBehaviour {

    public float enemySpeed;
    public float maxShotLength = 2f;
    public GameObject bullet;
    public GameObject player;
    public GameObject spawner;

    private Quaternion quat;

    void Start() {
        Vector3 dir = player.transform.position - transform.position;
        quat = Quaternion.FromToRotation(Vector3.up, dir);
        transform.rotation = quat;
        Invoke("Shoot", 0f);
        GetComponent<Rigidbody2D>().velocity = Vector3.Normalize(dir) * enemySpeed;
    }

    void Shoot() {
        GameObject b = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        //b.GetComponent<Bullet>().speed = 2f;
        Invoke("Shoot", (Random.value + 1) * maxShotLength);
    }

    void FixedUpdate() {
        if (transform.position.y < -12) {
            Destroy(gameObject);
        }
    }
}
