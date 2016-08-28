using UnityEngine;
using System.Collections;

public class WorldAttraction : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay(Collision other)
    {
        if (other.transform.root != transform)
        {
            other.transform.root.SetParent(transform.root);
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.transform.root != transform)
        {

        }
        //other.transform.root.SetParent(null);
    }
}
