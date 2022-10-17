using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    // Start is called before the first frame update
    CityTypeListSO cityTypeList;
    void Start() 
    {
        cityTypeList = Resources.Load<CityTypeListSO>(typeof(CityTypeListSO).Name);
        foreach (var city in cityTypeList.cityList)
        {
            GameObject cityObject = Instantiate<GameObject>(city.cityPrefab.transform.gameObject);
            cityObject.transform.parent = gameObject.transform;
            float colorChanger = Random.Range(0,1f);
            //cityObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            cityObject.GetComponent<MeshRenderer>().material.color= new Color(2.0f * colorChanger, 2.0f * (1 - colorChanger), 0);
        }
    }
}
