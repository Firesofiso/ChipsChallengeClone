using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour {


    [SerializeField]
    private int x, y; //X and Y Positions on the Grid;
    private GridMap grid;
    private Vector3 pos;
    private Vector3 slideDir;

    private Player player;

    public Sprite mudChangeTile;

    // Use this for initialization
    void Start () {
        player = GetComponent<Player>();
        grid = GameObject.Find("GridManager").GetComponent<GridMap>();
        x = (int)transform.position.x + grid.width / 2 + 1;
        y = (int)transform.position.y + grid.height / 2 + 1;
        pos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        //Sliding check
        if (!player.sliding)
        {

            //Check for input, player in position and the desired tile is not out of bounds.
            if (Input.GetButton("Right") && transform.position == pos && x < grid.width && grid.GetTileAt(x, y - 1))
            {

                if (Physics2D.Raycast(transform.position, Vector3.right, 1) && Physics2D.Raycast(transform.position, Vector3.right, 1).transform.GetComponent<Pushable>())
                {
                    Pushable tempBlock = Physics2D.Raycast(transform.position, Vector3.right, 1).transform.GetComponent<Pushable>();
                    tempBlock.Push(transform);
                }

                //This if takes care of all the checks and special cases. --This is the same for all directions, the only difference is the x and y pos
                // The next block needs to be walkable.
                // If the next block is a door, the player must have the respective key to walk there
                // If the next block is water, unless the player has the snorkel they cannot walk there.
                if (grid.GetTileAt(x, y - 1).isWalkable ||
                    grid.GetTileAt(x, y - 1).type == Tile.TileType.Door && player.HasKey(grid.GetTileAt(x, y - 1).GetComponent<Door>().keyType) ||
                    grid.GetTileAt(x, y - 1).type == Tile.TileType.Water && player.HasItem(Item.Type.Snorkel) == true)
                {



                    // Add a right direction to the position and increment x by 1 so when we move it picks the block to the right.
                    pos += Vector3.right;
                    x++;

                    // Here is the stuff for Ice / Sliding physics.
                    // This will basically just lock the player in a direction until they hit something that isn't ice.
                    if (grid.GetTileAt(x, y - 1).type == Tile.TileType.Ice && player.HasItem(Item.Type.SpikeBoots) == false)
                    {

                        // Fix direction and begin sliding
                        slideDir = Vector3.right;
                        player.sliding = true;
                    }
                }
            }
            else if (Input.GetButton("Left") && transform.position == pos && x > 1 && grid.GetTileAt(x - 2, y - 1))
            {

                if (Physics2D.Raycast(transform.position, Vector3.left, 1) && Physics2D.Raycast(transform.position, Vector3.left, 1).transform.GetComponent<Pushable>())
                {
                    Pushable tempBlock = Physics2D.Raycast(transform.position, Vector3.left, 1).transform.GetComponent<Pushable>();
                    tempBlock.Push(transform);
                }
                if (grid.GetTileAt(x - 2, y - 1).isWalkable ||
                    grid.GetTileAt(x - 2, y - 1).type == Tile.TileType.Door && player.HasKey(grid.GetTileAt(x - 2, y - 1).GetComponent<Door>().keyType) ||
                    grid.GetTileAt(x - 2, y - 1).type == Tile.TileType.Water && player.HasItem(Item.Type.Snorkel) == true)
                {

                    pos += Vector3.left;
                    x--;
                    if (grid.GetTileAt(x - 2, y - 1).type == Tile.TileType.Ice && player.HasItem(Item.Type.SpikeBoots) == false)
                    {
                        slideDir = Vector3.left;
                        player.sliding = true;
                    }
                }
            }
            else if (Input.GetButton("Up") && transform.position == pos && y < grid.height && grid.GetTileAt(x - 1, y))
            {

                if (Physics2D.Raycast(transform.position, Vector3.up, 1) && Physics2D.Raycast(transform.position, Vector3.up, 1).transform.GetComponent<Pushable>())
                {
                    Pushable tempBlock = Physics2D.Raycast(transform.position, Vector3.up, 1).transform.GetComponent<Pushable>();
                    tempBlock.Push(transform);
                }
                if (grid.GetTileAt(x - 1, y).isWalkable ||
                    grid.GetTileAt(x - 1, y).type == Tile.TileType.Door && player.HasKey(grid.GetTileAt(x - 1, y).GetComponent<Door>().keyType) ||
                    grid.GetTileAt(x - 1, y).type == Tile.TileType.Water && player.HasItem(Item.Type.Snorkel) == true)
                {
                    pos += Vector3.up;
                    y++;
                    if (grid.GetTileAt(x - 1, y).type == Tile.TileType.Ice && player.HasItem(Item.Type.SpikeBoots) == false)
                    {
                        slideDir = Vector3.up;
                        player.sliding = true;
                    }
                }
            }
            else if (Input.GetButton("Down") && transform.position == pos && y > 1 && grid.GetTileAt(x - 1, y - 2))
            {

                if (Physics2D.Raycast(transform.position, Vector3.down, 1) && Physics2D.Raycast(transform.position, Vector3.down, 1).transform.GetComponent<Pushable>())
                {
                    Pushable tempBlock = Physics2D.Raycast(transform.position, Vector3.down, 1).transform.GetComponent<Pushable>();
                    tempBlock.Push(transform);
                }
                if (grid.GetTileAt(x - 1, y - 2).isWalkable ||
                    grid.GetTileAt(x - 1, y - 2).type == Tile.TileType.Door && player.HasKey(grid.GetTileAt(x - 1, y - 2).GetComponent<Door>().keyType) ||
                    grid.GetTileAt(x - 1, y - 2).type == Tile.TileType.Water && player.HasItem(Item.Type.Snorkel) == true)
                {

                    pos += Vector3.down;
                    y--;
                    if (grid.GetTileAt(x - 1, y - 2).type == Tile.TileType.Ice && player.HasItem(Item.Type.SpikeBoots) == false)
                    {
                        slideDir = Vector3.down;
                        player.sliding = true;
                    }
                }
            }

            // Move to the desired spot on the grid.
            transform.position = Vector3.MoveTowards(transform.position, grid.GetGridPos(x - 1, y - 1), Time.deltaTime * player.speed);
        }
        else
        {
            // Only increment when the player is at the position.
            if (pos == transform.position)
            {
                x += (int)slideDir.x;
                y += (int)slideDir.y;
                pos += slideDir;
            }

            // MOVE! er SLIDE!
            transform.position = Vector3.MoveTowards(transform.position, grid.GetGridPos(x - 1, y - 1), Time.deltaTime * player.speed);

            // Stop sliding if the next tile is walkable and NOT ice
            // Also need to check two spaces away so that we don't clip into walls.
            if (grid.GetTileAt(x - 1, y - 1).isWalkable && grid.GetTileAt(x - 1, y - 1).type != Tile.TileType.Ice ||
                grid.GetTileAt(x + (int)slideDir.x - 1, y + (int)slideDir.y - 1).type == Tile.TileType.Wall)
            {
                player.sliding = false;
            }
        }
        if (grid.GetTileAt(transform.position).type == Tile.TileType.Mud)
        {
            grid.GetTileAt(transform.position).GetComponent<SpriteRenderer>().sprite = mudChangeTile;
            grid.GetTileAt(transform.position).type = Tile.TileType.Ground;
        }
    }
}
