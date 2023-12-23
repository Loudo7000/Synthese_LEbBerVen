using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class Generateur : NetworkBehaviour
{

    [SerializeField] private int _nbCoupsWrench;
    [SerializeField] private AudioSource _sonWrench;
    [SerializeField] private AudioSource _sonGas;


    private NetworkVariable<int> _nbCoup = new NetworkVariable<int>();
    private NetworkVariable<int> _qteGas = new NetworkVariable<int>();
    private bool _sortie = false;
    private UIGenerateur _etat;

    public int NbCoup { get => _nbCoup.Value;}
    public int QteGas { get => _qteGas.Value; }

    private void Start()
    {
        _etat = FindObjectOfType<UIGenerateur>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wrench"))
        {
            CoupWrenchClientRpc();
            _sonWrench.Play();
        }

        if (_nbCoup.Value == _nbCoupsWrench)
        {
            _etat.ChangerEtatWrenchClientRpc();
        }
    }

    [ClientRpc]
    private void CoupWrenchClientRpc()
    {
        _nbCoup.Value++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Gas"))
        {
            if (_qteGas.Value < 20)
            {
                _sonGas.Play();
            }

            _sortie = false;
            StartCoroutine(CompteurGasCoroutine());
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == ("Gas"))
        {
            _sonGas.Stop();
            _sortie = true;
            StopAllCoroutines();
        }
    }

    IEnumerator CompteurGasCoroutine()
    {
        if (_qteGas.Value < 20)
        {
            yield return new WaitForSeconds(2);
            AugmenterQteGas();
        }
        else if (_qteGas.Value == 20)
        {
            _etat.ChangerEtatGasClientRpc();
        }
    }

    private void AugmenterQteGas()
    {
        if (_sortie)
        {
            StopAllCoroutines();
            _sonGas.Stop();
        }
        else
        {
            _qteGas.Value += 2;
            _etat.AugmenterGasClientRpc(_qteGas.Value);
            StartCoroutine(CompteurGasCoroutine());
        }
    }
}
