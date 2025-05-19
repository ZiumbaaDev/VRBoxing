using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovement : MonoBehaviour
{
    public Transform fleeFromTarget;
    public float speed = 5f;
    public bool shouldFlee = false;

    public BotBlockDetection botBlock;

    void Start()
    {
        
    }

    void Update()
    {
        shouldFlee = botBlock.Blocking;
        if(fleeFromTarget != null)
        {
            Vector3 directionAway = (transform.position - fleeFromTarget.position).normalized;
            transform.position += (shouldFlee ? 1 : -1) * speed * Time.deltaTime * directionAway;
        }
        
    }
}
