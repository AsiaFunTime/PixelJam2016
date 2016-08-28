using UnityEngine;
using System.Collections;

public class WeeblePickup : MonoBehaviour {
    private WeebleAttack attack;
	// Use this for initialization
	void Start () {
        attack = GetComponentInParent<WeebleAttack>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {
        // pick up weapon
        if(other.tag == "Weapon")
        {
            if(attack.currentWeapon == Weapon.None)
            {
                Debug.Log("FOUND WEAPON");
                Pickupable weap = other.GetComponent<Pickupable>();
                attack.PickUp(weap.weapon);
                Destroy(other.transform.parent.gameObject);
            }
        }
    }
}
