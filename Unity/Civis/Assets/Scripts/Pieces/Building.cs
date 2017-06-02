using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Entity
{
	// Use this for initialization
    public new void Start()
    {
        base.Start();
    }

    void SpawnUnit(SelectController sc)
    {
        sc.SetInteract(SelectController.SelectMode.Highlight);
        Menu.Hide();
    }

    public override void OnSelect(SelectController sc = null)
    {
        base.OnSelect(sc);

        if (sc == null)
            return;

        sc.SelectRadius(1);
        sc.SetInteract(SelectController.SelectMode.GuiOnly);

        Menu.Hide();
        Menu.AddButton("Spawn", () => { SpawnUnit(sc);});
        Menu.AddButton("Close", () => { Menu.Hide(sc); });
        Menu.Move(0, 0);
        Menu.Show();
    }
}
