using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBlockDetection : MonoBehaviour
{
    public GameObject objectA;
    public GameObject objectB;

    private bool isAInside = false;
    private bool isBInside = false;

    public bool Blocking;

    public BotPunch botPunch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == objectA)
            isAInside = true;
        else if (other.gameObject == objectB)
            isBInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == objectA)
            isAInside = false;
        else if (other.gameObject == objectB)
            isBInside = false;
    }

    private void Update()
    {
        Blocking = (isAInside || isBInside) && !botPunch.attacking;
    }
}
