using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpExample : MonoBehaviour
{
    public Transform ObjectToMove;
    public MeshRenderer objectToMoveMeshRenderer;
    public Transform StartPosition;
    public MeshRenderer startPositionMeshRenderer;
    public Transform EndPosition;
    public MeshRenderer endPositionMeshRenderer;
    [Range(0, 1)]
    public float t;
    public Color startColor;
    public Color endColor;

    private void Start()
    {
        startColor = startPositionMeshRenderer.material.GetColor("_EmissionColor");
        endColor = endPositionMeshRenderer.material.GetColor("_EmissionColor");
    }

    private void Update()
    {
        ObjectToMove.position = Vector3.Lerp(StartPosition.position, EndPosition.position, t);
        Color objColor = Color.Lerp(startColor, endColor, t);
        objectToMoveMeshRenderer.material.SetColor("_EmissionColor", objColor);
    }
}
