using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIFinJeu : MonoBehaviour
{
    [SerializeField] private TMP_Text _TempsPartie;
    [SerializeField] private TMP_Text _MeilleurTemps;

    private float _temps;
    private int _minute;
    private int _seconde;
    // Start is called before the first frame update
    void Start()
    {
        _temps = PlayerPrefs.GetFloat("TempsPartie");
        _minute = (int)_temps / 60;
        _seconde = (int)_temps % 60;
        _TempsPartie.text= "Temps de la partie : " + _minute.ToString("00") + ":" + _seconde.ToString("00");
        
        _temps = PlayerPrefs.GetFloat("MeilleurTemps");
        _minute = (int)_temps / 60;
        _seconde = (int)_temps % 60;
        _MeilleurTemps.text = "Meilleur temps : " + _minute.ToString("00") + ":" + _seconde.ToString("00");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
