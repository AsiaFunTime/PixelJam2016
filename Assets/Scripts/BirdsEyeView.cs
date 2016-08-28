using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BirdsEyeView : MonoBehaviour
{
    private float dampening = 3f;
    private Camera cam;
    private SmoothFollow smoothFollow;
    private float zoomOutSpeed = 12f;

    private float zoomInSpeed = 10f;
    private float minHeight = 24f;

    private float recalculateFrequency = 0f;

    private float totalTime = 0f;

    public Transform centroid;
    // Use this for initialization
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        smoothFollow = cam.GetComponent<SmoothFollow>();
        smoothFollow.height = minHeight;
    }
    Vector3 centroidPos;
    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;

        if (totalTime >= recalculateFrequency)
        {

            centroidPos = new Vector3(0, 0, 0);
            GameObject[] units = GameObject.FindGameObjectsWithTag("PlayerModel");
            bool zoomedOut = false;
            foreach (GameObject unit in units)
            {
                if (!canBeSeen(unit))
                {
                    // Zoom out
                    zoomedOut = true;
                    zoomOut();
                }

                if (!zoomedOut)
                {
                    // zoom in
                    zoomIn();
                }
                centroidPos += unit.transform.position;
            }
            centroidPos /= units.Length;
            totalTime = 0f;
        }
        centroid.position = centroidPos;


    }

    bool canBeSeen(GameObject unit)
    {
        Vector3 screenPoint = cam.WorldToViewportPoint(unit.transform.position);
        return (screenPoint.z > 0 && screenPoint.x > 0.2 && screenPoint.x < 0.8 && screenPoint.y > 0.2 && screenPoint.y < 0.8);
    }

    void zoomOut()
    {
        smoothFollow.height += zoomOutSpeed * Time.deltaTime;
    }

    void zoomIn()
    {
        smoothFollow.height -= zoomInSpeed * Time.deltaTime;
        smoothFollow.height = Mathf.Clamp(smoothFollow.height, minHeight, smoothFollow.height);
    }
}