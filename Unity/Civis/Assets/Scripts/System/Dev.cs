using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dev : MonoBehaviour
{
    public CameraControl control;
    public GameObject target;
    public GameObject DevPanel;
    public GameObject Canvas;

    // Use this for initialization
    void Start ()
	{
	    control.SnapTo(target);

	    var tstate = GameObject.FindGameObjectWithTag("TempState")
            ?? new GameObject {tag = "TempState"};

	    tstate.AddComponent<Session>();

	    var menu = CustomMenu.CreateCustomMenu(Canvas, 300, 300, 300);
	    menu.name = "DevPanel";

	    menu.AddButton("msg1", () => DoStuff("hi"));
	    menu.AddButton("msg2", () => DoStuff("lo"));
	    menu.AddButton("Close", () => menu.Hide());

        menu.Show();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DoStuff(string msg)
    {
        Debug.Log(">> " + msg);
        switch (msg)
        {
            case "hi": Debug.Log("hi");
                break;
            default: Debug.Log("meh");
                break;
        }
    }
}
