using System.Collections;
using UnityEngine;

public class BotPunch : MonoBehaviour
{
    public PlayerBlocking playerBlocking;
    public bool attacking;
    public bool wantsToAttack;
    public float punchDuration;
    private float jabCooldown;
    private float baseJabCooldown = 2f;
    public float staggerCd = 1;

    public bool staggered;

    void Start()
    {
        jabCooldown = baseJabCooldown;
    }
    void Update()
    {
        staggerCd -= Time.deltaTime;
        jabCooldown -= Time.deltaTime;
        if (jabCooldown <= 0)
        {
            wantsToAttack = true;
            jabCooldown = baseJabCooldown + Random.value * baseJabCooldown + punchDuration;
        }

        float distance = Vector3.Distance(transform.position, playerBlocking.transform.position);
        
        if (wantsToAttack && distance <= 2)
        {
            Attack(Random.value < 0.5f ? "right" : "left", "jab");
        }

        staggered = staggerCd > 0;
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
        staggerCd = 1;
    }
}