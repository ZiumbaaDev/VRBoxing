using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hitboxes : MonoBehaviour
{
    SphereCollider hitbox;
    float timer = 0;

    bool readyToEnable = false;
    
    // Start is called before the first frame update
    void Start()
    {
        hitbox = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hitbox.enabled)
        {
            timer += Time.deltaTime;
        }

        if (timer >= 1 && readyToEnable)
        {
            hitbox.enabled = true;
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            hitbox.enabled = false;
            readyToEnable = false;
            Debug.Log("Enemy hit");
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            readyToEnable = true;
        }
    }
}
