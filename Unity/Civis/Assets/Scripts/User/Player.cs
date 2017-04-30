using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public string UserName;
    public string UserId;

    public Race.Type Team;

    public ResourceCounter RscCounter;
    public List<Entity> Pieces;

	// Use this for initialization
	void Start () {
		Pieces = new List<Entity>();
	}
	
}

public class ResourceCounter
{
    private List<Resource> _resources;
    private List<int> _count;

    public bool AddResource(Resource rsc, int count, bool force=false)
    {


        //return false if subtracting more than available
        return true;
    }
}