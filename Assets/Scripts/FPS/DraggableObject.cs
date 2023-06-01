using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class DraggableObject : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _intialScale;
    [SerializeField] private bool _isKinematicAfterDrop;
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private bool _follow;
    [SerializeField] private float _followSpeed = 15f;
    [SerializeField] private float _velocityLimit = 8f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void Update()
    {
        if (!_follow)
            return;

        Vector3 moveDirection = _targetPosition - _rigidbody.position;
        _rigidbody.velocity = Vector3.ClampMagnitude(moveDirection * _followSpeed, _velocityLimit);
    }

    public void StartFollowingObject()
    {
        _follow = true;
        _rigidbody.isKinematic = false;
    }

    public void SetTargetPosition(Vector3 newTargetPosition)
    {
        _targetPosition = newTargetPosition;
    }

    public void StopFollowingObject()
    {
        _follow = false;
        _rigidbody.velocity = Vector3.zero;

        if (_isKinematicAfterDrop)
            _rigidbody.isKinematic = true;
    }
}
