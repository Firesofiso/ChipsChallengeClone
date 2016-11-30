using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

    public Color on, off;
    public Door doorObject;

    private bool value = false;
    private SpriteRenderer sRend;
    private GridMap tileMap;

	// Use this for initialization
	void Start () {
        sRend = GetComponent<SpriteRenderer>();
        tileMap = GameObject.Find("GridManager").GetComponent<GridMap>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TRIGGERED!");
        value = !value;
        if (value)
        {
            sRend.color = on;
        } else
        {
            sRend.color = off;
        }
        ApplyEffect();
    }

    public void ApplyEffect()
    {
        doorObject.OpenClose();
    }
}
