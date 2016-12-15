using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

    public GameObject laserObject;
    public Vector3 dir;

    private RaycastHit2D hit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        hit = Physics2D.Raycast(transform.position, dir);
        laserObject.transform.localScale = new Vector3(Vector3.Distance(transform.position, hit.transform.position)*5, laserObject.transform.localScale.y);
        laserObject.transform.localPosition = new Vector3(Vector3.Distance(transform.position, hit.transform.position) * 5 / 2, 0);                                    
    }
}
