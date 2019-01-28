using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 5.5f;
    public bool friendly;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = (transform.rotation * Vector3.up) * speed;
    }

    private void FixedUpdate()
    {
        if (transform.position.y < - 4.8) Destroy(gameObject);
        if (transform.position.y > 4.8) Destroy(gameObject);
    }

}
