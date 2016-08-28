using UnityEngine;
using System.Collections;

public class WeebleHelmet : MonoBehaviour {

    private WeebleBottom bottom;
    private WeebleAttack attack;

    public SoundManager sounds;

    private bool isHelmetActive;
    private bool canCharge = false;
    // Use this for initialization
    void Start ()
    {
        bottom = GetComponentInParent<WeebleBottom>();
        attack = GetComponentInParent<WeebleAttack>();
        sounds = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Attack()
    {
        Debug.Log("CAn charge? " + canCharge);
        if (canCharge)
        {
            isHelmetActive = true;
            canCharge = false;
            Rigidbody rb = bottom.GetComponent<Rigidbody>();

            rb.AddRelativeForce(Vector3.up * attack.helmetChargeSpeed, ForceMode.Impulse);
            sounds.PlayHelmetCharge();
            StartCoroutine(BecomeInactive());
            //StopCoroutine(coroutine);
        }
    }

    public void SetupHelmet()
    {
        Debug.Log("CAN NOW CHARGE!");
        canCharge = true;
    }

    IEnumerator BecomeInactive()
    {

        yield return new WaitForSeconds(attack.helmetCooldown);
        isHelmetActive = false;
        canCharge = true;
    }

    void OnCollisionEnter(Collision other)
    {
        
        if (isHelmetActive)
        {
            isHelmetActive = false;
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 dir = other.contacts[0].point - transform.position;
            if (rb)
            {
                rb.AddForce(dir.normalized * attack.helmetImpactForce, ForceMode.Impulse);
                sounds.PlayHit();

                attack.PickUp(Weapon.None);
            }
        }
    }
}
