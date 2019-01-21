using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public float enemySpeed = 4f;
    public float left = -4f;
    public float up = 7f;
    public float right = 3f;
    public float down = -5f;
    public float maxShotLength = 10f;
    public GameObject bullet;
    public GameObject player;
    private Quaternion quat;

    void Start() {
        Vector3 dir = player.transform.position - transform.position;
        quat = Quaternion.FromToRotation(Vector3.up, dir);
        transform.rotation = quat;
        InvokeRepeating("Shoot", 0, Random.value * maxShotLength);
        GetComponent<Rigidbody2D>().velocity = Vector3.Normalize(dir) * enemySpeed;
    }

    void Shoot() {
        Instantiate(bullet, transform.position, quat);
    }

    void FixedUpdate () {

        if (transform.position.y <= down)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y >= up)
        {
            Destroy(gameObject);
        }

        if (transform.position.x <= left)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x >= right)
        {
            Destroy(gameObject);
        }
    }
}
