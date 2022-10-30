using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class CityData
{
    [JsonProperty("plateNumber")]public int plateNo;
    
    [JsonProperty("cityName")]public string cityName;
    [JsonProperty("heatValue")]public float heatValue;
    [JsonProperty("populationValue")]public int populationValue;

}
