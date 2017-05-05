using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour {

    void Start()
    {
        
    }

    public virtual void OnSelect()
    {
        Debug.Log("Click");
    }

    public virtual void OnDeSelect()
    {
        Debug.Log("UnClick");
    }

    public virtual void OnMiddleSelect()
    {
        
    }
}
