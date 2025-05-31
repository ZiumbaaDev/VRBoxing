using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Stamina : MonoBehaviour
{
    public float maxStamina;
    public float stamina;
    public float staminaRegen;

    public float baseStaminaRegenCd = 2;
    public float staminaRegenCd;
    public float staminaRegenCdMax;
    public float lastFrameStamina = 100;
    

    void Start()
    {
        staminaRegenCd = baseStaminaRegenCd;
        
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
        if (stamina == maxStamina)
        {
            staminaRegenCd = staminaRegenCdMax;
        }
        lastFrameStamina = stamina;
        
    }
}