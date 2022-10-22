using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CityMouseController : MonoBehaviour
{
    void OnMouseEnter()
    {
        transform.localPosition = new Vector3(transform.position.x,transform.position.y+0.2f,transform.position.z-0.05f);
        
    }
    private void OnMouseExit()
    {
       transform.localPosition = new Vector3(transform.position.x,transform.position.y-0.2f,transform.position.z+0.05f); 
    }

    private void OnMouseDown()
    {
        CityManager.instance.SetSelectedCity(transform);
        CameraManager.instance.SelectCamera(1);
    }

}