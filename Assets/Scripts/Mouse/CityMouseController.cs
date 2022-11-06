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
        if (!FilterManager.instance.filterCanvas.gameObject.activeSelf)
        {
            if (CityManager.instance.GetCurrentCity()!=null)
            {
                CityManager.instance.LowerCity(CityManager.instance.GetCurrentCity());
            }
            CityManager.instance.LiftUpCity(transform);
            CityManager.instance.SetCurrentOnEnter(transform);
            TooltipManager.instance.ShowTooltip(city.cityName);

        }

    }
    private void OnMouseExit()
    {
        if (!FilterManager.instance.filterCanvas.gameObject.activeSelf)
        {
            if(CityManager.instance.GetCurrentCity()!=transform && CityManager.instance.GetCurrentCity()!=null)
            {
                CityManager.instance.LowerCity(transform);     
            }
            TooltipManager.instance.HideTooltip();
        }

    }

    private void OnMouseDown()
    {
        if (!FilterManager.instance.filterCanvas.gameObject.activeSelf)
        {
            CityManager.instance.SetSelectedCity(transform);
            CameraManager.instance.SelectCamera(1);
            UIManager.instance.SelectCanvas(1);
        }
        
    }

}