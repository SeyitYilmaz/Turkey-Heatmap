using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityManager : MonoBehaviour
{
    public static CityManager instance {get; private set;}
    Transform selectedCity;
    Transform currentCity;
    public LayerMask cityLayerMask;

    void Awake() 
    {
        if(instance !=null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void SetSelectedCity(Transform selectedCity)
    {
        this.selectedCity = selectedCity;
    }

    public Transform GetSelectedCity()
    {
        if(this.selectedCity!=null)
        {
            return this.selectedCity;
        }
        return null;
        
    }

    public void SetCurrentOnEnter(Transform current)
    {
        currentCity = current;
    }

    public Transform GetCurrentCity()
    {
        if(this.currentCity != null)
        {
            return this.currentCity;
        }
        return null;
    }

    public void LiftUpCity(Transform city)
    {
        city.localPosition = new Vector3(city.position.x,city.position.y+0.2f,city.position.z-0.05f);
    }

    public void LowerCity(Transform city)
    {
        city.localPosition = new Vector3(city.position.x,city.position.y-0.2f,city.position.z+0.05f);
    }
    
}
