using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class AvatarReseau : NetworkBehaviour
{
    [SerializeField] private Transform _rootAvatar = default;
    [SerializeField] private Transform _teteAvatar = default;
    [SerializeField] private Transform _mainGAvatar = default;
    [SerializeField] private Transform _mainDAvatar = default;

    private PositionsKitVR _positionKitVR;

    void Start()
    {
        _positionKitVR = FindObjectOfType<PositionsKitVR>();
    }

    private void Update()
    {
        if (IsOwner)
        {
            _rootAvatar.position = _positionKitVR.Root.position;
            _rootAvatar.rotation = _positionKitVR.Root.rotation;

            _teteAvatar.position = _positionKitVR.Tete.position;
            _teteAvatar.rotation = _positionKitVR.Tete.rotation;

            _mainGAvatar.position = _positionKitVR.MainG.position;
            _mainGAvatar.rotation = _positionKitVR.MainG.rotation;

            _mainDAvatar.position = _positionKitVR.MainD.position;
            _mainDAvatar.rotation = _positionKitVR.MainD.rotation;
        }

    }
}
