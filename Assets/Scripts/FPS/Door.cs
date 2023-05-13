using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IOpenable
{
    [SerializeField] private bool _isOpened;
    [SerializeField] public float _openCloseTime = 1f;
    private Vector3 _startRotation;
    private Vector3 _targetRotation;
    [SerializeField] private float _rotateByDegrees = -90f;
    //[SerializeField] private float _moveForwardBy = 0.3f;
    public float openToCloseLerp;

    //private void Start()   ------OLD------
    //{
    //    _startPosition = transform.position;
    //    _targetPosition = transform.position - transform.forward * _moveForwardBy;
    //}
    private void Start()
    {
        _startRotation = transform.rotation.eulerAngles;
        _targetRotation = _startRotation + Vector3.up * _rotateByDegrees;
    }

    //private void Update()
    //{
    //    transform.rotation = Quaternion.Lerp(Quaternion.Euler(_startRotation),Quaternion.Euler(_targetRotation), openToCloseLerp);

    //    openToCloseLerp = _isOpened ?
    //        Math.Clamp(openToCloseLerp + Time.deltaTime / _openCloseTime, 0, 1)
    //        : Math.Clamp(openToCloseLerp - Time.deltaTime / _openCloseTime, 0, 1);
    //}

    IEnumerator Open()
    {
        while (openToCloseLerp < 1)
        {openToCloseLerp += Time.deltaTime / _openCloseTime;
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(_startRotation), Quaternion.Euler(_targetRotation), openToCloseLerp);
            
            yield return null;
        }
    }

    IEnumerator Close()
    {
        while (openToCloseLerp > 0)
        {
            openToCloseLerp -= Time.deltaTime / _openCloseTime;
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(_startRotation), Quaternion.Euler(_targetRotation), openToCloseLerp);

            yield return null;
        }
    }

    //IEnumerator Open()
    //{
    //    while (openToCloseLerp < 1)
    //    {
    //        openToCloseLerp += Time.deltaTime / _openCloseTime;
    //        transform.position = Vector3.Lerp(_startRotation, _targetRotation, openToCloseLerp);
    //        yield return null;
    //    }
    //}

    //IEnumerator Close()
    //{
    //    while (openToCloseLerp > 0)
    //    {
    //        openToCloseLerp -= Time.deltaTime / _openCloseTime;
    //        transform.position = Vector3.Lerp(_startRotation, _targetRotation, openToCloseLerp);
    //        yield return null;
    //    }
    //}

    public void OpenOrClose()
    {
        _isOpened = !_isOpened;
        StopAllCoroutines();

        if (_isOpened)
        {
            StartCoroutine(Open());
        }
        else
        {
            StartCoroutine(Close());
        }
    }
    //public void OpenOrClose()  -----OLD-----
    //{
    //    if (_isOpened)
    //    {
    //        StartCoroutine(Open());
    //    } else
    //    {
    //        StartCoroutine(Close());
    //    }
    //}
}