using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotHit : MonoBehaviour
{
    public Material flashMaterial;
    private Material originalMaterial;
    private Renderer rend;

    void Start()
    {
        rend = transform.Find("Boxer").GetComponent<Renderer>();
        originalMaterial = rend.material;
    }

    public void OnHit()
    {
        StartCoroutine(Flash());
    }

    private IEnumerator Flash()
    {
        rend.material = flashMaterial;
        yield return new WaitForSeconds(0.1f);
        rend.material = originalMaterial;
    }
}
