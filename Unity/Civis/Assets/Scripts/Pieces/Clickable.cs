using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{

    private static Session _session;

    public virtual void OnSelect()
    {
        if (_session == null)
            _session = GameObject.FindGameObjectWithTag("TempState")
                .GetComponent<Session>();

        if ((this as Entity).Owner != _session.Current) return;

        Camera.main.GetComponent<CameraControl>().SnapTo(gameObject);
    }

    public virtual void OnDeSelect()
    {
        
    }

    public virtual void OnMiddleSelect()
    {
        
    }
}
