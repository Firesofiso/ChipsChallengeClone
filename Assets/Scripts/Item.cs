using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public enum Type
    {
        Snorkel,
        SpikeBoots,
        HeatSuit
    }

    public Type type;
    public GameObject icon;

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
                if (GameObject.Find("UI"))
                {
                    GameObject.Find("UI").GetComponent<UI>().InstantiateIcon(icon);
                }
            }
            gameObject.SetActive(false);
        }
    }
}
