using UnityEngine;

public class TriggerVolume : MonoBehaviour
{
    int triggered = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"triggered {triggered} times");
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Break();
        RecursiveTrigger(triggered);
        triggered += 1;
        Debug.Log(collider.gameObject.name, collider.gameObject);   
    }

    void RecursiveTrigger(int i)
    {
        if (i == 5)
        {
            return;
        }
        else
        {
            RecursiveTrigger(i+1);
        }
    }
}
