using UnityEngine;

public class PlayerDataComponent : MonoBehaviour
{
    public PlayerData[] playerData;

    public PlayerDataSO[] playerDataSOs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var data in playerData)
        {
            Debug.Log("Player Data: " + data.ToString());
        }
        foreach (var data in playerDataSOs)
        {
            Debug.Log("Player Data SO: " + data.playerData.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
