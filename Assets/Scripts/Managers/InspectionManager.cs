using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InspectionManager : MonoBehaviour
{
    [SerializeField] Transform cityPrefabLocation;
    [SerializeField] Transform parentObject;
    [SerializeField] TextMeshProUGUI cityNameText;
    [SerializeField] TextMeshProUGUI cityPlateNumText;
    [SerializeField] TextMeshProUGUI cityHeatValueText;
    [SerializeField] TextMeshProUGUI cityPopValText;
    GameObject cityObject = null;
    CitySO selectedCity;

    void OnEnable()
    {
        cityObject = Instantiate<GameObject>(CityManager.instance.GetSelectedCity().gameObject,new Vector3(cityPrefabLocation.transform.position.x,cityPrefabLocation.transform.position.y+1f,cityPrefabLocation.transform.position.z),Quaternion.identity);
        cityObject.GetComponent<CityMouseController>().enabled = false; 
        cityObject.transform.rotation = Quaternion.AngleAxis(45, Vector3.right);
        selectedCity = cityObject.GetComponent<City>().citySO;
        cityNameText.text = "Şehir Adı: "+selectedCity.cityData.cityName;
        cityPlateNumText.text = "Plaka No: "+selectedCity.cityData.plateNo.ToString();
        cityHeatValueText.text = "Sıcaklık Değeri: "+selectedCity.cityData.heatValue.ToString();
        cityPopValText.text = "Nüfus: "+selectedCity.cityData.populationValue.ToString();

    }
    void OnDisable() 
    {
        Destroy(cityObject);
    }
    void Update() 
    {
        cityObject.transform.Rotate(new Vector3(0f, 90f, 0f)*Time.deltaTime, Space.World); 
        //cityPrefabLocation.transform.Rotate(new Vector3(0f, 0f, 90.0f)*Time.deltaTime, Space.Self);
        //cityObject.transform.Rotate(new Vector3(0f, 90f, 0f)*Time.deltaTime, Space.Self); 
    }
}
