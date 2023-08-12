using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Material targetMaterial; // The material you want to change the color of
    public float colorChangeInterval = 2.0f; // Time interval for color change in seconds

    private Color startColor;
    private Color endColor;
    private float startTime;

    private void Start()
    {
        if (targetMaterial == null)
        {
            Debug.LogError("Target material not assigned!");
            enabled = false;
            return;
        }

        startColor = Color.white;
        endColor = Color.red;
        startTime = Time.time;
    }

    private void Update()
    {
        float elapsedTime = Time.time - startTime;
        float t = Mathf.PingPong(elapsedTime / colorChangeInterval, 1f);

        Color lerpedColor = Color.Lerp(startColor, endColor, t);
        targetMaterial.color = lerpedColor;
    }
}