using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    void Start() 
    {
        gameObject.transform.GetComponent<Button>().onClick.AddListener(()=>{
            UIManager.instance.SelectCanvas(0);
            CameraManager.instance.SelectCamera(0);
        });
    }
}
