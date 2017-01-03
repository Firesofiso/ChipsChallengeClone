using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour {

    public Text lives;
    public Text time;

    public Image collected;
    public Image yellowKey, redKey, greenKey, blueKey;

    public Transform itemHolder;

    public Player p; // Player for the level
    public Timer t; // Timer for the level
    public GameObject gameOverScreen;

    private int itemIconSpacing = 0;
    private GameManager gm;

	// Use this for initialization
	void Start () {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        lives.text = "" + gm.playerLives;
        collected.fillAmount = p.curPower / (float)p.maxPower;
        time.text = t.GetTime();
        yellowKey.gameObject.SetActive(p.HasKey(Key.Type.Yellow));
        redKey.gameObject.SetActive(p.HasKey(Key.Type.Red));
        greenKey.gameObject.SetActive(p.HasKey(Key.Type.Green));
        blueKey.gameObject.SetActive(p.HasKey(Key.Type.Blue));
    }

    public void InstantiateIcon(GameObject icon)
    {
        Instantiate(icon, itemHolder.position + new Vector3(-itemIconSpacing, 0, 0), Quaternion.identity, itemHolder);
        itemIconSpacing += 95;
    }
}
