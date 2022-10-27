using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/City")]
public class CitySO : ScriptableObject
{
    public CityData cityData;
    public Transform cityPrefab;

}
