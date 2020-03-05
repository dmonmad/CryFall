using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 1f;

    public float jumpForce = 3f;

    public bool isGrounded = false;

    SpriteRenderer sprite;

    Animator anim;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
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
        transform.position += movement * Time.fixedDeltaTime * runSpeed;
    }


    // Start is called before the first frame update
    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }
    }



    internal void OnTouchGround()
    {
        isGrounded = true;
        anim.SetBool("isJumping", false);
    }

    internal void OnLeaveGround()
    {
        isGrounded = false;
    }

}
