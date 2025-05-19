using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBlockDetection : MonoBehaviour
{
    public bool Blocking;

    public BotPunch botPunch;
    public bool wants;
    public bool attacks;

    private void Update()
    {
        wants = botPunch.wantsToAttack;
        attacks = botPunch.attacking;
        Blocking = !botPunch.wantsToAttack && !botPunch.attacking;
    }
}
