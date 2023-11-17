using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionsKitVR : MonoBehaviour
{
    [SerializeField] private Transform _root = default;
    public Transform Root => _root;

    [SerializeField] private Transform _tete = default;
    public Transform Tete => _tete;

    [SerializeField] private Transform _mainG = default;
    public Transform MainG => _mainG;

    [SerializeField] private Transform _mainD = default;
    public Transform MainD => _mainD;

}
