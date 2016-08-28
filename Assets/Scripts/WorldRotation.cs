using UnityEngine;
using System.Collections;

public class WorldRotation : MonoBehaviour {

    public Vector3 currentRotation;
    public float rotationChangeInterval;
    public float rotateSpeed;
	// Use this for initialization
	void Start () {
        ChangeRotation();
        StartCoroutine(InitiateSpinning());
    }
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(currentRotation * Time.deltaTime * rotateSpeed);
    }

    IEnumerator InitiateSpinning()
    {
        while (true)
        {
            yield return new WaitForSeconds(rotationChangeInterval);
            ChangeRotation();
            rotateSpeed += 0.2f;
        }

    }

    void ChangeRotation()
    {
        currentRotation = new Vector3(Random.value, Random.value, Random.value);
        Debug.Log("rotation changed");
    }
}
