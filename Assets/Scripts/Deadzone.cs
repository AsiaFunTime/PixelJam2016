using UnityEngine;
using System.Collections;

public class Deadzone : MonoBehaviour {
    public GameManager manager;
	// Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerModelManager p = other.gameObject.GetComponent<PlayerModelManager>();
            if (p)
            {
                manager.KillPlayer(p.player);
            }
        }
        else
            Destroy(other.gameObject);
    }
}
