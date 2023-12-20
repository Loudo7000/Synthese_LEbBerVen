using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class UIGenerateur : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtGenerateur = default;
    [SerializeField] private TMP_Text _txtGas = default;
    [SerializeField] private GameObject _btnGenerateur = default;
    [SerializeField] private Slider _sliderGas = default;
    [SerializeField] private AudioSource _sonGenerateur;


    private Generateur _generateur;
    private bool _allumer = false;

    public bool Allumer { get => _allumer; set => _allumer = value; }

    private void Start()
    {
        _generateur = FindObjectOfType<Generateur>();
    }

    public void ChangerEtatWrench()
    {
        _txtGenerateur.text = "�tat : R�parer";
        _txtGenerateur.color = Color.green;
    }

    public void ChangerEtatGas()
    {
        _txtGas.color = Color.green;
    }

    public void AugmenterGas(int quantite)
    {
        if(quantite <= 20)
        {
            _txtGas.text = "Essence : " + quantite + " / 20L";
            _sliderGas.value = quantite;
        }
    }

    public void AllumerGenerateur()
    {
        if(_generateur.NbCoup >= 3 && _generateur.QteGas >= 20)
        {
            _btnGenerateur.GetComponent<Image>().color = Color.green;
            _allumer = true;
            _sonGenerateur.Play();
        }
    }
}
