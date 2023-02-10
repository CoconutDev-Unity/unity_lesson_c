using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralAnimation : MonoBehaviour
{
    public float amplitude = 1.0f;
    public float frequency = 1.0f;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float y = amplitude * Mathf.Sin(Time.time * frequency);
        transform.position = startPosition + new Vector3(0, y, 0);
    }
}

