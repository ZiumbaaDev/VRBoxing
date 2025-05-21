using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBlockDetection : MonoBehaviour
{
    public bool Blocking;

    public BotPunch botPunch;
    public bool wants;
    public bool attacks;
    public float timer = 0;

    private void FixedUpdate()
    {
        timer += 0.02f;
        wants = botPunch.wantsToAttack && GetComponent<Stamina>().stamina > 20;
        attacks = botPunch.attacking;
        Blocking = !wants && !attacks;
           
        GetComponent<Stamina>().stamina -= Blocking ? (7.5f / 50) : 0;
               
    }
}
