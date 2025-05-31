using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class Blur : MonoBehaviour
{
    public Volume globalVolume;
    private DepthOfField dof;
    public BotPunch botPunch;
    public Stamina playerStamina;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (globalVolume.profile.TryGet(out dof))
        {
            dof.focalLength.value = 250 - playerStamina.stamina;
        }
        if (botPunch.hurtBorder.enabled && dof.focalLength.value >= 50)
        {
            dof.aperture.value = 1;
        }
        else if (botPunch.hurtBorder.enabled && dof.focalLength.value <= 50)
        {
            dof.focalLength.value = 50;
            dof.aperture.value = 1;
        }
        else if (!botPunch.hurtBorder.enabled)
        {
            dof.aperture.value = 15;
            dof.focalLength.value = 250 - playerStamina.stamina;
        }
    }
}
