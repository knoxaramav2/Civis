using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{

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

	    Clickable newSelect = null, oldSelect = null;
	    oldSelect = _selected == null ? null : _selected.GetComponent<Clickable>();

        var hitInfo = new RaycastHit();
	    var hit = Physics.Raycast(
	        Camera.main.ScreenPointToRay(Input.mousePosition),
            out hitInfo);

	    if (!hit) return;
	    
	    var target = hitInfo.transform.gameObject;
	    
	    newSelect = target.GetComponent<Clickable>();

        if ((_hovered != target) && (_selected != target))
	    {
            if (_hovered != null && _hovered != _selected)
	            _hovered.GetComponent<Renderer>().material.shader = BaseShader;
	        _hovered = target;
            _hovered.GetComponent<Renderer>().material.shader = HoverShader;
	    }

	    if (Input.GetMouseButtonDown(0))
	    {
            Select(target);
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

    public void SetSelectedObject(GameObject gm)
    {
        Select(gm);
    }

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

    private void Select(GameObject gm)
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

    }
}
