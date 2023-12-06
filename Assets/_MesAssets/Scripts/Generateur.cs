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
    private bool _sortie = false;
    private int _qteGas;
    private UIGenerateur _etat;

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
            StopCoroutine(CompteurGasCoroutine());
        }
    }

    IEnumerator CompteurGasCoroutine()
    {
        if (_qteGas < 20)
        {
            yield return new WaitForSeconds(2);
            AugmenterQteGas();
        }
        else if (_qteGas == 20)
        {
            _etat.ChangerEtatGas();
        }
    }

    private void AugmenterQteGas()
    {
        if (_sortie)
        {
            StopCoroutine(CompteurGasCoroutine());
        }
        else
        {
            _qteGas += 2;
            _etat.AugmenterGas(_qteGas);
            StartCoroutine(CompteurGasCoroutine());
        }
    }
}
