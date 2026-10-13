using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public bool translational = true;
    public bool rotational = true;
    public bool traumaCubed = false;

    public float frequency = 25f;
    public Vector3 maxTranslation = new Vector3(0.5f, 0.5f, 0f);
    public Vector3 maxRotation = new Vector3(2f, 2f, 5f);
    public float decay = 1f;
    [Range(0f, 1f)] public float trauma;

    Vector3 startPosition;
    Quaternion startRotation;

    void Start()
    {
        startPosition = transform.localPosition;
        startRotation = transform.localRotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) trauma = 1f;

        float shake = trauma * trauma * (traumaCubed ? trauma : 1.0f);
        float t = Time.time * frequency;

        Vector3 offset = translational ? Vector3.Scale(maxTranslation, Noise(t, 0.5f)) * shake : Vector3.zero;
        Vector3 angles = rotational ? Vector3.Scale(maxRotation, Noise(t, 10.5f)) * shake : Vector3.zero;

        transform.localPosition = startPosition + offset;
        transform.localRotation = startRotation * Quaternion.Euler(angles);

        trauma = Mathf.Clamp01(trauma - decay * Time.deltaTime);
    }

    Vector3 Noise(float t, float seed)
    {
        return new Vector3(
            Mathf.PerlinNoise(t, seed) * 2f - 1f,
            Mathf.PerlinNoise(t, seed + 1f) * 2f - 1f,
            Mathf.PerlinNoise(t, seed + 2f) * 2f - 1f);
    }
}