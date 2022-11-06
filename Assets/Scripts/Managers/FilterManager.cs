using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FilterManager : MonoBehaviour
{
    public static FilterManager instance {get; private set;}
    void Awake() 
    {
        if (instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    [SerializeField] TMP_InputField parameterField;
    [SerializeField] TMP_Dropdown statementDropdown;
    public TextMeshProUGUI parameterText;
    public Transform filterCanvas;


    public void Filter()
    {
        if (MapManager.instance.currentMapType == MapManager.MapType.HeatMap)
        {
            switch (statementDropdown.value)
            {
                case 0:
                    CityManager.instance.DisableAllCities();
                    foreach (var city in MapManager.instance.cities)
                    {
                        if (city.GetComponent<City>().citySO.cityData.heatValue.ToString() == parameterField.text)
                        {
                            city.SetActive(true);
                        }
                    }
                    break;

                    case 1:
                    CityManager.instance.DisableAllCities();
                    foreach (var city in MapManager.instance.cities)
                    {
                        if (city.GetComponent<City>().citySO.cityData.heatValue < float.Parse(parameterField.text))
                        {
                            city.SetActive(true);
                        }
                    }
                    break;

                case 2:
                    CityManager.instance.DisableAllCities();
                    foreach (var city in MapManager.instance.cities)
                    {
                        if (city.GetComponent<City>().citySO.cityData.heatValue > float.Parse(parameterField.text))
                        {
                            city.SetActive(true);
                        }
                    }
                    break;
            }
        }
        else
        {
            switch (statementDropdown.value)
            {
                case 0:
                    CityManager.instance.DisableAllCities();
                    foreach (var city in MapManager.instance.cities)
                    {
                        if (city.GetComponent<City>().citySO.cityData.populationValue.ToString() == parameterField.text)
                        {
                            city.SetActive(true);
                        }
                    }
                    break;

                    case 1:
                    CityManager.instance.DisableAllCities();
                    foreach (var city in MapManager.instance.cities)
                    {
                        if (city.GetComponent<City>().citySO.cityData.populationValue < float.Parse(parameterField.text))
                        {
                            city.SetActive(true);
                        }
                    }
                    break;

                case 2:
                    CityManager.instance.DisableAllCities();
                    foreach (var city in MapManager.instance.cities)
                    {
                        if (city.GetComponent<City>().citySO.cityData.populationValue > float.Parse(parameterField.text))
                        {
                            city.SetActive(true);
                        }
                    }
                    break;
            }
        }
        
    }
}
