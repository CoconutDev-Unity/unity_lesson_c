using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChanger : MonoBehaviour
{
    [SerializeField] private Color[] _initialColors;
    [SerializeField] private Portal portal;
    [SerializeField] public new Light light;
    [SerializeField] public Material _lightBulbMaterial;
    [SerializeField] private float _interpolationTime = 1f;

    void Start()
    {
        TurnOnInitialLight(3);
    }

    public void ChangeLightColor(Color color)
    {
        light.color = color;
    }

    private enum initialLight
    {
        Red, Blue, Purple
    }

    public void TurnOnLight(Color color)
    {
        StartCoroutine(WaitToTurnOnLight(color));
    }

    private IEnumerator WaitToTurnOnLight(Color color)
    {
        float t = 0f;
        Color startColor = light.color;
        while (t < 1)
        {
            Color interpolatedColor = Color.Lerp(startColor, color, t);
            _lightBulbMaterial.SetColor("_EmissionColor", interpolatedColor);
            light.color = interpolatedColor;
            t += Time.deltaTime / _interpolationTime;
            yield return null;
        }
    }

    private string TurnOnInitialLight(int lightIndex)
    {
        return "Light has been turned on";
    }
}