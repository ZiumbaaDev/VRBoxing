using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotPunch : MonoBehaviour
{
    public Transform rightTarget;
    public Transform rightHint;

    public Transform leftTarget;
    public Transform leftHint;

    private float swingCooldown;
    private float baseSwingCooldown = 4;
    private float jabCooldown;
    private float baseJabCooldown = 0.75f;

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

    // Start is called before the first frame update
    void Start()
    {
        swingCooldown = baseSwingCooldown;
        jabCooldown = baseJabCooldown;
        blocking = GetComponent<BotBlockDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        swingCooldown -= Time.deltaTime;
        jabCooldown -= Time.deltaTime;

        if (!blocking.blocking && swingCooldown <= 0)
        {
            Attack(Random.value < 0.5f ? rightTarget : leftTarget, "swing");
        }
        else if (!blocking.blocking && jabCooldown <= 0)
        {
            Attack(Random.value < 0.5f ? rightTarget : leftTarget, "jab");
        }
    }

    void Attack(Transform hand, string type)
    {
        attacking = true;
        punchTarget = playerBlocking.blocking == "head" ? stomach : head;


        StartCoroutine(Punch(hand.position, punchTarget.position, punchDuration));


        if (type == "jab")
        {
            jabCooldown = baseJabCooldown / 2 + Random.value * baseJabCooldown;
        } 
        else
        {
            swingCooldown = baseSwingCooldown / 2 + Random.value * baseSwingCooldown;
        }
        attacking = false;
    }

    IEnumerator Punch(Vector3 from, Vector3 to, float duration)
    {
        hitBlock = false;
        midPunch = true;
        hitPlayer = false;

        float elapsed = 0f;
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            float eased = punchCurve.Evaluate(t);
            transform.position = Vector3.Lerp(from, to, eased);
            elapsed += Time.deltaTime;
            yield return null;
        }
        midPunch = false;
        transform.position = to;

        if (hitPlayer)
        {
            //decrease player hp
        }
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
