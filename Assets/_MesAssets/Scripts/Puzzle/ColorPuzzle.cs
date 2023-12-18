using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class ColorPuzzle : MonoBehaviour
{

    [SerializeField] private GameObject[] _button;
    [SerializeField] private GameObject[] _image;
    [SerializeField] private TMP_Text _puzzleColorTitle = default;

    private Color _color0 = Color.red;
    private Color _color1 = Color.blue;
    private Color _color2 = Color.yellow;
    private Color _color3 = Color.green;

    private int[]  _intRandomTab = new int[4];
    private int[]  _intTab = new int[4];
    private int _nbBtnPush = 0;

    private bool _puzzleColorEnable = false;


    void Start()
    {
       _button[0].GetComponent<Image>().color = _color0;
       _button[1].GetComponent<Image>().color = _color1;
       _button[2].GetComponent<Image>().color = _color2;
       _button[3].GetComponent<Image>().color = _color3;

        for(int i = 0; i < 4; i++)
        {
            int ran = Random.Range(0, 4);
            _intRandomTab[i] = ran;
            switch (ran)
            {
                case 0:
                    _image[i].GetComponent<Image>().color = _color0;
                    break;
                case 1:
                    _image[i].GetComponent<Image>().color = _color1;
                    break;
                case 2:
                    _image[i].GetComponent<Image>().color = _color2;
                    break;
                case 3:
                    _image[i].GetComponent<Image>().color = _color3;
                    break;

            }
        }


    }

    public void redBtn()
    {

        _intTab[_nbBtnPush] = 0;

        CheckArray();

    }
    public void blueBtn()
    {

        _intTab[_nbBtnPush] = 1;

        CheckArray();

    }
    public void yellowBtn()
    {

        _intTab[_nbBtnPush] = 2;

        CheckArray();

    }
    public void greenBtn()
    {

        _intTab[_nbBtnPush] = 3;

        CheckArray();

    }

    public void resetPuzzle()
    {
        _nbBtnPush = 0;

    }

    private void CheckArray()
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
