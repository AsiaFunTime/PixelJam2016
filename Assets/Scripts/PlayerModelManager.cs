using UnityEngine;
using System.Collections;

public enum Player { P1 = 0, P2 = 1, P3 = 2, P4 = 3 }
public class PlayerModelManager : MonoBehaviour {
    public Player player;
    public GameObject[] models;
    private WeebleBottom bottom;
	// Use this for initialization
	void Start () {
        bottom = GetComponentInChildren<WeebleBottom>();

        GameObject model = GameObject.Instantiate(models[(int)player]);
        model.transform.SetParent(bottom.transform);
        model.transform.localPosition = Vector3.zero;
        model.transform.localRotation = Quaternion.identity;
        model.transform.localScale = Vector3.one;
        model.tag = "PlayerModel";
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
