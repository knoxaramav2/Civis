using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LoadInfoManifest : MonoBehaviour
{
    private LinkedList<Order> _orders;
    private int _index;

    public LoadInfoManifest()
    {
        _orders = new LinkedList<Order>();
        _index = 0;
    }

    //create order manifest from string
    public void AssignManifest(string mn)
    {
        _orders = new LinkedList<Order>();
    }

    public override string ToString()
    {

        return "";
    }

    public void AddOrder(Order order)
    {
        //_orders.Add(order);
        _orders.AddLast(order);
    }

    public Order GetNextOrder()
    {
        return _index == _orders.Count ? null : _orders.ElementAt(_index++);
    }

    public void Rewind()
    {
        _index = 0;
    }

    public int Count()
    {
        return _orders.Count;
    }
}

public class Order
{
    public enum Instruction
    {
        Move,
        Create,
        Destroy,
        Modify,
        Focus
    }

    public enum TargetType
    {
        Camera,
        Unit,
        Player,
        Building,
        Resource,
        Tile,
        Effect,
        Class
    }

    public enum Keys
    {
        Location,
        Health,
        Attack,
        Defense,
        Buf,
        Type,
        Target
    }

    public Order()
    {
        Attributes = new Dictionary<Keys, string>();
    }

    public void AddAttribute(Keys key, string att)
    {
        Attributes.Add(key, att);
    }

    public Instruction Cmd;
    public TargetType Type;
    public string OwnerId;
    public string TargetId;
    public Dictionary<Keys, string> Attributes;
}
