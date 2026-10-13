using System.Data.Common;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject[] objs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        // rb.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + new Vector3(0, 10, 0) * Time.deltaTime;
        }

        // for (int i = 0; i < objs.Length; ++i)
        // {
        //     Debug.Log(objs[i].name);
        // }
    }
}
