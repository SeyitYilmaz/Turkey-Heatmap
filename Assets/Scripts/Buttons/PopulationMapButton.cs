using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationMapButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetComponent<Button>().onClick.AddListener(()=>{
            MapManager.instance.currentMapType = MapManager.MapType.PopulationMap;
            FilterManager.instance.parameterText.SetText("Nüfus : ");
            MapTypeButtonManager.instance.SelectButton(1);
            foreach (var city in MapManager.instance.cities)
            {
                MapManager.instance.ColorizeMap(MapManager.MapType.PopulationMap,city);
            }
            CityManager.instance.EnableAllCities();
        });
    }

}
