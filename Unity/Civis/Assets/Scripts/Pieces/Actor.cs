using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Actor : Entity
{
    private ActorSheet _sheet;

    public int Exp;
    public int Level;
    public int LevelUpExp;

    public void Start()
    {
        base.Start();
    }

    public Actor(ActorSheet sheet)
    {
        _sheet = sheet;
    }

}
