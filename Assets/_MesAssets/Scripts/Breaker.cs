using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Breaker : MonoBehaviour
{

    [SerializeField] private GameObject[] _light = default;
    [SerializeField] private GameObject _mainSwitch = default;
    private bool _mainSwitchState = false;

    private quaternion _mainSwitchOnPos = default;
    private quaternion _mainSwitchOffPos = default;

    private void Start()
    {



        foreach (var light in _light)
        {
            light.gameObject.SetActive(false);
        }

        _mainSwitch.transform.rotation = _mainSwitchOffPos;

    }


    public void mainSwitch()
    {
        _mainSwitchState = !_mainSwitchState;

        if (_mainSwitchState)
        {
            foreach (var light in _light)
            {
                light.gameObject.SetActive(true);
            }

            _mainSwitch.transform.rotation = _mainSwitchOnPos;

        }
        else
        {
            foreach (var light in _light)
            {
                light.gameObject.SetActive(false);
            }

            _mainSwitch.transform.rotation = _mainSwitchOffPos;

        }
    }


}
