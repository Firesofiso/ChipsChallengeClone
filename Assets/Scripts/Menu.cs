using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {

    public Button startHook;

    void OnEnable()
    {
        Debug.Log("OnEnable");
        startHook.Select();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeLevel(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
