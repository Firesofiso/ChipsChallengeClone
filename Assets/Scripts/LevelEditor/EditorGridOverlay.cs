using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EditorGridOverlay : MonoBehaviour {

    public int height, width;

    public GameObject gridImage;

	// Use this for initialization
	void Start () {
        Debug.Log("Started!");
        DrawGrid();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void DrawGrid()
    {
        Debug.Log("Shoop Da Woop Grid Drawn!");
        
        //Loop for instantiating the grid square by square.
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Instantiate(gridImage, new Vector3(j * 1.02f, i * 1.02f), Quaternion.identity, transform);
            }
        }
    }
}
