using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{   public CitySO citySO;
    public int plateNo;
    public string cityName;
    public int heatValue;
    public int populationValue;

    void Start()
    {
        plateNo = citySO.cityData.plateNo;
        cityName = citySO.cityData.cityName;
        heatValue = citySO.cityData.heatValue;
        populationValue = citySO.cityData.populationValue;
    }
}
