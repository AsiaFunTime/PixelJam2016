using UnityEngine;
using System.Collections;

public class SpikyObject : MonoBehaviour {
    public float spikyForce;
    public SoundManager sounds;
    // Use this for initialization
    void Start ()
    {
        sounds = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 dir = other.contacts[0].point - transform.position;
            
            rb.AddForce(dir.normalized * spikyForce, ForceMode.Impulse);
            sounds.PlayHit();
        }
    }
}
