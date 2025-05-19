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

    void FixedUpdate()
    {
        if (leftLastLocation == null && rightLastLocation == null)
        {
            leftHand.position = leftLastLocation;
            rightHand.position = rightLastLocation;
        }
        else
        {
            float leftDistance = Vector3.Distance(leftLastLocation, leftHand.position);
            float rightDistance = Vector3.Distance(rightLastLocation, rightHand.position);

            leftSpeed = leftDistance / 0.02f;
            rightSpeed = rightDistance / 0.02f;

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

            leftCollider.enabled = leftAttacking;
            rightCollider.enabled = rightAttacking;
        }
    }
}
