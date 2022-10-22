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
        plateNo = citySO.plateNo;
        cityName = citySO.cityName;
        heatValue = citySO.heatValue;
        populationValue = citySO.populationValue;
    }
}
