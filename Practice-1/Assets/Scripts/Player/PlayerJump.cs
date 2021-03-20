using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;

    private Rigidbody2D rigidBody;

    private bool jump = false;
    public bool Jump
    {
        get => jump;
        set => jump = value;
    }

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //Debug.Log("Should Jump");
            jump = true;
        }
    }

    void FixedUpdate()
    {
        if (jump)
        {
            if (isGrounded())
            {
                //Debug.Log("Jump");
                Vector2 jumpVelocity = rigidBody.velocity;
                jumpVelocity.y = jumpForce;
                rigidBody.velocity = jumpVelocity;
            }
            jump = false;
        }
    }

    public bool isGrounded()
    {
        Vector3 boxOrigin = transform.position;
        boxOrigin.y -= 1;
        Collider2D[] arr = Physics2D.OverlapCircleAll(boxOrigin, 0.5f);
        foreach (Collider2D c in arr)
        {
            if (c.gameObject.layer == 8)
            {
                return true;
            }
        }
        return false;
    }

}
