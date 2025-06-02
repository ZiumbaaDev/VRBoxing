using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Hitboxes : MonoBehaviour
{
    SphereCollider hitbox;
    float timer = 0;

    public bool isEnabled = true;

    public float cooldown;

    public AudioSource sound;

    public Material flashMaterial;

    public TMP_Text text;
    public GameObject staminaText;
    public GameObject hurtIndication;
    public GameObject blockIndication;
    public GameObject blur;

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
        if (collider.CompareTag("Enemy"))
        {
            collider.transform.root.GetComponent<BotHit>().OnHit();
            sound.Play();
            isEnabled = false;
            timer = 0;
            if(collider.transform.root.GetComponent<Stamina>().stamina <= 0)
            {
                staminaText.SetActive(false);
                hurtIndication.SetActive(false);
                blockIndication.SetActive(false);
                text.text = "You Win!";

                collider.gameObject.SetActive(false);
            }
            collider.transform.root.GetComponent<Stamina>().stamina -= 30;
            transform.root.GetComponent<Stamina>().stamina -= 10;
            Debug.Log("Enemy hit");
        }
    }
}
