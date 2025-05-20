using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{

    public float maxStamina;
    public float stamina;
    public float staminaRegen;

    public float baseStaminaRegenCd = 2;
    public float staminaRegenCd;
    public float staminaRegenCdMax;
    public float lastFrameStamina = 100;
    // Start is called before the first frame update
    void Start()
    {
        staminaRegenCd = baseStaminaRegenCd;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        stamina += staminaRegenCd <= 0 ? staminaRegen / 50 : 0;

        if(stamina > maxStamina)
        {
            stamina = maxStamina;
        }
        
        if (stamina == lastFrameStamina)
        {
            staminaRegenCd -= staminaRegenCd <= 0 ? 0 : 0.02f;
        }
        else if(staminaRegenCd > 0)
        {
            staminaRegenCd = baseStaminaRegenCd;
        }

        lastFrameStamina = stamina;
        if (stamina == maxStamina)
        {
            staminaRegenCd = staminaRegenCdMax;
        }
    }
}
