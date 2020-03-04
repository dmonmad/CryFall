using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekPlayer : MonoBehaviour
{

    public PlayerMovement player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0,0,-10);

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        Vector3 desiredPos;
        if(player.transform.position.y < -1.5f || player.transform.position.y > 1.5f)
        {
            desiredPos = new Vector3(player.transform.position.x, -1.5f, player.transform.position.z) + offset;
        }
        else
        {
            desiredPos = player.transform.position + offset;
        }
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothedPosition;


    }
}
