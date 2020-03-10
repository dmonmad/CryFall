using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenaryMovementScript : MonoBehaviour
{

    public float prefabSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * prefabSpeed;
    }
}
