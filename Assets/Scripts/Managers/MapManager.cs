using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public enum MapType
    {
        HeatMap,
        PopulationMap
    }
    public static MapManager instance {get;private set;}
    CityTypeListSO cityTypeList;
    //float popDifference = 15757255f;
    float maxPopLog = Mathf.Log(15840900)/Mathf.Log(8);
    float minPopLog = Mathf.Log(83645)/Mathf.Log(8);
    
    public float maxHeatVal = 4526.4f;
    public float minHeatVal = 3571.2f;
    public int maxPopValue = 15840900;
    public int minPopValue = 83645;

    public List<GameObject> cities;
    public MapType currentMapType = MapType.HeatMap;
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
            cityObject.GetComponent<City>().citySO = city;
            cityObject.transform.parent = gameObject.transform;
            StartCoroutine(DatabaseManager.instance.Download(city.cityData.cityName, result => {
                city.cityData.heatValue = result.heatValue;
                city.cityData.populationValue = result.populationValue;
                city.cityData.plateNo = result.plateNo;
            }));
            cities.Add(cityObject);
            ColorizeMap(currentMapType,cityObject);
            //float colorChanger = Random.Range(0,1f);
            //cityObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }

    public void ColorizeMap(MapType mapType, GameObject city)
    {
        switch (mapType)
        {
            case MapType.HeatMap:
                float deltaHeat = (city.GetComponent<City>().citySO.cityData.heatValue-minHeatVal)/(maxHeatVal - minHeatVal);
                city.GetComponent<MeshRenderer>().material.color= new Color(2.0f * deltaHeat, 2.0f * (1 - deltaHeat), 0);
            break;

            case MapType.PopulationMap:
                float deltaPop= ((float)((Mathf.Log(city.GetComponent<City>().citySO.cityData.populationValue)/Mathf.Log(8))-minPopLog)/(maxPopLog - minPopLog));
                city.GetComponent<MeshRenderer>().material.color= new Color(1.0f, 1f * (1f - deltaPop), 1f * (1.0f - deltaPop));
            break;
        }
    }
}
