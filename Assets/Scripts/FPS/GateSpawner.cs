using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSpawner : MonoBehaviour
{
    [SerializeField] private LightChanger _lightChanger;
    [SerializeField] private Transform _gateParent;
    [SerializeField] private GameObject _lightPrefab;
    [SerializeField] private GameObject _gatesPrefab;
    [SerializeField] private float _distBetweenGates = 2f;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject gateGO = SpawnGate();

            ChangeLightAndGateToRandomColor(gateGO);
        }
    }

    private GameObject SpawnGate()
    {
        GameObject gateGO = Instantiate(_gatesPrefab, _gateParent);
        gateGO.transform.localPosition = Vector3.right * _gateParent.childCount * _distBetweenGates + Vector3.down * 13f + Vector3.left * 31f + Vector3.forward * 18f;
        return gateGO;
    }

    private void ChangeLightAndGateToRandomColor(GameObject gateGO)
    {
        Color randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        gateGO.GetComponentInChildren<Portal>().SetLightColor(randomColor);
        List<MeshRenderer> _meshRenderers = new List<MeshRenderer>(gateGO.GetComponentsInChildren<MeshRenderer>());
        foreach (MeshRenderer meshRenderer in _meshRenderers)
        {
            if (meshRenderer.GetComponent<LightSwitcher>() != null)
                continue;
            meshRenderer.material.SetColor("_EmissionColor", randomColor);
        }
    }
}
