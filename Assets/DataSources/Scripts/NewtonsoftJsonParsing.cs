using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class NewtonsoftJsonParsing : MonoBehaviour
{
    public bool useResource;
    public TextAsset jsonAsset;

    public string jsonPath;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!useResource)
        {
            Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonAsset.text);

            foreach (var item in data)
            {
                Debug.Log("Key: " + item.Key + " Value: " + item.Value);
            }

            string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);
            Debug.Log("JSON String: " + jsonString);
        }
        else
        {
            TextAsset jsonFile = Resources.Load<TextAsset>(jsonPath); // no extension
            Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonFile.text);

            foreach (var item in data)
            {
                Debug.Log("Key: " + item.Key + " Value: " + item.Value);
            }

            string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);
            Debug.Log("JSON String: " + jsonString);
        }
    }
}
