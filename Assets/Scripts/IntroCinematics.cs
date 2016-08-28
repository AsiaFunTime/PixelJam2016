using UnityEngine;
using System.Collections;

public class IntroCinematics : MonoBehaviour {
    public MovieTexture myMovie;
	// Use this for initialization
	void Start () {

        myMovie.Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), myMovie);
    }
}
