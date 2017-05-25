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

    void SpawnUnit()
    {
        Menu.Hide();
    }

    public override void OnSelect(SelectController sc = null)
    {
        base.OnSelect(sc);

        if (sc)
            sc.SelectRadius(1);

        Menu.Hide();
        Menu.AddButton("Spawn", SpawnUnit);
        Menu.AddButton("Close", () => { Menu.Hide(); });
        Menu.Move(0, 0);
        Menu.Show();
    }
}
