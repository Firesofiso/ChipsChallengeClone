using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int playerLives;

    public static GameManager gMinstance;

    public UI ui_GM;
    public Player player_GM;
    public Timer timer_GM;


    AsyncOperation asyncLoadLevel;

    public IEnumerator LoadLevel(int sceneIndex)
    {
        asyncLoadLevel = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
        while (!asyncLoadLevel.isDone)
        {
            print("Loading the Scene");
            yield return null;
        }
        FindObjects();
    }

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
    }


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

    void FindObjects()
    {
        if (GameObject.Find("UI") != null && GameObject.Find("UI").GetComponent<UI>() != null)
        {
            ui_GM = GameObject.Find("UI").GetComponent<UI>();
        }
        if (GameObject.Find("Player") != null && GameObject.Find("Player").GetComponent<Player>() != null)
        {
            player_GM = GameObject.Find("Player").GetComponent<Player>();
        }
        if (GameObject.Find("Timer") != null && GameObject.Find("Timer").GetComponent<Timer>() != null)
        {
            timer_GM = GameObject.Find("Timer").GetComponent<Timer>();
        }
    }

    public void ChangeScene(int i)
    {
        StartCoroutine(LoadLevel(i));
    }

    public void ReturnToTitle()
    {
        playerLives = 5;
        SceneManager.LoadScene(0);
    }

    public void StartOver()
    {
        playerLives = 5;
        StartCoroutine(LoadLevel(1));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void GameOver()
    {
        timer_GM.StopTimer();
        ui_GM.gameOverScreen.SetActive(true);

    }

}
