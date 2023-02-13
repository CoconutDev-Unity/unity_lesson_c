using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitcher : MonoBehaviour
{
    [SerializeField] private Portal _portal;

    public void TurnOnLight()
    {
        _portal.TurnOnLightThroughPortal();
    }
}
