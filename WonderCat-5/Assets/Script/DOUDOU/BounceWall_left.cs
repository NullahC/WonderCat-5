﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceWall_left : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(7, 5);
        collision.gameObject.GetComponent<SpriteRenderer>().flipX = !collision.gameObject.GetComponent<SpriteRenderer>().flipX;
    }
}
