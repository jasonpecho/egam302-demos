using UnityEngine;

public class AnimationCurveTest : MonoBehaviour
{
    public AnimationCurve lerpCurve;
    public AnimationCurve scaleCurve;

    private Vector3 startingPos;
    public Vector3 endOffset;

    public float moveDuration = 1f;

    public float lerpT = 0;
    public float scaleT = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        lerpT += Time.deltaTime;
        float curveVal = lerpCurve.Evaluate(lerpT / moveDuration);
        transform.position = Vector3.Lerp(startingPos, startingPos + endOffset, curveVal);   

        scaleT += Time.deltaTime;
        float scaleCurveVal = scaleCurve.Evaluate(scaleT / moveDuration);
        transform.localScale = new Vector3(scaleCurveVal, scaleCurveVal, scaleCurveVal);
    }
}
