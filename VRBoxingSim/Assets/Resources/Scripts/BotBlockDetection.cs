using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBlockDetection : MonoBehaviour
{
    int hands = 0;

    public bool blocking = false;

    void Update()
    {
        blocking = hands > 0 && !GetComponent<BotPunch>().attacking;

    }

    private void OnCollisionEnter(Collision collision)
    {
        hands++;
    }

    private void OnCollisionExit(Collision collision)
    {
        hands--;
    }
}
