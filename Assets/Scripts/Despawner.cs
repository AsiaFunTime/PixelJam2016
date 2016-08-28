using UnityEngine;
using System.Collections;

public class Despawner : MonoBehaviour
{
    public float despawnInSeconds;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(InitiateDespawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator InitiateDespawn()
    {

        yield return new WaitForSeconds(4f);
        Despawn();
    }
    void Despawn()
    {
        Destroy(gameObject);
    }
}
