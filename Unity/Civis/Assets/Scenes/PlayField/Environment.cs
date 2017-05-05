using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Environment : MonoBehaviour
{

    public Light Light;

    public float CycleSpeed = 2f;

    public enum Weather
    {
        Clear,
        Snowing,
        Raining,
        Fog,
        Storm
    }

    private Weather _wheather;

	// Use this for initialization
	void Start ()
	{
	    _wheather = (Weather) Random.Range(0, Enum.GetNames(typeof(Weather)).Length);
	}
	
	// Update is called once per frame
	void Update () {
		Light.transform.Rotate(Vector3.left * Time.deltaTime * CycleSpeed);
	}
}
