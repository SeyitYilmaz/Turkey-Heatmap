using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CityMouseController : MonoBehaviour
{
    City city;
    void Start() 
    {
        city = transform.GetComponent<City>();    
    }
    void OnMouseEnter()
    {
        transform.localPosition = new Vector3(transform.position.x,transform.position.y+0.2f,transform.position.z-0.05f);
        CityManager.instance.SetCurrentOnEnter(transform);
        TooltipManager.instance.ShowTooltip(city.cityName);
    }
    private void OnMouseExit()
    {
        if(CityManager.instance.GetCurrentCity()!=transform && CityManager.instance.GetCurrentCity()!=null)
        {
            transform.localPosition = new Vector3(transform.position.x,transform.position.y-0.2f,transform.position.z+0.05f);
        }
        transform.localPosition = new Vector3(transform.position.x,transform.position.y-0.2f,transform.position.z+0.05f); 
        TooltipManager.instance.HideTooltip();
    }

    private void OnMouseDown()
    {
        CityManager.instance.SetSelectedCity(transform);
        CameraManager.instance.SelectCamera(1);
        UIManager.instance.SelectCanvas(1);
    }

}