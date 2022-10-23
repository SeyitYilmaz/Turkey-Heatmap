using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance{get; private set;}
    public Canvas[] canvases;
    int selectCanvasIndex = 0;

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
        DisableAllCanvases();
        SelectCanvas(0);
    }
    public void SelectCanvas(int canvasIndex)
      {
          if( canvasIndex >= 0 && canvasIndex < canvases.Length )
          {
            canvases[selectCanvasIndex].gameObject.SetActive(false);
            selectCanvasIndex = canvasIndex;
            canvases[selectCanvasIndex].gameObject.SetActive(true);
          }
      }

    private void DisableAllCanvases()
    {
        for (int i = 0; i < canvases.Length; i++)
        {
            canvases[i].gameObject.SetActive(false);;
        }
    }

}
