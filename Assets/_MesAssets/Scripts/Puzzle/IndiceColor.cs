using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndiceColor : MonoBehaviour
{

    [SerializeField] GameObject _plate = default;
    [SerializeField] private AudioSource _sonWrench;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wrench")
        {
            _plate.SetActive(false);
            _sonWrench.Play();
        }
    }
}
