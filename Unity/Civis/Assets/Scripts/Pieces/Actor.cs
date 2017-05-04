using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Effect
{
    //Powers and abilities
    Flight,
    Swim,
    Poison,
    Fire,
    Heal,
    Work,
    Range,
    
    //Conditions
    Poisoned,
    Burned,

    //Type buffs
    BuffFire,
    BuffWater,
    BuffCold,
    BuffHeat,
    BuffPoison
}

public enum AttackType
{
    Normal,
    Fire,
    Electric,
    Poison,
    Bleed
}

public class Buff
{
    public Effect Ability;
    public float Magnitude;
}

public class Attack
{
    private string name;
}

public class Actor : Entity
{
    public List<Buff> Buffs;
    public List<Attack> Attacks;

    public int Exp;
    public int Level;
    public int LevelUpExp;

    public Actor()
    {
        Buffs = new List<Buff>();
        Attacks = new List<Attack>();
    }

}
