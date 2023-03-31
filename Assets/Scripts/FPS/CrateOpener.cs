using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateOpener : MonoBehaviour
{
    [SerializeField] private bool _isOpen;
    [SerializeField] private float _openCloseTime = 1f;
    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    [SerializeField] private float _moveForwardBy = 0.3f;
    private float openToCloseLerp;

    private void Start()
    {
        _startPosition = transform.position;
        _targetPosition = transform.position - transform.forward * _moveForwardBy;
    }

    IEnumerator Open()
    {
        while (openToCloseLerp < 1)
        {
            openToCloseLerp += Time.deltaTime / _openCloseTime;
            transform.position = Vector3.Lerp(_startPosition, _targetPosition, openToCloseLerp);
            yield return null;
        }
    }

    IEnumerator Close()
    {
        while (openToCloseLerp > 0)
        {
            openToCloseLerp -= Time.deltaTime / _openCloseTime;
            transform.position = Vector3.Lerp(_startPosition, _targetPosition, openToCloseLerp);
            yield return null;
        }
    }

    public void openOrClose()
    {
        if (_isOpen)
        {
            StartCoroutine(Open());
        } else
        {
            StartCoroutine(Close());
        }
    }
}