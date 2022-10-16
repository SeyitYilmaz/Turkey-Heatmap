using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    public static MouseWorld instance;
    void Start()
    {
        instance = this;   
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray,out hit, 999f);
        return hit.point;
    }

    public static Vector3 GetMouseWorldPosition(float distance)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray,out hit, distance);
        return hit.point;
    }
    public static Vector3 GetMouseWorldPosition(float distance, LayerMask layerMask)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray,out hit, distance,layerMask);
        return hit.point;
    }
    
    public static Transform GetMouseHitTransform()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray,out hit, 999f);
        return hit.transform;
    }
    public static Transform GetMouseHitTransform(LayerMask layerMask)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray,out hit, 999f,layerMask);
        return hit.transform;
    }
}
