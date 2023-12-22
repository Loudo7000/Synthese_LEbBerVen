using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemi"))
        {
            _audioSource.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ennemi"))
        {
            _audioSource.Stop();
        }
    }
}
