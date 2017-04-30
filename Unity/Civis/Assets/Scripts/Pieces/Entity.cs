using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public string Name;
    public float Health, MaxHealth;

    public Tile Location;
    public Player Owner;

    public void Destroy()
    {
        
    }

}
