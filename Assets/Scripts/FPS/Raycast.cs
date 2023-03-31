using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    [SerializeField] private float _raycastDist = 2f;
    [SerializeField] private LayerMask _raycastLayerMask;
    private DraggableObject _currentlyDraggedObject = null;
    [SerializeField] private float _draggableObjectDistance = 2f;

    void Update()
    {
        Debug.DrawLine(_cam.transform.position, _cam.transform.position + _cam.transform.forward * _raycastDist, Color.white);

        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit hit;
            if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, _raycastDist, _raycastLayerMask))
            {
                if (hit.collider.TryGetComponent(out LightSwitcher lightSwitcher))
                {
                    lightSwitcher.TurnOnLight();
                }
                
                if (hit.collider.TryGetComponent(out CrateOpener crateOpener))
                {
                    crateOpener.openOrClose();
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, _raycastDist, LayerMask.GetMask("DraggableObject")))
            {
                if (hit.collider.TryGetComponent(out DraggableObject draggableObject))
                {
                    draggableObject.StartFollowingObject();
                    _currentlyDraggedObject = draggableObject;
                }
            }
        }

        if (_currentlyDraggedObject != null)
        {
            Vector3 targetPosition = _cam.transform.position + _cam.transform.forward * _draggableObjectDistance;
            _currentlyDraggedObject.SetTargetPosition(targetPosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (_currentlyDraggedObject != null)
            {
                _currentlyDraggedObject.StopFollowingObject();
                _currentlyDraggedObject = null;
            }
        }

    }
}
