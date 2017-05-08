using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActorTemplate
{
    public GameObject Template;

    public ActorTemplate()
    {
        Template = null;
    }
}

public class UnitManager : MonoBehaviour
{

    private Map _map;

    public List<ActorTemplate> Templates;

    void Start()
    {
        _map = GameObject.FindGameObjectWithTag("TempState").GetComponent<Map>();

        Templates = new List<ActorTemplate>();

        //load building sheets

        //load building models
        var am = new ActorTemplate { Template = Resources.Load("Models/Buildings/Default") as GameObject };
        Debug.Log(am);
        Templates.Add(am);
    }

    public Actor CreateActor(Player p, string buildingName, Cell loc, bool free = false)
    {
        var actor = Instantiate(Templates.ElementAt(0).Template);
        var a = actor.GetComponent<Actor>();
        loc.Target.CoupleEntity(a);
        p.AddPiece(a);

        actor.transform.position = loc.Target.GetSurfaceCoord();

        return a;
    }
}
