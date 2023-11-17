using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private Button _hostButton = default;
    [SerializeField] private Button _serverButton = default;
    [SerializeField] private Button _clientButton = default;

    private void Start()
    {
        _hostButton.onClick.AddListener(() => NetworkManager.Singleton.StartHost());
        _serverButton.onClick.AddListener(() => NetworkManager.Singleton.StartServer());
        _clientButton.onClick.AddListener(() => NetworkManager.Singleton.StartClient());
    }
}
