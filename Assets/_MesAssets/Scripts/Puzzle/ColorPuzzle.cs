using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Netcode;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class ColorPuzzle : NetworkBehaviour
{

    [SerializeField] private GameObject[] _button;
    [SerializeField] private GameObject[] _image;
    [SerializeField] private TMP_Text _puzzleColorTitle = default;

    private NetworkVariable<Color> _color0 = new NetworkVariable<Color>(Color.red);
    private NetworkVariable<Color> _color1 = new NetworkVariable<Color>(Color.blue);
    private NetworkVariable<Color> _color2 = new NetworkVariable<Color>(Color.yellow);
    private NetworkVariable<Color> _color3 = new NetworkVariable<Color>(Color.green);

    private int[]  _intRandomTab = new int[4];
    private int[]  _intTab = new int[4];
    private int _nbBtnPush = 0;

    private bool _puzzleColorEnable = false;


    void Start()
    {
        if (!IsServer)
        {
            return;
        }
        for (int i = 0; i < 4; i++)
        {
            int ran = Random.Range(0, 4);
            CouleurClientRpc(ran, i);
        }

    }

    [ClientRpc]
    private void CouleurClientRpc(int ran, int i)
    {
        _button[0].GetComponent<Image>().color = _color0.Value;
        _button[1].GetComponent<Image>().color = _color1.Value;
        _button[2].GetComponent<Image>().color = _color2.Value;
        _button[3].GetComponent<Image>().color = _color3.Value;

        
            
            _intRandomTab[i] = ran;
            switch (ran)
            {
                case 0:
                    _image[i].GetComponent<Image>().color = _color0.Value;
                    break;
                case 1:
                    _image[i].GetComponent<Image>().color = _color1.Value;
                    break;
                case 2:
                    _image[i].GetComponent<Image>().color = _color2.Value;
                    break;
                case 3:
                    _image[i].GetComponent<Image>().color = _color3.Value;
                    break;

            }
        
    }
    [ServerRpc(RequireOwnership = false)]
    public void redBtnServerRpc()
    {
        redBtnClientRpc();
    }

    [ClientRpc]
    public void redBtnClientRpc()
    {

        _intTab[_nbBtnPush] = 0;

        CheckArrayClientRpc();

    }

    [ServerRpc(RequireOwnership = false)]
    public void blueBtnServerRpc()
    {
        blueBtnClientRpc();
    }

    [ClientRpc]
    public void blueBtnClientRpc()
    {

        _intTab[_nbBtnPush] = 1;

        CheckArrayClientRpc();

    }

    [ServerRpc(RequireOwnership = false)]
    public void yellowBtnServerRpc()
    {
        yellowBtnClientRpc();
    }

    [ClientRpc]
    public void yellowBtnClientRpc()
    {

        _intTab[_nbBtnPush] = 2;

        CheckArrayClientRpc();

    }

    [ServerRpc(RequireOwnership = false)]
    public void greenBtnServerRpc()
    {
        greenBtnClientRpc();
    }

    [ClientRpc]
    public void greenBtnClientRpc()
    {

        _intTab[_nbBtnPush] = 3;

        CheckArrayClientRpc();

    }

    [ServerRpc(RequireOwnership = false)]
    public void resetPuzzleServerRpc()
    {
        resetPuzzleClientRpc();
    }

    [ClientRpc]
    public void resetPuzzleClientRpc()
    {
        _nbBtnPush = 0;

    }

    [ClientRpc]
    private void CheckArrayClientRpc()
    {
        if (!_puzzleColorEnable)
        {
            _nbBtnPush++;
            if (_nbBtnPush == 4)
            {
                if (_intRandomTab.SequenceEqual(_intTab))
                {
                    _puzzleColorEnable = true;
                    _puzzleColorTitle.text = "Combinaison Valide !";
                }
                _nbBtnPush = 0;
            }
        }
    }
}
