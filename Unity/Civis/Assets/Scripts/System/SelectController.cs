using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectController : MonoBehaviour {

    private GameObject _selected;
    private GameObject _hovered;
    private GameObject _lastHovered;
    private GameObject [] _highlighted;

    private Map _map;

    private Color _hovSelTemp;

    public Color HovSelColor;
    public Shader SelectShader;
    public Shader BaseShader;
    public Shader HoverShader;
    public Shader HighlightShader;//TODO Hover shader

    //private bool _disabled;
    private SelectMode _selectMode;

    public enum SelectMode
    {
        Normal,
        Highlight,
        GuiOnly
    }

    // Use this for initialization
    void Start ()
    {
        Debug.Log("Init Select");

        _selected = null;
        _hovered = null;
        _highlighted = null;

        _map = GameObject.FindGameObjectWithTag("TempState")
            .GetComponent<Map>();

        _selectMode = SelectMode.Normal;
    }

    public void Hover(GameObject obj)
    {
        if (obj == _hovered || _selectMode == SelectMode.GuiOnly) return;

        if (_hovered != _selected)
            SetShader(_hovered, BaseShader);
            
        if (obj != _selected)
            SetShader(obj, HoverShader);

        if (_highlighted != null)
        {
            if (_highlighted.Contains(obj))
            {
                _hovSelTemp = GetColor(obj);
                SetColor(obj, HovSelColor);
            }

            if (obj != _lastHovered)
            {
                SetColor(_lastHovered, _hovSelTemp);
                _lastHovered = _hovered;
            }
        }

        
        _hovered = obj;
    }

    public void Select(GameObject obj)
    {
        if (_selectMode == SelectMode.GuiOnly) return;

        Deselect();

        if (obj != _selected && _selected != null)
            SetShader(_selected, BaseShader);

        SetShader(obj, SelectShader);

        _selected = obj;

        var entity = _selected.GetComponent<Entity>();
        if (entity == null) return;
        entity.OnSelect(this);
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

        if (_highlighted != null)
        {
            foreach (var cell in _highlighted)
            {
                SetShader(cell, BaseShader);
            }

            _highlighted = null;
        }
        
    }

    public void SelectRadius(int radius)
    {
        var ent = _selected.GetComponent<Entity>();
        var cells = _map.GetAdjacentCells(ent.Location.Target, 
            radius, true);

        foreach (var cell in cells)
        {
            SetShader(cell.Target.gameObject, HoverShader);
        }

        _highlighted = cells.Select(o => o.Target.gameObject).ToArray();
    }

    public void SetInteract(SelectMode mode)
    {
        _selectMode = mode;
    }

    private void SetShader(GameObject obj, Shader shader)
    {
        obj.GetComponent<Renderer>().material.shader = shader;
    }

    private void SetColor(GameObject obj, Color color)
    {
        if (obj == null) return;
        obj.GetComponent<Renderer>().material.color = color;
    }

    private Color GetColor(GameObject obj)
    {
        return obj.GetComponent<Renderer>().material.color;
    }

    private Shader GetShader(GameObject obj)
    {
        return obj.GetComponent<Renderer>().material.shader;
    }
}
