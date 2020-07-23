using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public string name;
    public GameObject modelPrefab;
    public GameObject model;
    public int X;
    public int Z;
    public int rotation;
    public List<GameObject> doors;
    public Sprite tile;
}
