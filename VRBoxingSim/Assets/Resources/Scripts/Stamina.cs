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

    public RectTransform rectTransform;
    void Start()
    {
        staminaRegenCd = baseStaminaRegenCd;
    }

    private void FixedUpdate()
    {
        stamina += staminaRegenCd <= 0 ? staminaRegen / 50 : 0;
        rectTransform.localScale = new Vector3(stamina / 137.5f, 1, 0);

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