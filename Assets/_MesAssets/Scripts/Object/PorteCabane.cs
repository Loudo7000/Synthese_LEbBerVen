using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PorteCabane : MonoBehaviour
{

    [SerializeField] GameObject _porte = default;
    private bool _isOpen = false;

    public void switchLight()
    {
        _isOpen = !_isOpen;

        if (_isOpen)
        _porte.gameObject.SetActive(_porte);
    }
}
