using System.Collections.Generic;
using UnityEngine;

public class CsvParsing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<LevelInfo> levels = new List<LevelInfo>();
        TextAsset csvFile = Resources.Load<TextAsset>("data\\levels");
        string[] lines = csvFile.text.Split('\n');

        for (int i = 1; i < lines.Length; i++) // skip header
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;
            string[] fields = lines[i].Split(',');

            levels.Add(new LevelInfo
            {
                name = fields[0].Trim(),
                difficulty = int.Parse(fields[1].Trim()),
                enemyCount = int.Parse(fields[2].Trim()),
                timeLimit = float.Parse(fields[3].Trim()),
                unlocked = bool.Parse(fields[4].Trim())
            });
        }

        foreach (var level in levels)
        {
            Debug.Log("Level: " + level.name + " Difficulty: " + level.difficulty + " Enemy Count: " + level.enemyCount + " Time Limit: " + level.timeLimit + " Unlocked: " + level.unlocked);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
