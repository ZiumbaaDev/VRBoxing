using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hitboxes : MonoBehaviour
{
    SphereCollider hitbox;
    float timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        hitbox = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hitbox.enabled)
        {
            timer += Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            hitbox.enabled = false;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            if (timer >= 1)
            {
                hitbox.enabled = true;
            }
        }   
    }
}
