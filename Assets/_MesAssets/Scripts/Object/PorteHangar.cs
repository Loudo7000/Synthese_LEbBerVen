using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PorteHangar : NetworkBehaviour
{

    [SerializeField] private GameObject[] _openDoor = default;
    [SerializeField] private GameObject[] _closeDoor = default;
    [SerializeField] private GameObject _knobOn = default;
    [SerializeField] private GameObject _knobOff = default;
    private bool _knobState = false;
    private UIGenerateur _generateurUI;

    private void Start()
    {
        _generateurUI = FindObjectOfType<UIGenerateur>();

        _knobOn.gameObject.SetActive(false);

        foreach (var door in _openDoor)
        {
            door.gameObject.SetActive(false);
        }

    }

    [ServerRpc(RequireOwnership =false)]
    public void knobSwitchServerRpc()
    {
        knobSwitchClientRpc();
    }

    [ClientRpc]
    private void knobSwitchClientRpc()
    {
        if (_generateurUI.Allumer)
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
