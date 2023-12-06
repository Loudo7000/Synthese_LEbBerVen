using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGenerateur : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtGenerateur = default;
    [SerializeField] private TMP_Text _txtGas = default;
    [SerializeField] private Slider _sliderGas = default;


    public void ChangerEtatWrench()
    {
        _txtGenerateur.text = "État : Réparer";
        _txtGenerateur.color = Color.green;
    }

    public void ChangerEtatGas()
    {
        _txtGas.color = Color.green;
    }

    public void AugmenterGas(int quantite)
    {
        _txtGas.text = "Essence : " + quantite + " / 20L";
        _sliderGas.value = quantite;
        
    }
}
