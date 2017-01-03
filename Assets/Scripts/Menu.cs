using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    private GameManager gm;

	void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void ChangeScene(int i)
    {
        gm.ChangeScene(i);
    }

    public void ReturnToTitle()
    {
        gm.ReturnToTitle();
    }

    public void StartOver()
    {
        gm.StartOver();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        gm.ReloadScene();
    }
}
