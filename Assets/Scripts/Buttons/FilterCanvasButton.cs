using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FilterCanvasButton : MonoBehaviour
{
    private bool isActive = false;
    [SerializeField] Transform filterCanvas;
    void Start()
    {
        gameObject.transform.GetComponent<Button>().onClick.AddListener(()=>{
            isActive = !isActive;
            filterCanvas.gameObject.SetActive(isActive);
        });
    }
}
