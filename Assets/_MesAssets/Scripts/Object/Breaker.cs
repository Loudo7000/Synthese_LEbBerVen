using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Breaker : MonoBehaviour
{

    [SerializeField] private GameObject[] _light = default;
    [SerializeField] private GameObject _mainSwitchOn = default;
    [SerializeField] private GameObject _mainSwitchOff = default;
    private bool _mainSwitchState = false;
    private UIGenerateur _generateur;

    private void Start()
    {
        _generateur = FindObjectOfType<UIGenerateur>();

        _mainSwitchOn.gameObject.SetActive(false);

        foreach (var light in _light)
        {
            light.gameObject.SetActive(false);
        }

    }


    public void mainSwitch()
    {
        if (_generateur.Allumer)
        {
            _mainSwitchState = !_mainSwitchState;

            if (_mainSwitchState)
            {
                foreach (var light in _light)
                {
                    light.gameObject.SetActive(true);
                }


                _mainSwitchOn.gameObject.SetActive(true);
                _mainSwitchOff.gameObject.SetActive(false);

            }
            else
            {
                foreach (var light in _light)
                {
                    light.gameObject.SetActive(false);
                }

                _mainSwitchOff.gameObject.SetActive(true);
                _mainSwitchOn.gameObject.SetActive(false);


            }
        }
        
    }


}
