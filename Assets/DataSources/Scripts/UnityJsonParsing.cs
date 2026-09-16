using System;
using UnityEngine;

public class UnityJsonParsing : MonoBehaviour
{
    public bool useResource;
    public TextAsset jsonAsset;

    public string jsonPath;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!useResource)
        {
            PlayerData data = JsonUtility.FromJson<PlayerData>(jsonAsset.text);

            Debug.Log("JSON: " + data.ToString());
        }
        else
        {
            TextAsset jsonFile = Resources.Load<TextAsset>(jsonPath); // no extension
            PlayerData data = JsonUtility.FromJson<PlayerData>(jsonFile.text);

            Debug.Log("JSON: " + data.ToString());
        }    
    }
}
