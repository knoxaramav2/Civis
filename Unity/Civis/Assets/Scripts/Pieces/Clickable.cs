using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public CustomMenu Menu;

    private static Session _session;

    public void Start()
    {
        Menu = GameObject.FindGameObjectWithTag("State").GetComponent<CustomMenu>();
    }

    public virtual void OnSelect(SelectController sc = null)
    {
        if (_session == null)
            _session = GameObject.FindGameObjectWithTag("TempState")
                .GetComponent<Session>();

        Camera.main.GetComponent<CameraControl>().ZoomTo(gameObject);
    }

    public virtual void OnDeSelect()
    {
        
    }

    public virtual void OnMiddleSelect()
    {
        
    }
}
