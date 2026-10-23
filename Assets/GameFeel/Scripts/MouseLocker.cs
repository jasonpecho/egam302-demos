using UnityEngine;

public class MouseLocker : MonoBehaviour
{
    public bool lockMouse = true;

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = lockMouse ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
