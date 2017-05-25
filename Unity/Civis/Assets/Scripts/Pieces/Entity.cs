using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : Clickable
{
    public string Name;
    public string Id;
    public float Health, MaxHealth;

    public Cell Location;
    public Player Owner;

    public new void Start()
    {
        base.Start();
    }

    public void CoupleToCell(Cell loc)
    {
        loc.Target.CoupleEntity(this);
        Location = loc;
        transform.position = loc.Target.GetSurfaceCoord();
    }

    public void CoupleToPlayer(Player plr)
    {
        plr.AddPiece(this);
    }

    public void Destroy()
    {
        Location.Target.DecoupleEntity(this);
        Destroy(this);
    }

}
