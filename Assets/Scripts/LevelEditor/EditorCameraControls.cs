using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class EditorCameraControls : MonoBehaviour {

    public float zoomInc = 0.1f;
    public float zoomMax, zoomMin;
    public float panSpeed;

    private Camera c;

	// Use this for initialization
	void Start () {
        c = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

        // equalizes the zoom so farther out zooms faster than zooming in closer.
        zoomInc = c.orthographicSize / zoomMax * 2;

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            c.orthographicSize = Mathf.Max(c.orthographicSize - zoomInc, zoomMin);
        } else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            c.orthographicSize = Mathf.Min(c.orthographicSize + zoomInc, zoomMax);
        }

        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(xMove, yMove);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + (moveDir * panSpeed), Time.deltaTime * 2);
        
	}
}
