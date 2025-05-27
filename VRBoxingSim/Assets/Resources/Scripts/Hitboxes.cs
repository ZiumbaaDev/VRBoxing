using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hitboxes : MonoBehaviour
{
    SphereCollider hitbox;
    float timer = 0;

    public bool isEnabled = true;

    public float cooldown;

    public AudioSource sound;
    
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

        if (timer >= cooldown)
        {
            isEnabled = true;
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider);
        if (collider.CompareTag("Enemy"))
        {
            sound.Play();
            isEnabled = false;
            timer = 0;
            if(collider.transform.root.GetComponent<Stamina>().stamina <= 0)
            {
                //You win
                collider.gameObject.SetActive(false);
            }
            collider.transform.root.GetComponent<Stamina>().stamina -= 30;
            transform.root.GetComponent<Stamina>().stamina -= 10;
            Debug.Log("Enemy hit");
        }
    }
}
