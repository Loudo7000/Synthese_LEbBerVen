using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class ColorPuzzle : MonoBehaviour
{

    [SerializeField] GameObject[] _button;
    [SerializeField] GameObject[] _image;

    private Color _color0 = Color.red;
    private Color _color1 = Color.blue;
    private Color _color2 = Color.yellow;
    private Color _color3 = Color.green;

    private int[]  _intRandom = new int[4];
    private int[]  _int = new int[4];

    private 

    void Start()
    {
       _button[0].GetComponent<Image>().color = _color0;
       _button[1].GetComponent<Image>().color = _color1;
       _button[2].GetComponent<Image>().color = _color2;
       _button[3].GetComponent<Image>().color = _color3;

        for(int i = 0; i < 4; i++)
        {
            int ran = Random.Range(0, 4);
            _intRandom[i] = ran;
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


            Debug.Log(_intRandom[i]);
        }


    }

    public void ButtonTransitionColors()
    {


    }
}
