using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotPunch : MonoBehaviour
{
    public Transform rightTarget;
    public Transform rightHint;

    public Transform leftTarget;
    public Transform leftHint;

    private float jabCooldown;
    private float baseJabCooldown = 2f;

    private Transform punchTarget;

    public Transform stomach;
    public Transform head;

    public PlayerBlocking playerBlocking;

    BotBlockDetection blocking;

    public bool attacking;

    public AnimationCurve punchCurve;

    public float punchDuration;

    bool hitBlock;
    bool midPunch;
    bool hitPlayer;

    public bool wantsToAttack;

    // Start is called before the first frame update
    void Start()
    {
        jabCooldown = baseJabCooldown;
        blocking = GetComponent<BotBlockDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        jabCooldown -= Time.deltaTime;
        if (jabCooldown <= 0)
        {
            wantsToAttack = true;
            jabCooldown = baseJabCooldown + Random.value * baseJabCooldown + punchDuration;
        }


            float distance = Vector3.Distance(transform.position, stomach.position);
        if (wantsToAttack && distance <= 1)
        {
            Attack(Random.value < 0.5f ? rightTarget : leftTarget, "jab");
        }
    }

    void Attack(Transform hand, string type)
    {
        wantsToAttack = false;
        attacking = true;
        punchTarget = playerBlocking.blocking ? stomach : head;


        StartCoroutine(Punch(hand.position, punchTarget.position, punchDuration, hand));
    }

    IEnumerator Punch(Vector3 from, Vector3 to, float duration, Transform hand)
    {
        Debug.Log("balls");
        hitBlock = false;
        midPunch = true;
        hitPlayer = false;

        float elapsed = 0f;
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            float eased = punchCurve.Evaluate(t);
            hand.position = Vector3.Lerp(from, to, eased);
            elapsed += Time.deltaTime;
            yield return null;
        }
        midPunch = false;
        hand.position = to;

        if (hitPlayer)
        {
            //Indicate hit
        }
        attacking = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (midPunch)
        {
            if (collision.collider.CompareTag("block"))
            {
                hitBlock = true;
            }
            if (collision.collider.CompareTag("hurtbox") && !hitBlock)
            {
                hitPlayer = true;
            }
        }
    }
}
