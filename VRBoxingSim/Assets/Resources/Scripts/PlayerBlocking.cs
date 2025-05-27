using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Comfort;
using UnityEngine.XR.Interaction.Toolkit;


public class PlayerBlocking : MonoBehaviour
{
    public bool blocking = false;

    public float maxHeadDistance = 0.3f;
    public float maxHandDistance = 0.3f;

    public Transform headTransform;
    public Transform leftHandTransform;
    public Transform rightHandTransform;

    public Stamina stamina;
    public Canvas blockBorder;

    private void FixedUpdate()
    {
        bool leftHandClose = Vector3.Distance(headTransform.position, leftHandTransform.position) < maxHeadDistance;
        bool rightHandClose = Vector3.Distance(headTransform.position, rightHandTransform.position) < maxHeadDistance;

        blocking = leftHandClose && rightHandClose && Vector3.Distance(leftHandTransform.position, rightHandTransform.position) < maxHandDistance;

        stamina.stamina -= blocking ? (7.5f / 50) : 0;
        
        blockBorder.enabled = blocking;
    }
}
