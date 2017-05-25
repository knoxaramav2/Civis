using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectController : MonoBehaviour {

    private GameObject _selected;
    private GameObject _hovered;
    private GameObject _highlited;

    public Map Map;

    public Shader SelectShader;
    public Shader BaseShader;
    public Shader HoverShader;
    public Shader HighlightShader;//TODO Hover shader

    private bool _disableClicking;

    // Use this for initialization
    void Start ()
    {
        _selected = null;
        _hovered = null;
    }

    public void Hover(GameObject obj)
    {
        if (obj == _hovered) return;

        if (_hovered != _selected)
            SetShader(_hovered, BaseShader);
            
        if (obj != _selected)
            SetShader(obj, HoverShader);

        _hovered = obj;
    }

    public void Select(GameObject obj)
    {
        Deselect();

        if (obj != _selected && _selected != null)
            SetShader(_selected, BaseShader);

        SetShader(obj, SelectShader);

        _selected = obj;
    }

    public void Deselect()
    {
        if (_selected == null)
            return;

        var oldSelect = _selected.GetComponent<Clickable>();
        if (oldSelect != null)
            oldSelect.OnDeSelect();
        SetShader(_selected, BaseShader);
        _selected = null;
    }

    public void SelectRadius(int radius)
    {
        var ent = _selected.GetComponent<Entity>();
        Map.GetAdjacentCells(ent.Location.Target, 
            radius, true);
    }

    public void SetInteract(bool enable)
    {
        _disableClicking = !enable;
    }

    private void SetShader(GameObject obj, Shader shader)
    {
        obj.GetComponent<Renderer>().material.shader = shader;
    }

    private Shader GetShader(GameObject obj)
    {
        return obj.GetComponent<Renderer>().material.shader;
    }
}
