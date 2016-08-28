using System.Collections.Generic;
using UnityEngine;
using System.Collections;





public class weapon_spawn : MonoBehaviour
{
    public List<GameObject> weaponTypes;// = new List<GameObject>();
    public GameObject spawnArea;// = GameObject.CreatePrimitive(PrimitiveType.Cube);
    public int spawnLimit = 10;
    List<GameObject> currentWeapons = new List<GameObject>();
    // Use this for initialization
    void Start()
    {
        StartCoroutine(InitiateWeaponSpawn());

    }

    // Update is called once per frame
    void Update()
    {

    }

    GameObject ChooseWeapon()
    {
        int listLength = weaponTypes.Count;
        int weaponChoice = Random.Range(0, listLength);

        Debug.Log("Weapon Choice: " + weaponTypes[weaponChoice].name);
        return weaponTypes[weaponChoice];

    }

    Vector3 SpawnLocation()
    {

        var spawnerBounds = spawnArea.GetComponent<Collider>().bounds;
        float xLocation = Random.Range(spawnerBounds.min.x, spawnerBounds.max.x);
        float zLocation = Random.Range(spawnerBounds.min.z, spawnerBounds.max.z);
        float yLocation = spawnerBounds.center.y; //Random.Range(spawnerBounds.min.y, spawnerBounds.max.y );

        Vector3 location = new Vector3(xLocation, yLocation, zLocation);
        //Debug.Log("Box Location: " + location);
        return location;

    }

    void SpawnWeapon()
    {
        GameObject[] weaponList = GameObject.FindGameObjectsWithTag("Weapon");
        int currentWeaponAmount = weaponList.Length;
        if (spawnLimit > currentWeaponAmount)
        {
            for (int i = currentWeaponAmount; i <= spawnLimit; i++)
            {
                GameObject weap= Instantiate(ChooseWeapon(), SpawnLocation(), Random.rotation) as GameObject;
            }
        }
    }

    IEnumerator InitiateWeaponSpawn()
    {

        while (true)
        {
            Debug.Log("Initiating Weapon Spawn");
            SpawnWeapon();
            yield return new WaitForSeconds(5);
        }


    }
}
