using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovement : MonoBehaviour
{
    public Animator animator;
    public Transform fleeFromTarget;
    public float speed = 5f;
    public bool shouldFlee = false;

    public BotBlockDetection botBlock;
    public BotPunch punch;

    void Update()
    {
        shouldFlee = botBlock.Blocking;
        if(fleeFromTarget != null)
        {
            animator.SetBool("IsIdle", punch.wantsToAttack);
            animator.SetBool("IsBlocking", botBlock);
            Vector3 directionAway = (transform.position - fleeFromTarget.position).normalized;
            transform.position += (shouldFlee ? 0.4f : (punch.attacking ? 0 : -1)) * speed * Time.deltaTime * directionAway;
        }
    }
}
