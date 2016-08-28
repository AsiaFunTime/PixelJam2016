using UnityEngine;
using System.Collections;

public class InfiniteHop : MonoBehaviour {
    public WeebleBottom bottom;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        bottom = GetComponent<WeebleBottom>();
        rb = GetComponent<Rigidbody>();
        StartCoroutine(infiniteHop());
	}
	
    IEnumerator infiniteHop()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f + Random.value);
            if (bottom.IsGrounded())
            {
                rb.AddForce(Vector3.up * 250, ForceMode.Impulse);
            }
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
