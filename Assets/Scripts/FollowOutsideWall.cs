using UnityEngine;
using System.Collections;

public class FollowOutsideWall : MonoBehaviour {

    public bool moveLeft;
    public float speed;

    private int x, y;
    private GridMap grid;
    private Vector3 pos;
    private Vector3 facing = Vector3.down;

    // Use this for initialization
    void Start () {
        grid = GameObject.Find("GridManager").GetComponent<GridMap>();
        x = (int)transform.position.x + grid.width / 2;
        y = (int)transform.position.y + grid.height / 2;
        pos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (moveLeft)
        {
            if (facing == Vector3.down && transform.position == pos)
            {
                if (x < grid.width - 1 && grid.GetTileAt(x + 1, y) && grid.GetTileAt(x + 1, y).isWalkable && y < grid.height - 1 && (!grid.GetTileAt(x + 1, y + 1) || !grid.GetTileAt(x + 1, y + 1).isWalkable))
                {
                    //move right if up is no longer possible
                    x++;
                    pos += Vector3.right;
                    facing = Vector3.right;
                }
                else if (y > 0 && grid.GetTileAt(x, y - 1) && grid.GetTileAt(x, y - 1).isWalkable)
                {
                    //Move down if possible.
                    y--;
                    pos += Vector3.down;
                }
                else
                {
                    facing = Vector3.left;
                }
            }
            else if (facing == Vector3.left && transform.position == pos)
            {
                if (y > 0 && grid.GetTileAt(x, y - 1) && grid.GetTileAt(x, y - 1).isWalkable)
                {
                    //Move down if possible.
                    y--;
                    pos += Vector3.down;
                    facing = Vector3.down;
                }
                else if(x > 0 && grid.GetTileAt(x - 1, y) && grid.GetTileAt(x - 1, y).isWalkable)
                {
                    //Move left if down isn't possible.
                    x--;
                    pos += Vector3.left;
                }
                else
                {
                    facing = Vector3.up;
                }
            }
            else if (facing == Vector3.up && transform.position == pos)
            {
                if (x > 0 && grid.GetTileAt(x - 1, y) && grid.GetTileAt(x - 1, y).isWalkable)
                {
                    x--;
                    pos += Vector3.left;
                    facing = Vector3.left;
                } else if (y < grid.height - 1 && grid.GetTileAt(x, y + 1) && grid.GetTileAt(x, y + 1).isWalkable)
                {
                    //move up if left is no longer possible
                    y++;
                    pos += Vector3.up;
                }
                else
                {
                    facing = Vector3.right;
                }
            }
            else if (facing == Vector3.right && transform.position == pos)
            {
                if (y < grid.height - 1 && grid.GetTileAt(x, y + 1) && grid.GetTileAt(x, y + 1).isWalkable)
                {
                    //move up if left is no longer possible
                    y++;
                    pos += Vector3.up;
                    facing = Vector3.up;
                }
                else if (x < grid.width - 1 && grid.GetTileAt(x + 1, y) && grid.GetTileAt(x + 1, y).isWalkable)
                {
                    //move right if up is no longer possible
                    x++;
                    pos += Vector3.right;
                }
                else
                {
                    facing = Vector3.down;
                }
            }
        } else
        {
            // Move down whenever you can.
            if (facing == Vector3.down && transform.position == pos)
            {
                //This is a special case of a convex corner
                //Tile to the left is open and the one diagonally upleft is a wall/not there.
                if (x > 0 && grid.GetTileAt(x - 1, y) && grid.GetTileAt(x - 1, y).isWalkable && y < grid.height - 1 && (!grid.GetTileAt(x - 1, y + 1) || !grid.GetTileAt(x - 1, y + 1).isWalkable))
                {
                    x--;
                    pos += Vector3.left;
                    facing = Vector3.left;
                }
                else if (y > 0 && grid.GetTileAt(x, y - 1) && grid.GetTileAt(x, y - 1).isWalkable)
                {
                    //Move down if possible.
                    y--;
                    pos += Vector3.down;
                }
                else
                {
                    facing = Vector3.right;
                }
            }

            // If moving down is no longer possible move right
            else if (facing == Vector3.right && transform.position == pos)
            {
                //If moving down becomes possible again revert back
                if (y > 0 && grid.GetTileAt(x, y - 1) && grid.GetTileAt(x, y - 1).isWalkable)
                {
                    y--;
                    pos += Vector3.down;
                    facing = Vector3.down;
                }
                else if (x < grid.width - 1 && grid.GetTileAt(x + 1, y) && grid.GetTileAt(x + 1, y).isWalkable)
                {
                    //move right
                    x++;
                    pos += Vector3.right;
                }
                else
                {
                    //Moving right no longer possible, switch to up.
                    facing = Vector3.up;
                }
            }

            // If moving right is no longer possible move up
            else if (facing == Vector3.up && transform.position == pos)
            {
                if (x < grid.width - 1 && grid.GetTileAt(x + 1, y) && grid.GetTileAt(x + 1, y).isWalkable)
                {
                    //move right if up is no longer possible
                    x++;
                    pos += Vector3.right;
                    facing = Vector3.right;
                }
                else if (y < grid.height - 1 && grid.GetTileAt(x, y + 1) && grid.GetTileAt(x, y + 1).isWalkable)
                {
                    //move up if left is no longer possible
                    y++;
                    pos += Vector3.up;
                }
                else
                {
                    facing = Vector3.left;
                }
            }

            // If moving up is no longer possible move left
            else if (facing == Vector3.left && transform.position == pos)
            {
                if (y < grid.height - 1 && grid.GetTileAt(x, y + 1) && grid.GetTileAt(x, y + 1).isWalkable)
                {
                    //move up if left is no longer possible
                    y++;
                    pos += Vector3.up;
                    facing = Vector3.up;
                }
                else if (x > 0 && grid.GetTileAt(x - 1, y) && grid.GetTileAt(x - 1, y).isWalkable)
                {
                    //Move left if down isn't possible.
                    x--;
                    pos += Vector3.left;
                }
                else
                {
                    facing = Vector3.down;
                }
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, grid.GetGridPos(x, y), Time.deltaTime * speed);

    }
}
