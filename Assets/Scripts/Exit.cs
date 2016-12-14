using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Exit : MonoBehaviour {

    private Animator anim;
    private Player p;

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        p = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {

        if (p.curPower == p.maxPower)
        {
            anim.SetBool("isActive", true);
        }
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && anim.GetBool("isActive"))
        {
            //Load Next Level
            if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
