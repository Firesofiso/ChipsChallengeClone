using UnityEngine;
using System.Collections;

public class Pushable : MonoBehaviour {



    private Vector3 pushDir;
    private Vector3 dest;
    private GridMap grid;

	// Use this for initialization
	void Start () {

        grid = GameObject.Find("GridManager").GetComponent<GridMap>();
        dest = transform.position;
        
        grid.GetTileAt(transform.position).isWalkable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dest != transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, grid.GetGridPos(dest), Time.deltaTime * 3);
        }
    }

    public void Push(Transform pusher)
    {
        
        //Get the direction the player is coming from.
        Vector3 playerDir = (transform.position - pusher.transform.position) / (transform.position - pusher.transform.position).magnitude;
        pushDir = playerDir;
        dest = transform.position + pushDir;
        if (grid.GetTileAt(dest).type == Tile.TileType.Wall)
        {
            dest = transform.position;
        }
        else
        {
            //Make the current tile walkable again.
            grid.GetTileAt(transform.position).isWalkable = true;

            //Then make the dest tile unwalkable.
            grid.GetTileAt(dest).isWalkable = false;
        }
        
    }
}
