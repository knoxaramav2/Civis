using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player
{

    public string UserName;
    public string UserId;

    public bool IsHost;

    public Race.Type Team;

    public ResourceCounter RscCounter;
    public List<Entity> Pieces;

	// Use this for initialization
	void Start () {

        RscCounter = new ResourceCounter();
		Pieces = new List<Entity>();

	    IsHost = false;
	}

    public void AddPiece(Entity piece)
    {
        if (Pieces.Any(entity => piece == entity))
        {
            return;
        }

        Pieces.Add(piece);
    }

    public void DestroyPiece(Entity piece)
    {
        var entity = Pieces.FirstOrDefault(o => o == piece);

        if (entity == false) return;

        Pieces.Remove(piece);
        piece.Destroy();
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