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
    }
	
	// Update is called once per frame
	void Update () {
	    if (dest != transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, grid.GetGridPos(dest), Time.deltaTime * 3);
        }
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Get the direction the player is coming from.
            Vector3 playerDir = (transform.position - other.transform.position) / (transform.position - other.transform.position).magnitude;
            pushDir = playerDir;
            dest = transform.position + pushDir;      
        }
    }
}
