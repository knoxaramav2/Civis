using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//lists all available units and buildings belonging to a faction
public class Faction
{

    public string FactionName;


    //
    public List<ActorSheet> ActorSheets;

    public List<BuildingSheet> BuildingSheets;

    public void LoadFactionInfo()
    {
        
    }

}

//outlines base values of 
public class ObjectSheet
{
    public string Name;
    public string Faction;

    public int MaxHealth;
    public int MaxDefense;

}

public class ActorSheet
{
    public int MaxAttack;

    public List<Buff> Buffs;
}

public class BuildingSheet
{
    
}