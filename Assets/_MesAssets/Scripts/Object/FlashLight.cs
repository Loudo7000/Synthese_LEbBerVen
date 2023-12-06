using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{

    [SerializeField] GameObject _spotlight = default;

    private bool _enabled = true;

    public void switchLight()
    {
        _enabled = !_enabled;

        _spotlight.gameObject.SetActive(_enabled);
    }

}
