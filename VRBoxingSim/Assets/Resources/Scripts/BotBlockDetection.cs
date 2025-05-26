using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBlockDetection : MonoBehaviour
{
    public bool Blocking;

    public BotPunch botPunch;
    public bool wants;
    public bool attacks;

    private void FixedUpdate()
    {
        wants = botPunch.wantsToAttack && GetComponent<Stamina>().stamina > 50;
        attacks = botPunch.attacking;
        Blocking = !wants && !attacks && !botPunch.staggered;
        
        GetComponent<Stamina>().stamina -= Blocking && GetComponent<Stamina>().stamina > 125f ? (7.5f / 50) : 0;
               
    }
}