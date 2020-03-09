using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 1f;

    public float jumpForce = 3f;

    public bool isGrounded = false;

    public bool isOnIce = false;
    public PhysicsMaterial2D icyMaterial;
    public float speedOnIce = 20f;

    public bool isAlive;

    SpriteRenderer sprite;
    Rigidbody2D rb;
    Animator anim;

    private void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isAlive = true;
    }


    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(horizontalMovement));

        if (horizontalMovement == 1)
        {
            sprite.flipX = false;
        }
        else if (horizontalMovement == -1)
        {
            sprite.flipX = true;
        }

        Vector3 movement = new Vector3(horizontalMovement, 0f, 0f);

        if (isOnIce)
        {
            movement.x /= speedOnIce;
            rb.AddForce(movement, ForceMode2D.Impulse);
        }
        else
        {
            //rb.MovePosition(transform.position + movement * Time.fixedDeltaTime * runSpeed);
            transform.position += movement * Time.fixedDeltaTime * runSpeed;
        }




    }


    // Start is called before the first frame update
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }
    }



    internal void OnTouchGround(string type)
    {
        isGrounded = true;
        anim.SetBool("isJumping", false);
        if (type.Equals("IcyGround"))
        {
            Debug.Log("IsOnIce = true");
            isOnIce = true;
            GetComponent<BoxCollider2D>().sharedMaterial = icyMaterial;
        }
        else
        {
            isOnIce = false;
            GetComponent<BoxCollider2D>().sharedMaterial = null;
        }
    }

    internal void OnLeaveGround()
    {
        isGrounded = false;
        //if (isOnIce)
        //{
        //    isOnIce = false;
        //    GetComponent<EdgeCollider2D>().sharedMaterial = null;
        //}
    }

}
