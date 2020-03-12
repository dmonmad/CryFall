using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon_Walk : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 0.7f;
    Transform player;
    Rigidbody2D rb;
    public DemonBossAI dai;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.GetComponentInParent<DemonBossAI>().player.transform;
        rb = animator.GetComponentInParent<Rigidbody2D>();
        dai = animator.GetComponentInParent<DemonBossAI>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (dai.GetChase())
        {
            dai.LookAtPlayer();
            if (Vector2.Distance(player.transform.position, rb.position) <= attackRange)
            {
                animator.SetTrigger("Attack");
            }
            else
            {
                Vector2 target = new Vector2(player.transform.position.x, rb.position.y);
                Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
                rb.MovePosition(newPos);
            }

        }
        else
        {
            if (Vector2.Distance(new Vector2(dai.demonSpawn.transform.position.x, dai.demonSpawn.transform.position.y), rb.position) > 0.5f)
            {
                Vector2 target = new Vector2(dai.demonSpawn.transform.position.x, rb.position.y);
                Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
                rb.MovePosition(newPos);
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
