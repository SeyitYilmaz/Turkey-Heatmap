using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairWorld : MonoBehaviour
{
    public static CrosshairWorld instance;
    public static Camera cam = Camera.main;

    private void Start() 
    {
        instance = this;   
    }
    public static Vector3 GetCrosshairWorldPosition()
    {
        RaycastHit hit;
        Physics.Raycast(cam.transform.position,cam.transform.forward ,out hit, 999f);
        return hit.point;
    }

    public static Vector3 GetCrosshairWorldPosition(float distance)
    {
        RaycastHit hit;
        Physics.Raycast(cam.transform.position,cam.transform.forward ,out hit, distance);
        return hit.point;
    }
    public static Vector3 GetCrosshairWorldPosition(float distance, LayerMask layerMask)
    {
        RaycastHit hit;
        Physics.Raycast(cam.transform.position,cam.transform.forward ,out hit, distance, layerMask);
        return hit.point;
    }

    public static Transform GetObjectFromCrosshairPosition()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position,cam.transform.forward ,out hit, 999f))
            return hit.transform;
        return hit.transform;
    }

    public static Transform GetObjectFromCrosshairPosition(float distance)
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position,cam.transform.forward ,out hit, distance))
            return hit.transform;
        return hit.transform;
    }
    public static Transform GetObjectFromCrosshairPosition(float distance, LayerMask layerMask)
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position,cam.transform.forward ,out hit, distance, layerMask))
            return hit.transform;
        return hit.transform;
    }

    public static RaycastHit GetHitFromCrosshairPosition(float distance, LayerMask layerMask)
    {
        RaycastHit hit;
        Physics.Raycast(cam.transform.position,cam.transform.forward ,out hit, distance, layerMask);
        return hit;
    }

}
