using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorSheet : Sheet {

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
        public string Name;
        public AttackType Type;
        public bool IsRanged;//Only ranged
        public int Range;//Both melee and 'ranged'
        public int Power;
        public int StaminaCost;
    }

    public List<Buff> Buffs;
    public List<Attack> Attacks;

    public ActorSheet()
    {
        Buffs = new List<Buff>();
        Attacks = new List<Attack>();
    }

}