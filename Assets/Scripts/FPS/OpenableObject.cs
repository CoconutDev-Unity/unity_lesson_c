//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class OpenableObject : IOpenable 
//{
//    private Vector3 _startPosition;
//    private Vector3 _targetPosition;
//    [SerializeField] private float _moveDownBy = 5f;

//    private void Start()
//    {
//        this._startPosition = transform.position;
//        this._targetPosition = transform.position - transform.up * _moveDownBy;
//    }

//    public IEnumerator GoUnderground()
//    {
//        while (this.openToCloseLerp < 1)
//        {
//            this.openToCloseLerp += Time.deltaTime / this._openCloseTime;
//            transform.position = Vector3.Lerp(this._startPosition, this._targetPosition, this.openToCloseLerp);
//            yield return null;
//        }
//    }
//}
