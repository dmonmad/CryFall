using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public GameObject player;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            player.GetComponent<PlayerMovement>().isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            player.GetComponent<PlayerMovement>().isGrounded = false;
        }
    }
}
