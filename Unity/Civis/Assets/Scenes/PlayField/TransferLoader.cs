using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferLoader : MonoBehaviour {

    private GameObject _dataShuttle;

    // Use this for initialization
    void Start () {
		var state = _dataShuttle = GameObject.FindGameObjectWithTag("TempState");
        state.AddComponent<Map>();
    }
}
