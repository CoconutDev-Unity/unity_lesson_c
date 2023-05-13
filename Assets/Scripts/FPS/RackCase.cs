using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RackCase : MonoBehaviour, IOpenable
{
    [SerializeField] private bool _isOpened;
    [SerializeField] public float _openCloseTime = 1f;
    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    [SerializeField] private float _moveForwardBy = 0.3f;
    public float openToCloseLerp;

    private void Start()
    {
        _startPosition = transform.position;
        _targetPosition = transform.position - transform.forward * _moveForwardBy;
        //_targetPosition = transform.position - transform.right * _moveForwardBy;
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

    public void OpenOrClose()
    {
        _isOpened = !_isOpened;
        StopAllCoroutines();

        if (_isOpened)
        {
            StartCoroutine(Open());
        } else
        {
            StartCoroutine(Close());
        }
    }
}