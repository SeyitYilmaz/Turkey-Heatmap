using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.Networking;
using Newtonsoft.Json;
public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance{get; private set;}
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
        /*StartCoroutine(Download("ANKARA"_city.cityName, result => {
            Debug.Log(result.cityName);
        }));*/
    }

    public IEnumerator Download(string cityName, System.Action<CityData>callback = null)
        {
            using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:3000/numberPlate/" + cityName))
            {
                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.Log(request.error);
                    if (callback != null)
                    {
                        callback.Invoke(null);
                    }
                }
                else
                {
                    if (callback != null)
                    {
                        //Debug.Log(request.downloadHandler.text);
                        callback.Invoke(JsonConvert.DeserializeObject<CityData>(request.downloadHandler.text));
                        //callback.Invoke(CityData.Parse((request.downloadHandler.text)));
                    }
                }
            }
        }
}
