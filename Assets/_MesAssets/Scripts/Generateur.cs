using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class Generateur : MonoBehaviour
{

    [SerializeField] private int _nbCoupsWrench;

    private int _nbCoup;
    private int _qteGas;
    private bool _sortie = false;
    private UIGenerateur _etat;

    public int NbCoup { get => _nbCoup; set => _nbCoup = value; }
    public int QteGas { get => _qteGas; set => _qteGas = value; }

    private void Start()
    {
        _etat = FindObjectOfType<UIGenerateur>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wrench"))
        {
            _nbCoup++;
        }

        if (_nbCoup == _nbCoupsWrench)
        {
            _etat.ChangerEtatWrench();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Gas"))
        {
            _sortie = false;
            StartCoroutine(CompteurGasCoroutine());
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == ("Gas"))
        {
            _sortie = true;
            StopAllCoroutines();
        }
    }

    IEnumerator CompteurGasCoroutine()
    {
        if (_qteGas < 20)
        {
            yield return new WaitForSeconds(2);
            AugmenterQteGas();
        }
        else if (_qteGas >= 20)
        {
            _etat.ChangerEtatGas();
        }
    }

    private void AugmenterQteGas()
    {
        if (_sortie)
        {
            StopAllCoroutines();
        }
        else
        {
            _qteGas += 2;
            _etat.AugmenterGas(_qteGas);
            StartCoroutine(CompteurGasCoroutine());
        }
    }
}
