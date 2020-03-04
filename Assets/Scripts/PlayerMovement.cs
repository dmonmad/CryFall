using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 40f;

    public float jumpForce = 5f;

    public bool isGrounded = false;

    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        Jump();        
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            sprite.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            sprite.flipX = true;
        }
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.fixedDeltaTime * runSpeed;
    }


    // Start is called before the first frame update
    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    
}
