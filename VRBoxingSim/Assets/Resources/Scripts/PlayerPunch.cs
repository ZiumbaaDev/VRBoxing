using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    private Vector3 leftLastLocation;
    private Vector3 rightLastLocation;

    public Transform leftHand;
    public Transform rightHand;

    public SphereCollider leftCollider;
    public SphereCollider rightCollider;

    public bool rightAttacking;
    public float rightSpeed;
    public bool leftAttacking;
    public float leftSpeed;

    public float minimumSpeed = 1f;

    public float leftAttackingTime = 0;
    public float rightAttackingTime = 0;

    private Queue<float> distancesA = new Queue<float>();
    private Queue<float> distancesB = new Queue<float>();
    public int maxFrames = 10;


    private void Update()
    {
        leftCollider.enabled = leftAttacking && leftCollider.GetComponent<Hitboxes>().isEnabled;
        rightCollider.enabled = rightAttacking && rightCollider.GetComponent<Hitboxes>().isEnabled;
    }

    void FixedUpdate()
    {
        UpdateDistances(leftLastLocation, leftHand.position, rightLastLocation, rightHand.position);

        leftSpeed = GetAverageDistanceA() / 0.02f;
        rightSpeed = GetAverageDistanceB() / 0.02f;

        leftAttacking = leftSpeed >= minimumSpeed;
        rightAttacking = rightSpeed >= minimumSpeed;

        if (leftAttacking) 
        {
            leftAttackingTime += 0.02f;
        }
        else
        {
            leftAttackingTime = 0;
        }

        if (rightAttacking)
        {
            rightAttackingTime += 0.02f;
        }
        else
        {
            rightAttackingTime = 0;
        }


        leftLastLocation = leftHand.position;
        rightLastLocation = rightHand.position;
    }
    public void UpdateDistances(Vector3 a1, Vector3 a2, Vector3 b1, Vector3 b2)
    {
        float distanceA = Vector3.Distance(a1, a2);
        float distanceB = Vector3.Distance(b1, b2);

        distancesA.Enqueue(distanceA);
        distancesB.Enqueue(distanceB);

        if (distancesA.Count > maxFrames)
            distancesA.Dequeue();

        if (distancesB.Count > maxFrames)
            distancesB.Dequeue();
    }

    public float GetAverageDistanceA()
    {
        return GetAverage(distancesA);
    }

    public float GetAverageDistanceB()
    {
        return GetAverage(distancesB);
    }

    private float GetAverage(Queue<float> queue)
    {
        if (queue.Count == 0)
            return 0f;

        float sum = 0f;
        foreach (float d in queue)
        {
            sum += d;
        }
        return sum / queue.Count;
    }
}
