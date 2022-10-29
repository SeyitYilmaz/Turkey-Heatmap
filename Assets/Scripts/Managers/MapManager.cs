using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance {get;private set;}
    CityTypeListSO cityTypeList;
    //float popDifference = 15757255f;
    float maxPopLog = Mathf.Log(15840900)/Mathf.Log(8);
    float minPopLog = Mathf.Log(83645)/Mathf.Log(8);
    
    //float popDifference = 3500000f;
    //float minPopVal = 83645f;
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
        float deltaPopLog = maxPopLog - minPopLog;
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
            float deltaPop= ((float)((Mathf.Log(city.cityData.populationValue)/Mathf.Log(8))-minPopLog)/deltaPopLog);
            
            float colorChanger = Random.Range(0,1f);
            //cityObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            //cityObject.GetComponent<MeshRenderer>().material.color= new Color(2.0f * colorChanger, 2.0f * (1 - colorChanger), 0);
            cityObject.GetComponent<MeshRenderer>().material.color= new Color(1.0f, 1f * (1f - deltaPop), 1f * (1.0f - deltaPop));
            //cityObject.GetComponent<MeshRenderer>().material.color= new Color(1f * deltaPop, 1f * (1 - deltaPop), 0);
        }
    }
}
