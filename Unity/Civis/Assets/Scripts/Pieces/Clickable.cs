using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public CustomMenu Menu;

    private static Session _session;

    public void Start()
    {
        Menu = CustomMenu.CreateCustomMenu(
            GameObject.Find("Canvas"), 
            0,0, 300);

        Debug.Log("asdasdsd");
    }

    public virtual void OnSelect()
    {
        Menu.Move(0, 0);
        Menu.Show();

        if (_session == null)
            _session = GameObject.FindGameObjectWithTag("TempState")
                .GetComponent<Session>();

        var entity = this as Entity;
        if (entity != null && entity.Owner != _session.Current) return;
    }

    public virtual void OnDeSelect()
    {
        
    }

    public virtual void OnMiddleSelect()
    {
        Camera.main.GetComponent<CameraControl>().ZoomTo(gameObject);
    }
}
