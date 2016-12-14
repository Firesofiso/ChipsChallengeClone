using UnityEngine;
using System.Collections;

public class PowerCell : MonoBehaviour {

    public int value;
    private Transform parent;

	// Use this for initialization
	void Start () {
        parent = GetComponentInParent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<Player>().curPower + value <= other.GetComponent<Player>().maxPower)
            {
                other.GetComponent<Player>().curPower += value;
            } else
            {
                other.GetComponent<Player>().curPower = other.GetComponent<Player>().maxPower;
            }
            parent.gameObject.SetActive(false);
        }
    }
}
