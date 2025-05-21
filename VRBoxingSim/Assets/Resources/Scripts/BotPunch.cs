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
            Attack(Random.value < 0.5f ? "right" : "left", "jab");
        }
    }

    void Attack(string hand, string type)
    {
        wantsToAttack = false;
        attacking = true;


        StartCoroutine(Punch(punchDuration, hand));
    }

    IEnumerator Punch(float duration, string hand)
    {
        transform.localScale = new Vector3(hand == "left" ? -transform.localScale.x : transform.localScale.x, 0.01f, 0.01f);

        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }


        if (Vector3.Distance(transform.position, playerBlocking.transform.position) <= 2 && !playerBlocking.blocking)
        {
            if(playerBlocking.stamina.stamina <= 0)
            {
                //You Lose
            }
            playerBlocking.stamina.stamina -= 30;
        }
        attacking = false;
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        GetComponent<Stamina>().stamina -= 10;
    }
}
