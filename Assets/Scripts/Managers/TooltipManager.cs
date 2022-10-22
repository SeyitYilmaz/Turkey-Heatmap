using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager instance{get; private set;}
    [SerializeField] TextMeshProUGUI tooltipText;

    void Awake()
    {
        if(instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    
    void Start() 
    {
        gameObject.SetActive(true);
    }

    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void ShowTooltip(string text)
    {
        gameObject.SetActive(true);
        tooltipText.text = text;
    }
    public void HideTooltip()
    {
        gameObject.SetActive(false);
        tooltipText.text = string.Empty;
    }


}
