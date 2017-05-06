using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dev : MonoBehaviour
{
    public CameraControl control;
    public GameObject target;

	// Use this for initialization
	void Start ()
	{
	    control.SnapTo(target);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
