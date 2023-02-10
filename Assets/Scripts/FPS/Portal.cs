using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Color _lightColor;
    [SerializeField] private LightChanger _lightChanger;

    private void Awake()
    {
        _lightChanger = FindObjectOfType<LightChanger>();
    }

    public void SetLightColor(Color color)
    {
        _lightColor = color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _lightChanger.TurnOnLight(_lightColor);
        }
    }
}
