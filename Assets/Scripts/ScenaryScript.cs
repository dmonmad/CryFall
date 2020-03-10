using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenaryScript : MonoBehaviour
{

    public Transform target;
    public Renderer bgRend;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bgRend.material.mainTextureOffset = new Vector2(target.position.x,0);
    }

}
