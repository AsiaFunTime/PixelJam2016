using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public enum Level {Grass =1, Desert=2, Ice=3, Fire=4, Metal=5, Rock=6}
public class GameManager : MonoBehaviour {
    public Level currentLevel;
    
    public Texture hongDead;
    public Texture zachDead;
    public Texture kenjiDead;
    public Texture baoxiongDead;

    public RawImage hongUI;
    public RawImage baoxiongUI;
    public RawImage kenjiUI;
    public RawImage zachUI;

    public bool isHongDead = false;
    public bool isBaoXiongDead = false;
    public bool isKenjiDead = false;
    public bool isZachDead = false;
    public int playerAliveCount = 4;

    public GameObject hongWin;
    public GameObject baoxiongWin;
    public GameObject kenjiWin;
    public GameObject zachWin;
    public GameObject winText;

    private bool isPaused = false;
    private bool isEnded = false;

    public GameObject menu;

    public AudioClip[] backgroundClips;
    public AudioSource backgroundMusic;
    public SoundManager sounds;
    // Use this for initialization
    void Start () {
        backgroundMusic.clip = backgroundClips[(int)currentLevel];
        backgroundMusic.loop = true;
        backgroundMusic.Play();
        sounds = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        //sounds.PlayWinner();

    }

    // Update is called once per frame
    void Update () {
	    if(playerAliveCount == 1)
        {
            if (!isHongDead)
            {
                hongWin.SetActive(true);
                Destroy(hongUI);
            }
            else if (!isBaoXiongDead)
            {
                baoxiongWin.SetActive(true);
                Destroy(baoxiongUI);

            }
            else if (!isKenjiDead)
            {
                kenjiWin.SetActive(true);
                Destroy(kenjiUI);

            }
            else if (!isZachDead)
            {
                zachWin.SetActive(true);
                Destroy(zachUI);

            }
            isEnded = true;
            // WIN!
        }

        if (Input.GetButtonDown("Pause") && !isEnded)
        {
            if (isPaused)
            {
                isPaused = false;
                Time.timeScale = 1;
                menu.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                menu.SetActive(true);
                isPaused = true;
            }
        }
        if (Input.GetButtonDown("NextLevel") && (isPaused || isEnded))
        {
            NextLevel();
        }

        if (Input.GetButtonDown("Restart") && (isPaused || isEnded))
        {
            Time.timeScale = 1;
            if (isEnded)
            {
                NextLevel();
            }
            else
            {
                Scene loadedLevel = SceneManager.GetActiveScene();
                SceneManager.LoadScene((int)currentLevel);
            }
        }
        if (Input.GetButtonDown("Quit") && (isPaused || isEnded))
        {
            SceneManager.LoadScene("menu");
        }

    }

    void NextLevel()
    {
        int level = 0;
        do
        {
            level = Random.RandomRange(1, 7);
        } while (level == (int)(currentLevel));
        
        SceneManager.LoadScene(level);
        Time.timeScale = 1;
    }

    public void KillPlayer(Player player)
    {
        switch (player)
        {
            case Player.P1:
                hongUI.texture = hongDead;
                isHongDead = true;
                break;
            case Player.P2:
                baoxiongUI.texture = baoxiongDead;
                isBaoXiongDead = true;
                break;
            case Player.P3:
                kenjiUI.texture = kenjiDead;
                isKenjiDead = true;
                break;
            case Player.P4:
                zachUI.texture = zachDead;
                isZachDead = true;
                break;
        }
        playerAliveCount--;
        if(playerAliveCount == 1)
        {
            winText.SetActive(true);
            Time.timeScale = 0;
            menu.SetActive(true);
            sounds.PlayWinner();
        }
    }
}
