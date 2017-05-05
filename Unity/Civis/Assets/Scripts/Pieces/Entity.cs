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

    public void Destroy()
    {
        Location.Target.DecoupleEntity(this);
        Destroy(this);
    }

}
