using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestGenerator : MonoBehaviour
{

    [SerializeField] private int _nbCoupsWrench;

    private int _nbCoup;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wrench")
        {
            _nbCoup++;
        }

        if (_nbCoup >= _nbCoupsWrench)
        {
            this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 255);
        }

        Debug.Log(_nbCoup);
    }
}
