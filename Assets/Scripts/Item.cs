using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public enum Type
    {
        Snorkel,
        SpikeBoots,
        HeatArmor
    }

    public Type type;

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
            if (!other.GetComponent<Player>().HasItem(type))
            {
                other.GetComponent<Player>().items.Add(this);
            }
            gameObject.SetActive(false);
        }
    }
}
