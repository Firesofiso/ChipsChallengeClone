using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;

public class Player : MonoBehaviour {


    public int collected;
    public float speed;
    public bool canMove = true;
    public bool swimming = false;

    public List<Key> keys;
    public List<Item> items;

    [SerializeField]
    private int x, y; //X and Y Positions on the Grid;
    private GridMap grid;
    private Vector3 pos;

	// Use this for initialization
	void Start () {
        grid = GameObject.Find("GridManager").GetComponent<GridMap>();
        x = (int)transform.position.x + grid.width / 2 + 1;
        y = (int)transform.position.y + grid.height / 2 + 1;
        canMove = true;
        pos = transform.position;
        keys = new List<Key>();
        items = new List<Item>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Right") && transform.position == pos && x < grid.width && grid.GetTileAt(x, y - 1))
        {
            //Debug.Log("Tile: " + grid.GetTileAt(x, y - 1) + " walkable? " + grid.GetTileAt(x, y - 1).isWalkable);

            if (grid.GetTileAt(x, y - 1).isWalkable || 
                grid.GetTileAt(x, y - 1).type == Tile.TileType.Door && HasKey(grid.GetTileAt(x, y - 1).GetComponent<Door>().keyType) ||
                grid.GetTileAt(x, y - 1).type == Tile.TileType.Water && HasItem(Item.Type.Snorkel) == true)
            {
                pos += Vector3.right;
                x++;
            }
        }
        else if (Input.GetButton("Left") && transform.position == pos && x > 1 && grid.GetTileAt(x - 2, y - 1))
        {
            if (grid.GetTileAt(x - 2, y - 1).isWalkable || 
                grid.GetTileAt(x - 2, y - 1).type == Tile.TileType.Door && HasKey(grid.GetTileAt(x - 2, y - 1).GetComponent<Door>().keyType) ||
                grid.GetTileAt(x - 2, y - 1).type == Tile.TileType.Water && HasItem(Item.Type.Snorkel) == true)
            {
                pos += Vector3.left;
                x--;
            }
        }
        else if (Input.GetButton("Up") && transform.position == pos && y < grid.height && grid.GetTileAt(x - 1, y))
        {
            if (grid.GetTileAt(x - 1, y).isWalkable || 
                grid.GetTileAt(x - 1, y).type == Tile.TileType.Door && HasKey(grid.GetTileAt(x - 1, y).GetComponent<Door>().keyType) ||
                grid.GetTileAt(x - 1, y).type == Tile.TileType.Water && HasItem(Item.Type.Snorkel) == true)
            {
                pos += Vector3.up;
                y++;
            }
        }
        else if (Input.GetButton("Down") && transform.position == pos && y > 1 && grid.GetTileAt(x - 1, y - 2))
        {
            if (grid.GetTileAt(x - 1, y - 2).isWalkable || 
                grid.GetTileAt(x - 1, y - 2).type == Tile.TileType.Door && HasKey(grid.GetTileAt(x - 1, y - 2).GetComponent<Door>().keyType) ||
                grid.GetTileAt(x - 1, y - 2).type == Tile.TileType.Water && HasItem(Item.Type.Snorkel) == true)
            {
                pos += Vector3.down;
                y--;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, grid.GetGridPos(x - 1, y - 1), Time.deltaTime * speed);

    }

    public bool HasKey(Key.Type keyType)
    {
        for (int i = 0; i < keys.Count; i++)
        {
            if (keys[i].t == keyType)
            {
                return true;
            }
        }
        return false;
    }

    public void RemoveKey(Key.Type keyType)
    {
        for (int i = 0; i < keys.Count; i++)
        {
            if (keys[i].t == keyType)
            {
                keys.RemoveAt(i);
            }
        }
    }

    public bool HasItem(Item.Type itemType)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].type == itemType)
            {
                return true;
            }
        }
        return false;
    }

    public void RemoveItem(Item.Type itemType)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].type == itemType)
            {
                items.RemoveAt(i);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        GameManager temp = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (other.tag == "Enemy")
        {
            if (temp.playerLives > 0)
            {
                temp.playerLives--;
                temp.gameTime.Reset();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            } else {
                temp.GameOver();
            }
            
        }
    }
}
