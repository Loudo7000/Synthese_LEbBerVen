using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class UIIngame : MonoBehaviour
{

    [SerializeField] private TMP_Text _txtTemps = default;
    [SerializeField] private AudioSource AudioSource = default;
    private float _timeDebut;
    private bool _Audio = true;

    private void Start()
    {
        _timeDebut = Time.time;
    }

    private void Update()
    {
        _txtTemps.text = (Time.time - _timeDebut).ToString("f2");
    }

    public void sourdine()
    {

        if (_Audio)
        {
            _Audio = false;
            AudioSource.Stop();
        }
        else
        {
            _Audio = true;
            AudioSource.Play();
        }
    }


}
