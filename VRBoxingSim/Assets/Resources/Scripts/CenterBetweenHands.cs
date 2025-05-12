using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterBetweenHands : MonoBehaviour
{
    public Transform LeftHand;
    public Transform RightHand;
    public BoxCollider boxCollider;
    public PlayerBlocking playerBlocking;

    void Update()
    {
        if (LeftHand != null && RightHand != null)
        {
            Vector3 midpoint = (LeftHand.position + RightHand.position) / 2;
            transform.position = midpoint;
        }

        boxCollider.enabled = playerBlocking.blocking;
    }
}
