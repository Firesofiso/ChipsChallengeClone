using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour {

    public Text lives;
    public Text time;

    public Image collected;
    public Image yellowKey, redKey, greenKey, blueKey;

    public Transform itemHolder;

    private GameManager gm;
    private Player p;
    private int itemIconSpacing = 0;

	// Use this for initialization
	void Start () {
        p = GameObject.Find("Player").GetComponent<Player>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        lives.text = "" + gm.playerLives;
        collected.fillAmount = p.curPower / p.maxPower;
        time.text = gm.gameTime.GetTime();
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
