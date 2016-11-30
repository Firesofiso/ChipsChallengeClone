using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour {

    public Text lives, collected;
    public Text time;
    public Image yellowKey, redKey, greenKey, blueKey;

    private GameManager gm;
    private Player p;

	// Use this for initialization
	void Start () {
        p = GameObject.Find("Player").GetComponent<Player>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        lives.text = "" + gm.playerLives;
        collected.text = "" + p.collected;
        time.text = gm.gameTime.GetTime();
        yellowKey.gameObject.SetActive(p.HasKey(Key.Type.Yellow));
        redKey.gameObject.SetActive(p.HasKey(Key.Type.Red));
        greenKey.gameObject.SetActive(p.HasKey(Key.Type.Green));
        blueKey.gameObject.SetActive(p.HasKey(Key.Type.Blue));
    }
}
