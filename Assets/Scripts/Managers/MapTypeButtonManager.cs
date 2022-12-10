using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapTypeButtonManager : MonoBehaviour
{
    public static MapTypeButtonManager instance {get; private set;}
    public Button[] mapTypeButtons;
    public int currentButtonID = 0;
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
        DisableAllButtons();
        SelectButton(0);
    }
    public void SelectButton(int buttonIndex)
      {
          if( buttonIndex >= 0 && buttonIndex < mapTypeButtons.Length )
          {
            mapTypeButtons[currentButtonID].gameObject.transform.Find("background").GetComponent<Outline>().enabled = false;
            currentButtonID = buttonIndex;
            mapTypeButtons[currentButtonID].gameObject.transform.Find("background").GetComponent<Outline>().enabled = true;
            MapColorInfoManager.instance.SetGradientTexture(buttonIndex);
            if(MapManager.instance.currentMapType == MapManager.MapType.HeatMap)
            {
                MapColorInfoManager.instance.SetStartText(MapManager.instance.maxHeatVal.ToString());
                MapColorInfoManager.instance.SetEndText(MapManager.instance.minHeatVal.ToString());
            }
            else
            {
                MapColorInfoManager.instance.SetStartText(MapManager.instance.maxPopValue.ToString());
                MapColorInfoManager.instance.SetEndText(MapManager.instance.minPopValue.ToString());
            }
          }
      }

    private void DisableAllButtons()
    {
        for (int i = 0; i < mapTypeButtons.Length; i++)
        {
            mapTypeButtons[i].gameObject.transform.Find("background").GetComponent<Outline>().enabled = false;
        }
    }
}
