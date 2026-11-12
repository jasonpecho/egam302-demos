using System.Collections;
using UnityEngine;

// Drives the "_FlashAmount" property on a HitFlash Shader Graph material.
// Test it in Play mode: component's ⋮ menu → Test Flash.
public class HitFlash : MonoBehaviour
{
    [SerializeField] float flashTime = 0.15f;

    // Must match the Reference field of the Flash Amount property in the graph.
    static readonly int FlashAmount = Shader.PropertyToID("_FlashAmount");

    Material mat;

    // .material gives this object its own copy, so only this one flashes.
    void Awake()
    {
        mat = GetComponent<Renderer>().material;
    }

    [ContextMenu("Test Flash")]
    public void Flash()
    {
        StopAllCoroutines();
        StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        for (float t = 0; t < flashTime; t += Time.deltaTime)
        {
            mat.SetFloat(FlashAmount, 1f - t / flashTime);
            yield return null;
        }
        mat.SetFloat(FlashAmount, 0f);
    }

    [ContextMenu("Debug: Flash On")]
    void FlashOn()
    {
        var r = GetComponent<Renderer>();
        r.material.SetFloat(FlashAmount, 1f);
        Debug.Log($"{name} | renderer on: {r.gameObject.name} | mat: {r.material.name} | " +
                $"shader: {r.material.shader.name} | value: {r.material.GetFloat(FlashAmount)} | " +
                $"slots: {r.sharedMaterials.Length}", r);
    }

    // Example gameplay hook:
    // void OnCollisionEnter(Collision c) => Flash();
}
