using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/CityTypeList")]
public class CityTypeListSO : ScriptableObject
{
   public List<CitySO> cityList;
}
