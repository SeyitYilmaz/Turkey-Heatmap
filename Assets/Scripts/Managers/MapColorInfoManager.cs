using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MapColorInfoManager : MonoBehaviour
{

    public static MapColorInfoManager instance{get; private set;}
    public Texture[] textures;
    [SerializeField] TextMeshProUGUI startValueText;
    [SerializeField] TextMeshProUGUI endValueText;
    [SerializeField] RawImage gradientImage;


    void Awake()
    {
        if (instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void SetStartText(string startValueText)
    {
        this.startValueText.text = startValueText;
    }

    public void SetEndText(string endValueText)
    {
        this.endValueText.text = endValueText;
    }

    public void SetGradientTexture(int CurrentCanvasIndex)
    {
        gradientImage.texture = textures[CurrentCanvasIndex];
    }
}
