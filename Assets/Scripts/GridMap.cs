using UnityEngine;
using System.Collections;

public class GridMap : MonoBehaviour {

    public int width, height;
    private Vector3[][] gridPositions;
    private Tile[][] tiles;

	// Use this for initialization
	void Start () {
        SetupGrid(width, height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Vector3 GetGridPos(int x, int y)
    {
        return gridPositions[y][x];
    }

    //Set up the grid and positions of each space
    public void SetupGrid(int x, int y)
    {
        gridPositions = new Vector3[y][];
        for(int i = 0;  i < y; i++)
        {
            gridPositions[i] = new Vector3[x];
        }

        float xPos = -x / 2;
        float yPos = -y / 2;

        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                gridPositions[i][j] = new Vector3(xPos, yPos, 0);

                xPos++;
                if (x % 2 == 0)
                {
                    if (xPos == (x / 2))
                    {
                        yPos++;
                        xPos = -x / 2;
                    }
                }
                else
                {
                    if (xPos == (x / 2) + 1)
                    {
                        yPos++;
                        xPos = -x / 2;
                    }
                }
            }
        }
    }

    public void FindTiles()
    {
        tiles = new Tile[height][];
        for (int i = 0; i < height; i++)
        {
            tiles[i] = new Tile[width];
        }

        for(int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {

            }
        }
    }

    void OnDrawGizmos()
    {
        SetupGrid(width, height);
        Gizmos.color = Color.black;
        for (int i = 0; i < gridPositions.Length; i++)
        {
            for (int j = 0; j < gridPositions[i].Length; j++)
            {
                Gizmos.DrawWireCube(gridPositions[i][j], Vector3.one);
            }
        }
    }
}
