using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


    public int x, y; //X and Y Positions on the Grid;
    public float speed;
    public bool canMove = true;

    private GridMap grid;
    public Vector3 pos;

	// Use this for initialization
	void Start () {
        grid = GameObject.Find("GridManager").GetComponent<GridMap>();
        x = (int)transform.position.x + grid.width / 2 + 1;
        y = (int)transform.position.y + grid.height / 2 + 1;
        canMove = true;
        pos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Right") && transform.position == pos && x < grid.width)
        {
            pos += Vector3.right;
            x++;
        }
        else if (Input.GetButton("Left") && transform.position == pos && x > 1)
        {
            pos += Vector3.left;
            x--;
        }
        else if (Input.GetButton("Up") && transform.position == pos && y < grid.height)
        {
            pos += Vector3.up;
            y++;
        }
        else if (Input.GetButton("Down") && transform.position == pos && y > 1)
        {
            pos += Vector3.down;
            y--;
        }
        transform.position = Vector3.MoveTowards(transform.position, grid.GetGridPos(x - 1, y - 1), Time.deltaTime * speed);

    }
}
