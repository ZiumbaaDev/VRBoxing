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
    public Volume globalVolume;
    private DepthOfField dof;
    public BotPunch botPunch;

    void Start()
    {
        staminaRegenCd = baseStaminaRegenCd;
        
    }

    private void FixedUpdate()
    {
        stamina += staminaRegenCd <= 0 ? staminaRegen / 50 : 0;
        
        if(globalVolume.profile.TryGet(out dof))
        {
            dof.focalLength.value = 250 - stamina;
        }
        if (botPunch.hurtBorder.enabled && dof.focalLength.value >= 50)
        {
            dof.aperture.value = 1;          
        }
        else if(botPunch.hurtBorder.enabled && dof.focalLength.value <= 50)
        {
            dof.focalLength.value = 50;
            dof.aperture.value = 1;
        }
        else if (!botPunch.hurtBorder.enabled)
        {
            dof.aperture.value = 15;
            dof.focalLength.value = 250 - stamina;
        }

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