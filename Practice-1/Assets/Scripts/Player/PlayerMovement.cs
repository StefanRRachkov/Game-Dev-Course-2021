using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 40f;

    private Rigidbody2D rigidBody;
    private float horizontalInput;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        ResolveLookDirection();
    }

   

    void FixedUpdate ()
    {
        // Move our character
        if (horizontalInput != 0)
        {
            Vector2 target = rigidBody.velocity;
            target.x = horizontalInput * moveSpeed;
            rigidBody.velocity = (target);
        }
    }

    void ResolveLookDirection()
    {
        if (Abs(rigidBody.velocity.x) > 0.01f) 
        {
            transform.localScale = new Vector3(Sign(rigidBody.velocity.x), 1, 1);
        }
    }

}
