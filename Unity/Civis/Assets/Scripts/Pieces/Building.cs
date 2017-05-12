using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Entity
{
	// Use this for initialization
    public void Start()
    {
        base.Start();
    }

    void SpawnUnit()
    {
        Menu.Hide();
    }

    public override void OnSelect()
    {
        base.OnSelect();

        Menu.Hide();
        Menu.AddButton("Spawn", SpawnUnit);
        Menu.AddButton("Close", () => { Menu.Hide(); });
        Menu.Move(0, 0);
        Menu.Show();
    }
}
