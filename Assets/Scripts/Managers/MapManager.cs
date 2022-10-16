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
            cityObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }

    void Update() 
    {
        /*Transform selectedCity = CityManager.instance.GetSelectedCity();
        Debug.Log(selectedCity.name);

        if(selectedCity !=null)
        {
            //selectedCity.localScale = Vector3.Lerp(selectedCity.localScale,new Vector3(1.1f,0,1.1f),10f*Time.deltaTime);
            selectedCity.position.y = selectedCity.position.;
        }

        //Debug.Log(GetMouseHitTransform(cityLayerMask));*/
    }
    
}
