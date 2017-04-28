using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAnim : MonoBehaviour
{
    private List<GameObject> _panels;
    private GameObject _current;

	// Use this for initialization
	void Start ()
	{
        _panels = new List<GameObject>();

	    foreach (Transform child in transform)
	    {
	        if (child.tag == "UI_Panel")
	        {
	            _panels.Add(child.gameObject);
                child.gameObject.SetActive(false);

                if (child.name == "Front")
	            {
	                _current = child.gameObject;
                    _current.SetActive(true);
	            }
            }
	    }
	}

    public void SwitchTo(string menu)
    {
        foreach (var panel in _panels)
        {
            if (!panel.name.Equals(menu)) continue;

            //enable selected panel, close current
            //TODO add slide animation
            _current.SetActive(false);
            _current = panel;
            _current.SetActive(true);

            break;
        }
    }
}
