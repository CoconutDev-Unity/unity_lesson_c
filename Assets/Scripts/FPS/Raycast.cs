using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    [SerializeField] private float _raycastDist = 2f;
    [SerializeField] private LayerMask _raycastLayerMask;
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
            }
            else
            {
                Debug.Log("We hit nothing");
            }
        }
    }
}
