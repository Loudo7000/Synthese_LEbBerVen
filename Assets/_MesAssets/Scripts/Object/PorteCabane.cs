using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PorteCabane : NetworkBehaviour
{

    [SerializeField] private GameObject _openDoor = default;
    [SerializeField] private GameObject _closeDoor = default;
    private bool _doorState = false;

    private void Start()
    {
        _openDoor.gameObject.SetActive(false);
    }

    [ServerRpc(RequireOwnership = false)]
    public void doorServerRpc()
    {
        doorClientRpc();
    }

    [ClientRpc]
    private void doorClientRpc()
    {
        _doorState = !_doorState;

        if (_doorState)
        {
            _openDoor.gameObject.SetActive(true);
            _closeDoor.gameObject.SetActive(false);
        }
        else
        {
            _closeDoor.gameObject.SetActive(true);
            _openDoor.gameObject.SetActive(false);
        }
    }
}
