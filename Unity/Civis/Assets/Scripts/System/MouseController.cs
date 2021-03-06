﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public SelectController _scontrol;

    private GameObject _selected;
    private GameObject _hovered;

    public Shader SelectShader;
    public Shader BaseShader;
    public Shader HoverShader;

    private bool _disableClicking;

	// Use this for initialization
	void Start ()
	{
	    _selected = null;
	    _hovered = null;

	    _disableClicking = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (_disableClicking) return;

	    //Clickable newSelect = null, oldSelect = null;
	    //oldSelect = _selected == null ? null : _selected.GetComponent<Clickable>();

        RaycastHit hitInfo;
	    var hit = Physics.Raycast(
	        Camera.main.ScreenPointToRay(Input.mousePosition),
            out hitInfo);

	    if (!hit) return;
	    
	    var target = hitInfo.transform.gameObject;

        _scontrol.Hover(target);

	    if (Input.GetMouseButtonDown(0))
	    {
            _scontrol.Select(target);
	    }
	}

    public void SetClickable(bool allow)
    {
        _disableClicking = !allow;
    }

    public GameObject GetSelectedObject()
    {
        return _selected;
    }

    public GameObject GetHoveredObject()
    {
        return _hovered;
    }

    //public void SetSelectedObject(GameObject gm)
    //{
    //    Select(gm);
    //}

    private void DeSelect()
    {
        if (_selected == null)
            return;

        var oldSelect = _selected.GetComponent<Clickable>();
        if (oldSelect != null)
            oldSelect.OnDeSelect();
        _selected.GetComponent<Renderer>().material.shader = BaseShader;
        _selected = null;
    }

    /*private void Select(GameObject gm)
    {
        if (gm == _selected || gm == null)
        {
            DeSelect();
            return;
        }

        DeSelect();

        _selected = gm;

        var newSelect = _selected.GetComponent<Clickable>();
        if (newSelect != null)
            newSelect.OnSelect();
        _selected.GetComponent<Renderer>().material.shader = SelectShader;

    }*/
}
