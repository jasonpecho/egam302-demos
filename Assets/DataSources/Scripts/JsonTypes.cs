[System.Serializable]
public class Vector3Data
{
    public float x, y, z;

    public override string ToString()
    {
        return $"Vector3Data: {x}, {y}, {z}";
    }
}

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int level;
    public float health;
    public bool isAlive;
    public Vector3Data position;   // nested object — fine
    public string[] inventory;     // array as a field — fine
    public int[] stats;            // fine
    public int spattack = -1;

    public override string ToString()
    {
        return $"PlayerData: {playerName}, {level}, {health}, {isAlive}, {position.ToString()}, {string.Join(", ", inventory)}, {string.Join(", ", stats)}, {string.Join(", ", spattack)}";
    }
}