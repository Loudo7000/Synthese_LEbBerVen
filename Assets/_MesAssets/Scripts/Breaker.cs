using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Breaker : MonoBehaviour
{
    //[SerializeField] private int _mainSwitchOnPos = default;
    //[SerializeField] private int _mainSwitchOffPos = default;

    [SerializeField] private GameObject[] _light = default;
    [SerializeField] private GameObject _mainSwitch = default;
    private bool _mainSwitchState = false;

    private void Start()
    {

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


        }
        else
        {
            foreach (var light in _light)
            {
                light.gameObject.SetActive(false);
            }

        }
    }


}
