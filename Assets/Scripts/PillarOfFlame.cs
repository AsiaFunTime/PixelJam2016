using UnityEngine;
using System.Collections;

public class PillarOfFlame : MonoBehaviour
{
    public float upForce;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            //rb.AddForce(Vector3.up * upForce, ForceMode.Impulse);
            Vector3 dir = transform.position - other.transform.position;
            rb.AddExplosionForce(upForce, other.transform.position, 100);
        }
    }
}
