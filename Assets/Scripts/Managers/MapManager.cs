using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance {get;private set;}
    CityTypeListSO cityTypeList;

    void Awake()
    {
        if (instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    void Start() 
    {
        cityTypeList = Resources.Load<CityTypeListSO>(typeof(CityTypeListSO).Name);
        foreach (var city in cityTypeList.cityList)
        {
            GameObject cityObject = Instantiate<GameObject>(city.cityPrefab.transform.gameObject);
            StartCoroutine(DatabaseManager.instance.Download(city.cityData.cityName, result => {
                Debug.Log(result);
                city.cityData.heatValue = result.heatValue;
                city.cityData.populationValue = result.populationValue;
                city.cityData.plateNo = result.plateNo;
            }));
            cityObject.transform.parent = gameObject.transform;
            cityObject.GetComponent<City>().citySO = city;
            float colorChanger = Random.Range(0,1f);
            //cityObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            cityObject.GetComponent<MeshRenderer>().material.color= new Color(2.0f * colorChanger, 2.0f * (1 - colorChanger), 0);
            //cityObject.GetComponent<MeshRenderer>().material.color= new Color(1, 2.0f * (1 - colorChanger), 2.0f * (1 - colorChanger));
        }
    }
}
