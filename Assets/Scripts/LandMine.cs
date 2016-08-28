using UnityEngine;
using System.Collections;

public class LandMine : MonoBehaviour {

    public SoundManager sounds;

    public GameObject explosionEffect;

    public float explosionForce;
    public float explosionRadius;
    public float explosionLift;

    // Use this for initialization
    void Start()
    {
        sounds = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        // explode!
        if (other.gameObject.tag == "Player")
        {
            sounds.PlayCannonExplode();
            GameObject.Instantiate(explosionEffect, other.contacts[0].point, Quaternion.identity);


            Vector3 explosionPos = other.contacts[0].point;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                Debug.Log("HIT BY EXPLOSION");
                if (rb != null)
                    rb.AddExplosionForce(explosionForce, explosionPos, explosionRadius, explosionLift);

            }

            Destroy(gameObject);
        }
    }
}
