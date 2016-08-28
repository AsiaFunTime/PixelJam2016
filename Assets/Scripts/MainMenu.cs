using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    private bool inCredits = false;

    public GameObject credits;
    public GameObject main;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Start"))
        {
            int level = Random.RandomRange(1, 6);
            SceneManager.LoadScene(level);
            Time.timeScale = 1;
        }
        else if (Input.GetButtonDown("Credits"))
        {
            inCredits = true;
            credits.SetActive(true);
            main.SetActive(false);
        }
        else if (Input.GetButtonDown("Quit"))
        {
            if (inCredits)
            {
                inCredits = false;
                credits.SetActive(false);
                main.SetActive(true);
            }
            else
            {
                Application.Quit();
                // quit
            }
        }
	}
}
