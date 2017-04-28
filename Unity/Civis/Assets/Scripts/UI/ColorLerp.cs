using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorLerp : MonoBehaviour
{
    public Color [] Colors;
    public float Speed;

    private int _currColor;
    private int _nextColor;
    private float _time;
    private Text _text;

	// Use this for initialization
	void Start ()
	{
	    _currColor = 0;
	    _nextColor = 1;

        _text = GetComponent<Text>();
        _text.color = Colors[0];
	}
	
	// Update is called once per frame
	void Update ()
	{
	    _time += Time.deltaTime * Speed;

	    _text.color = Color.Lerp(Colors[_currColor], Colors[_nextColor], _time);

	    if (_time >= 1)
	    {
	        _time = 0;

	        _currColor = _currColor + 1 == Colors.Length ? 0 : _currColor + 1;
            _nextColor = _currColor + 1 == Colors.Length ? 0 : _currColor + 1;
	    }
	}
}
