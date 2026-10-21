using UnityEditor.AdaptivePerformance.Editor;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;
    public Transform previewTx;
    [Range(0f, 1f)] public float smoothing = 0.1f;
    [Range(0f, 5f)] public float sharpness = 0.1f;

    public bool preview = false;
    public bool frameRateIndependent = false;

    public bool smoothDamp = false;
    [Range(0f, 15f)] public float smoothDampMaxSpeed = 1.0f;
    [Range(0.01f, 2.0f)] public float smoothDampTime = 0.5f; 

    Vector3 offset;
    Quaternion startingRotation;

    Vector3 smoothDampVel = Vector3.zero;

    void Start()
    {
        offset = transform.position - target.position;
        startingRotation = transform.rotation;
    }

    void LateUpdate()
    {
        Vector3 targetPos = preview ? previewTx.position : target.position + offset;
        Quaternion targetRot = preview ? previewTx.rotation : startingRotation;
        float t = !frameRateIndependent ? smoothing : 1f - Mathf.Exp(-sharpness * Time.deltaTime);

        if(!smoothDamp)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, t);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref smoothDampVel, smoothDampTime, smoothDampMaxSpeed);
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, t);
    }
}