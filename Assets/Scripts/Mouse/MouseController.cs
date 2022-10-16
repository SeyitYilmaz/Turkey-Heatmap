using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    void OnMouseEnter()
    {
        transform.localPosition = new Vector3(transform.position.x,transform.position.y+0.2f,transform.position.z);
        CityManager.instance.SetSelectedCity(gameObject.transform);
    }
    private void OnMouseExit()
    {
        transform.localPosition = new Vector3(transform.position.x,transform.position.y-0.2f,transform.position.z);
    }
}