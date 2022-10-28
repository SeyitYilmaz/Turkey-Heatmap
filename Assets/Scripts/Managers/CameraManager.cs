using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance{get; private set;}
    public Camera[] cameras;
    int selectedCameraIndex = 0;
    void Awake() 
    {
        if (instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    void Start() 
    {
        DisableAllCameras();
        SelectCamera(0);
    }

    public void SelectCamera(int cameraIndex)
      {
          if( cameraIndex >= 0 && cameraIndex < cameras.Length )
          {
            cameras[selectedCameraIndex].gameObject.SetActive(false);
            selectedCameraIndex = cameraIndex;
            cameras[selectedCameraIndex].gameObject.SetActive(true);
          }
      }

    private void DisableAllCameras()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);;
        }
    }
}
