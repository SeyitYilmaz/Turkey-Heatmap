using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class CityData : List<CityData>
{
    [JsonProperty("plateNumber")]public int plateNo;
    
    [JsonProperty("cityName")]public string cityName;
    [JsonProperty("heatValue")]public int heatValue;
    [JsonProperty("populationValue")]public int populationValue;

    public string Stringify() 
    {
        return JsonUtility.ToJson(this);
    }

    public static CityData Parse(string json)
    {
        return JsonUtility.FromJson<CityData>(json);
    }
}
