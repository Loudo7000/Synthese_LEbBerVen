using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndiceColor : MonoBehaviour
{

    [SerializeField] GameObject _plate = default;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wrench")
        {
            _plate.SetActive(false);
        }
    }
}
