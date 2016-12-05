using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    public enum TileType
    {
        Wall,
        Ground,
        Door,
        Water,
        Fire,
        Oil,
        Ice
    }

    public bool isWalkable;
    public TileType type;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
