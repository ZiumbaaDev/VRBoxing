using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBlockDetection : MonoBehaviour
{
    public bool Blocking;

    public BotPunch botPunch;
    public bool wants;
    public bool attacks;
    public bool regening;

    private void FixedUpdate()
    {
        wants = botPunch.wantsToAttack && GetComponent<Stamina>().stamina > 20;
        attacks = botPunch.attacking;
        regening = !wants && !attacks && GetComponent<Stamina>().stamina < 50;
        Blocking = !wants && !attacks && !regening;

        GetComponent<Stamina>().stamina -= Blocking ? (7.5f / 50) : 0;
    }
}
