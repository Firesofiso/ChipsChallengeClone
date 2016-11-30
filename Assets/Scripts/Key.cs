using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

    public enum Type
    {
        Yellow,
        Red,
        Green,
        Blue
    }

    public Type t;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!other.GetComponent<Player>().HasKey(t))
            {
                other.GetComponent<Player>().keys.Add(this);
                gameObject.SetActive(false);
            }
        }
    }
}
