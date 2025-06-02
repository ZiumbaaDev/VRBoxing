using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFov : MonoBehaviour
{
    public Camera camera;
    public Stamina stamina;

    public RectTransform blockBorder;
    public RectTransform hurtBorder;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        //if (stamina.stamina <= 125)
        //{
        //    camera.fieldOfView -= 2 * Time.deltaTime;
        //    if (camera.fieldOfView <= 35)
        //    {
        //        camera.fieldOfView = 35;
        //    }
        //}
        //else
        //{
        //    camera.fieldOfView = 60;
        //    blockBorder.localScale = new Vector3(60 / 35, 60 / 35, 60 / 35);
        //    hurtBorder.localScale = new Vector3(60 / 35, 60 / 35, 60 / 35);
        //}
    }
}
