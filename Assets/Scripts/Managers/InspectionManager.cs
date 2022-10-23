using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectionManager : MonoBehaviour
{
    [SerializeField] Transform cityPrefabLocation;
    [SerializeField] Transform parentObject;
    GameObject cityObject = null;

    void OnEnable()
    {
        cityObject = Instantiate<GameObject>(CityManager.instance.GetSelectedCity().gameObject,new Vector3(cityPrefabLocation.transform.position.x,cityPrefabLocation.transform.position.y+1f,cityPrefabLocation.transform.position.z),Quaternion.identity);
        cityObject.GetComponent<CityMouseController>().enabled = false; 
        cityObject.transform.rotation = Quaternion.AngleAxis(45, Vector3.right);
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
