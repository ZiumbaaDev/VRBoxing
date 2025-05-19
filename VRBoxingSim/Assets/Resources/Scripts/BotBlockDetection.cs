using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBlockDetection : MonoBehaviour
{
    public bool Blocking;

    public BotPunch botPunch;

    private void Update()
    {
        Debug.Log(botPunch.wantsToAttack);
        Debug.Log(botPunch.attacking);
        Blocking = !botPunch.wantsToAttack && !botPunch.attacking;
    }
}
