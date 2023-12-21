using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearPuzzle : MonoBehaviour
{
    private bool _puzzleGearEnable = false;

    private int _compteur = 0;
    private int _nbGear = 3;

    public bool PuzzleGearEnable { get => _puzzleGearEnable; set => _puzzleGearEnable = value; }

    public void OnSocket()
    {
        _compteur++;

        if (_compteur == _nbGear)
        {
            _puzzleGearEnable = true;
        }

    }

    public void OffSocket()
    {
        _compteur--;

        if (_compteur < _nbGear)
        {
            _puzzleGearEnable = false;
        }
    }
}
