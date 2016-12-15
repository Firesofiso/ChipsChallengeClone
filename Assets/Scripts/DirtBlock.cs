using UnityEngine;
using System.Collections;

public class DirtBlock : MonoBehaviour {

    public Sprite mud;
    private GridMap grid;

    // Use this for initialization
    void Start () {

        grid = GameObject.Find("GridManager").GetComponent<GridMap>();
    }
	
	// Update is called once per frame
	void Update () {

        if (grid.GetTileAt(transform.position).type == Tile.TileType.Water)
        {
            grid.GetTileAt(transform.position).type = Tile.TileType.Mud;
            grid.GetTileAt(transform.position).isWalkable = true;
            grid.GetTileAt(transform.position).gameObject.GetComponent<SpriteRenderer>().sprite = mud;
            gameObject.SetActive(false);
        }
    }
}
