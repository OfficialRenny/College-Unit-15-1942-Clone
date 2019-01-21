using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 5.5f;
    public bool friendly;

    void Start()
    {
        if (friendly) Debug.Log("Player fired a bullet!");
        GetComponent<Rigidbody2D>().velocity = (transform.rotation * Vector3.up) * speed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
