using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingTemplate
{
    public GameObject Template;

    public BuildingTemplate()
    {
        Template = null;
    }
}

public class BuildingManager : MonoBehaviour
{

    private Map _map;

    public List<BuildingTemplate> Templates;

    void Start()
    {
        _map = GameObject.FindGameObjectWithTag("TempState").GetComponent<Map>();

        Templates = new List<BuildingTemplate>();

        //load building sheets

        //load building models
        var bm = new BuildingTemplate {Template = Resources.Load("Models/Buildings/Default") as GameObject};
        Debug.Log(bm);
        Templates.Add(bm);
    }

    public Building CreateBuilding(Player p, string buildingName, Cell loc, bool free=false)
    {
        var bld = Instantiate(Templates.ElementAt(0).Template);
        var b = bld.GetComponent<Building>();
        loc.Target.CoupleEntity(b);
        p.AddPiece(b);

        bld.transform.position = loc.Target.GetSurfaceCoord();

        return b;


        return null;
    }
}
