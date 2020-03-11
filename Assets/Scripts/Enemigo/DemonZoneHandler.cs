using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonZoneHandler : MonoBehaviour
{

    public DemonBossAI dai;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dai.IntoZone();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dai.ExitZone();
        }
    }
}
