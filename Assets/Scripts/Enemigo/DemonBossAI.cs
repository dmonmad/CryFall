using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DemonBossAI : MonoBehaviour
{

    Animator anim;
    Rigidbody2D rb;
    public GameObject player;
    public bool chasePlayer;
    public bool isFlipped = false;
    public Vector3 attackOffset;
    public float attackRange = 0.2f;
    public float speed = 0.3f;
    public float AttackDamage = 50f;
    public GameObject demonSpawn;
    public LayerMask layerMask;

    public void Awake()
    {
        FindObjectOfType<DemonZoneHandler>().dai = this;
        rb = GetComponent<Rigidbody2D>();
    }


    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    private void Update()
    {
        
    }

    public bool GetChase()
    {
        return chasePlayer;
    }

    public void Die()
    {
        this.gameObject.SetActive(false);
    }

    public void IntoZone()
    {
        chasePlayer = true;
    }

    public void ExitZone()
    {
        chasePlayer = false;
    }

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, layerMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().TakeDamage(AttackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }



    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.transform.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.transform.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void Restart()
    {
        GetComponent<DemonBossHealth>().Restart();
        this.transform.position = demonSpawn.transform.position;
        anim.Rebind();
    }

}
