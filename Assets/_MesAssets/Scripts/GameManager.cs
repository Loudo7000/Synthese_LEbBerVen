using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float _timeDebut;

    private void Start()
    {

        _timeDebut = Time.time;
        
    }

    public void PlayerPref()
    {
        PlayerPrefs.SetFloat("TempsPartie", (Time.time - _timeDebut));
        PlayerPrefs.Save();
    }

}
