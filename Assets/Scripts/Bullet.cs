using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 5.5f;
    public bool friendly;
    public GameObject shooter;
    public GameObject explosion;
    void Start() {
        GetComponent<Rigidbody2D>().velocity = (transform.rotation * Vector3.up) * speed;
    }

    private void FixedUpdate() {
        if (transform.position.y < - 4.8) Destroy(gameObject);
        if (transform.position.y > 4.8) Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy" && friendly) {
            if (col.gameObject.GetComponent<Enemy>().isBoss) EnemySpawner.bossDestroyed = true;
            col.gameObject.GetComponent<Enemy>().health -= 100;
            Destroy(gameObject);
        } else if (col.gameObject.tag == "Player" && !friendly && !col.gameObject.GetComponent<Player>().isRespawning) {
            col.gameObject.GetComponent<Player>().RespawnPlayer();
        }
    }
}
