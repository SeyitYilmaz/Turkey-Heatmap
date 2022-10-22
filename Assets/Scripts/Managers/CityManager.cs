using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityManager : MonoBehaviour
{
    public static CityManager instance {get; private set;}
    Transform selectedCity;
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
        Debug.Log(selectedCity);
    }

    public Transform GetSelectedCity()
    {
        if(this.selectedCity!=null)
        {
            return this.selectedCity;
        }
        return null;
        
    }
    
}
