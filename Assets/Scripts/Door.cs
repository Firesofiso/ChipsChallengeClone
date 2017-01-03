using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public Sprite open_S, closed_S;
    public Color open, closed;

    public bool requireKey;
    public Key.Type keyType;

    private bool isOpen;
    private SpriteRenderer sRend;
    private Tile t;
    private Player p;

	// Use this for initialization
	void Start () {
        sRend = GetComponent<SpriteRenderer>();
        t = GetComponent<Tile>();
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        isOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (p.HasKey(keyType) && !isOpen) {
            p.RemoveKey(keyType); 
            OpenClose();
        }
    }

    public void OpenClose()
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            if (open_S)
            {
                sRend.sprite = open_S;
            }
            else
            {
                sRend.color = open;
            }
            t.isWalkable = true;
            t.type = Tile.TileType.Ground;
        } else
        {
            if (closed_S)
            {
                sRend.sprite = closed_S;
            }
            else
            {
                sRend.color = closed;
            }
            t.isWalkable = false;
            t.type = Tile.TileType.Door;
        }
    }


}
