using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Gear : MonoBehaviour
{

    private GearPuzzle _gearPuzzle;

    private void Start()
    {
        _gearPuzzle = FindObjectOfType<GearPuzzle>();
    }

    private void FixedUpdate()
    {
        if (_gearPuzzle.PuzzleGearEnable)
        {
            this.transform.Rotate(0f, 0f, -1f);
        }
    }

}
