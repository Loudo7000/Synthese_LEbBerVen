using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIFinJeu : MonoBehaviour
{
    [SerializeField] private TMP_Text _TempsPartie;
    [SerializeField] private TMP_Text _MeilleurTemps;

    private float _temps;
    private float _tempsRecord;
    private int _minute;
    private int _minuteRecord;
    private int _seconde;
    private int _secondeRecord;
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(PlayerPrefs.GetFloat("TempsPartie"));
        Debug.Log(PlayerPrefs.GetFloat("MeilleurTemps"));

        _temps = PlayerPrefs.GetFloat("TempsPartie");

        if (_temps < PlayerPrefs.GetFloat("MeilleurTemps", 0))
        {
            PlayerPrefs.SetFloat("MeilleurTemps", _temps);
        }

        _minute = (int)_temps / 60;
        _seconde = (int)_temps % 60;
        _TempsPartie.text= _minute.ToString("00") + ":" + _seconde.ToString("00");

        _tempsRecord = PlayerPrefs.GetFloat("MeilleurTemps");
        _minuteRecord = (int)_tempsRecord / 60;
        _secondeRecord = (int)_tempsRecord % 60;
        _MeilleurTemps.text = _minuteRecord.ToString("00") + ":" + _secondeRecord.ToString("00");

    }

}
