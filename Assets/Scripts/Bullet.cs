using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 5.5f;

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.forward * speed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
