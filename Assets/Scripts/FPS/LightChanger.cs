using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChanger : MonoBehaviour
{
    [SerializeField] private Color[] _initialColors;
    [SerializeField] private Portal portal;
    [SerializeField] public new Light light;
    [SerializeField] public Material _lightBulbMaterial;

    void Start()
    {
        Debug.Log(TurnOnInitialLight(3));
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
        Debug.Log("Before waiting");

        yield return new WaitForSeconds(2);

        _lightBulbMaterial.SetColor("_EmissionColor", light.color);
        light.color = color;

        Debug.Log("After waiting");

    }

    private string TurnOnInitialLight(int lightIndex)
    {
        return "Light has been turned on";
    }
}