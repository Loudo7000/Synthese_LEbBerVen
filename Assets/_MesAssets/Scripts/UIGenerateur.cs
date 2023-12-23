using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class UIGenerateur : NetworkBehaviour
{
    [SerializeField] private TMP_Text _txtGenerateur = default;
    [SerializeField] private TMP_Text _txtGas = default;
    [SerializeField] private GameObject _btnGenerateur = default;
    [SerializeField] private Slider _sliderGas = default;
    [SerializeField] private AudioSource _sonGenerateur;


    private Generateur _generateur;
    private bool _allumer = false;

    public bool Allumer { get => _allumer; }

    private void Start()
    {
        _generateur = FindObjectOfType<Generateur>();
    }

    [ClientRpc]
    public void ChangerEtatWrenchClientRpc()
    {
        _txtGenerateur.text = "État : Réparer";
        _txtGenerateur.color = Color.green;
    }

    [ClientRpc]
    public void ChangerEtatGasClientRpc()
    {
        _txtGas.color = Color.green;
    }

    [ClientRpc]
    public void AugmenterGasClientRpc(int quantite)
    {
        if (quantite <= 20)
        {
            _txtGas.text = "Essence : " + quantite + " / 20L";
            _sliderGas.value = quantite;
        }
    }

    [ServerRpc(RequireOwnership =false)]
    public void AllumerGenerateurServerRpc()
    {
        AllumerGenerateurClientRpc();
    }

    [ClientRpc]
    private void AllumerGenerateurClientRpc()
    {
        if (_generateur.NbCoup >= 3 && _generateur.QteGas >= 20)
        {
            _btnGenerateur.GetComponent<Image>().color = Color.green;
            _allumer = true;
            _sonGenerateur.Play();
        }
    }
}
