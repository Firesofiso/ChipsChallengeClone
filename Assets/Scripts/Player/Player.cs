using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;

public class Player : MonoBehaviour {


    public int curPower, maxPower;
    public float speed;
    public bool swimming = false;
    public bool sliding = false;

    public Timer pTimer;

    public List<Key> keys;
    public List<Item> items;

    private GameManager gm; // Kind of thinking that most if not all game objects need a connection to the Gamemanager of some sort.

    // Use this for initialization
    void Start () {

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        keys = new List<Key>();
        items = new List<Item>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    public bool HasKey(Key.Type keyType)
    {
        for (int i = 0; i < keys.Count; i++)
        {
            if (keys[i].t == keyType)
            {
                return true;
            }
        }
        return false;
    }

    public void RemoveKey(Key.Type keyType)
    {
        for (int i = 0; i < keys.Count; i++)
        {
            if (keys[i].t == keyType)
            {
                keys.RemoveAt(i);
            }
        }
    }

    public bool HasItem(Item.Type itemType)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].type == itemType)
            {
                return true;
            }
        }
        return false;
    }

    public void RemoveItem(Item.Type itemType)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].type == itemType)
            {
                items.RemoveAt(i);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Fire" && !HasItem(Item.Type.HeatSuit))
        {
            if (gm.playerLives > 0)
            {
                gm.playerLives--;
                pTimer.Reset();
                gm.ReloadScene();
            } else {
                gm.GameOver();
            }
            
        }
    }
}
