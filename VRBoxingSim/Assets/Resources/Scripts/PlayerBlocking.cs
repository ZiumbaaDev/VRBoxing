using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlocking : MonoBehaviour
{
    public bool blocking = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            blocking = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            blocking = false;
        }
    }
}
