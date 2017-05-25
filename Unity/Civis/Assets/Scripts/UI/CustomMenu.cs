using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CustomMenu : MonoBehaviour
{
    public GameObject TargetPanel; 
    public List<Button> Controls = new List<Button>();

    private RectTransform rect;

    // Use this for initialization
    void Start()
    {
        rect = TargetPanel.GetComponent<RectTransform>();
    }

    public Button AddButton(string msg, UnityAction cb)
    {
        var gm = new GameObject();
        var label = new GameObject();
        var btn = gm.AddComponent<Button>();
        var text = label.AddComponent<Text>();
        var img = gm.AddComponent<Image>();
        var rPanel = rect.sizeDelta;

        Controls.Add(btn);
        gm.name = "Control " + Controls.Count;
        label.name = "Label";

        gm.transform.SetParent(TargetPanel.transform);
        label.transform.SetParent(gm.transform);

        gm.GetComponent<Image>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Resources/unity_builtin_extra/UISprite.psd");

        gm.GetComponent<RectTransform>().sizeDelta
            = new Vector2(rPanel.x*.9f, 30);
        label.GetComponent<RectTransform>().sizeDelta
            = new Vector2(rPanel.x * .9f, 30);

        img.sprite = Resources.Load("Background") as Sprite;
        img.color = Color.white;

        text.color = Color.black;
        text.font = Resources.Load<Font>("Font/zekton rg");
        text.text = msg;
        text.alignment = TextAnchor.MiddleCenter;

        btn.onClick.AddListener(cb);

        return btn;
    }

    public void Move(float x, float y)
    {
        TargetPanel.transform.position = new Vector3(Screen.width/2f+x, Screen.height/2f+y, 0);
    }

    public void Show()
    {
        TargetPanel.SetActive(true);

        rect.sizeDelta = new Vector2(rect.sizeDelta.x, (35 * Controls.Count) + 50);

        foreach(var ctrl in Controls)
        {
            var btn = ctrl.GetComponent<Button>();

            var offset = (TargetPanel.transform.position.y + rect.sizeDelta.y / 2) - 25;
            var deltay = (rect.sizeDelta.y / Controls.Count);

            ctrl.transform.position = new Vector3(
                TargetPanel.transform.position.x,
                offset - Controls.IndexOf(ctrl) * deltay);   
        }
    }

    public void Hide(SelectController sc = null)
    {
        Controls.Clear();
        TargetPanel.SetActive(false);

        if (sc == null) return;
        sc.SetInteract(true);
        sc.Deselect();
    }
	
    public static CustomMenu CreateCustomMenu(GameObject parent, int xOff, int yOff, float width)
    {
        var gm = new GameObject();
        var menu = gm.AddComponent<CustomMenu>();

        var rTransform = gm.AddComponent<RectTransform>();
        var pTransform = parent.transform;
        menu.transform.SetParent(pTransform);

        rTransform.sizeDelta = new Vector2(width, 10);
        gm.transform.position = new Vector3(xOff, yOff);

        var rend = gm.AddComponent<Image>();
        rend.color = new Color(0.145f, 0.161f, .463f);
        rend.sprite = Resources.Load("Background") as Sprite;

        gm.SetActive(false);

        return menu;
    }
}
