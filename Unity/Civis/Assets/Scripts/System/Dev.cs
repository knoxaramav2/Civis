using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dev : MonoBehaviour
{
    public CameraControl control;
    public GameObject target;
    public GameObject DevPanel;

    // Use this for initialization
    void Start ()
	{
	    control.SnapTo(target);

	    var tstate = GameObject.FindGameObjectWithTag("TempState")
            ?? new GameObject {tag = "TempState"};

	    tstate.AddComponent<Session>();

        AddButton("hi");
        AddButton("not hi");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddButton(string msg)
    {
        var Front = new GameObject();
        Front.transform.SetParent(DevPanel.transform);
        var img = Front.AddComponent<Image>();
        img.rectTransform.sizeDelta = new Vector2(60, 30);
        img.sprite = Resources.Load("UISprite") as Sprite;
        var btn = Front.AddComponent<Button>();
        var label = new GameObject();
        label.transform.SetParent(Front.transform);
        var lbl = label.AddComponent<Text>();
        lbl.text = msg;
        lbl.color = Color.black;
        lbl.font = Resources.Load("Arial") as Font;
        btn.onClick.AddListener(() => { DoStuff(msg); });
    }

    public void DoStuff(string msg)
    {
        switch (msg)
        {
            case "hi": Debug.Log("hi");
                break;
            default: Debug.Log("meh");
                break;
        }
    }
}
