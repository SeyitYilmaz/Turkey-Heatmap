using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatmapButton : MonoBehaviour
{
    void Start() 
    {
        gameObject.transform.GetComponent<Button>().onClick.AddListener(()=>{
            MapManager.instance.currentMapType = MapManager.MapType.HeatMap;
            FilterManager.instance.parameterText.SetText("Sıcaklık : ");
            MapTypeButtonManager.instance.SelectButton(0);
            foreach (var city in MapManager.instance.cities)
            {
                MapManager.instance.ColorizeMap(MapManager.MapType.HeatMap,city);
            }
            CityManager.instance.EnableAllCities();
        });
    }
}
