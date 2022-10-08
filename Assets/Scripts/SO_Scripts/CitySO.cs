using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/City")]
public class CitySO : ScriptableObject
{
    public int plateNo;
    public string cityName;
    public int heatValue;
    public int populationValue;
    public Transform cityPrefab;

}
