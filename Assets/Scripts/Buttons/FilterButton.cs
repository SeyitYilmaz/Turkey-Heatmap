using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FilterButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetComponent<Button>().onClick.AddListener(()=>{
            FilterManager.instance.Filter();
        });
    }
}
