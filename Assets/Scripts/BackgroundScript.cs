using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {

    private Vector2 location;
    Rigidbody2D backgroundRB;
    public float scrollSpeed = 1f;

    void Start () {
        backgroundRB = GetComponent<Rigidbody2D>();
        location = backgroundRB.position;
        backgroundRB.velocity = new Vector2(0, scrollSpeed);
	}
	
	void Update () {

        if (backgroundRB.position.y < (location.y - 10f))
        {
            backgroundRB.position = location;
        }
	}
}
