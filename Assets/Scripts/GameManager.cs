using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Timer))]
public class GameManager : MonoBehaviour {

    public Timer gameTime;
    public GameObject gameOverScreen;
    public Transform ui;

    public int playerLives;

    public static GameManager gMinstance;

    void Awake()
    {
        if (gMinstance == null)
        {
            DontDestroyOnLoad(gameObject);
            gMinstance = this;

        }
        else if (gMinstance != this)
        {
            Destroy(gameObject);

        }
        ui = GameObject.Find("UI").GetComponent<Transform>();
        gameOverScreen = ui.transform.Find("GameOverScreen").gameObject;
    }


    // Use this for initialization
    void Start () {

        ui = GameObject.Find("UI").GetComponent<Transform>();
        gameOverScreen = ui.transform.Find("GameOverScreen").gameObject;

        gameTime = GetComponent<Timer>();
        gameTime.SetIsCountDown(false);
        gameTime.StartTimer();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
