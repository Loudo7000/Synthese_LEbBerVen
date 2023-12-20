using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteHangar : MonoBehaviour
{

    [SerializeField] private GameObject[] _openDoor = default;
    [SerializeField] private GameObject[] _closeDoor = default;
    [SerializeField] private GameObject _knobOn = default;
    [SerializeField] private GameObject _knobOff = default;
    private bool _knobState = false;
    private UIGenerateur _generateur;

    private void Start()
    {
        _generateur = FindObjectOfType<UIGenerateur>();

        _knobOn.gameObject.SetActive(false);

        foreach (var door in _openDoor)
        {
            door.gameObject.SetActive(false);
        }

    }


    public void knobSwitch()
    {
        if (_generateur.Allumer)
        {
            _knobState = !_knobState;

            if (_knobState)
            {
                foreach (var door in _openDoor)
                {
                    door.gameObject.SetActive(true);
                }

                foreach (var door in _closeDoor)
                {
                    door.gameObject.SetActive(false);
                }


                _knobOn.gameObject.SetActive(true);
                _knobOff.gameObject.SetActive(false);

            }
            else
            {

                foreach (var door in _openDoor)
                {
                    door.gameObject.SetActive(false);
                }

                foreach (var door in _closeDoor)
                {
                    door.gameObject.SetActive(true);
                }

                _knobOn.gameObject.SetActive(false);
                _knobOff.gameObject.SetActive(true);


            }
        }
        
    }

}
