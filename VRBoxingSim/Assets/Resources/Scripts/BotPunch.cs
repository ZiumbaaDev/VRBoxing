using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class BotPunch : MonoBehaviour
{
    public PlayerBlocking playerBlocking;
    public ScreenShake screenShake;
    public bool attackingJab;
    public bool attackingUppercut;
    public bool attackingHook;
    public bool wantsToAttack;
    public float punchDuration;
    private float jabCooldown;
    private float baseJabCooldown = 2f;
    public float staggerCd = 1;
    public float hurtBorderDuration;

    public bool staggered;

    public Canvas hurtBorder;

    void Start()
    {
        jabCooldown = baseJabCooldown;
        hurtBorder.enabled = false;
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
        if(hurtBorder.enabled)
        {
            hurtBorderDuration += Time.deltaTime;
            if(hurtBorderDuration >= 0.5f)
            {
                hurtBorder.enabled = false;
                hurtBorderDuration = 0;
            }
        }
        

        float distance = Vector3.Distance(transform.position, playerBlocking.transform.position);
        
        if (wantsToAttack && distance <= 2)
        {
            float randomAtk = Random.value;
            Attack(Random.value < 0.5f ? "right" : "left", randomAtk < 0.33f ? "jab" : (randomAtk < 0.66f ? "uppercut" : "hook"));
        }

        staggered = staggerCd > 0;
    }

    void Attack(string hand, string type)
    {
        wantsToAttack = false;
        if (type == "jab")
        {
            attackingJab = true;
        }
        else if (type == "uppercut")
        {
            attackingUppercut = true;
        }
        else if (type == "hook")
        {
            attackingHook = true;
        }

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
                gameObject.SetActive(false);
            }
            playerBlocking.stamina.stamina -= 30;
            hurtBorder.enabled = true;
            screenShake.start = true;
        }
        attackingJab = false;
        attackingUppercut = false;
        attackingHook = false;
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        GetComponent<Stamina>().stamina -= 10;
        staggerCd = 1;
    }
}