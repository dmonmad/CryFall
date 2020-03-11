using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenaryMovementScript : MonoBehaviour
{

    PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(pm.transform.position.x, transform.position.y, transform.position.z);
    }
}
