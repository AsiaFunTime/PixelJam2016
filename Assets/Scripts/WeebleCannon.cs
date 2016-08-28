using UnityEngine;
using System.Collections;

public class WeebleCannon : MonoBehaviour {
    public GameObject cannonball;
    public GameObject cannon;
    private WeebleAttack attack;
    public Transform releasePoint;
    public Transform spawnPoint;
    public SoundManager sounds;

    public GameObject muzzleFlash;
    public GameObject hands;
    // Use this for initialization
    void Start () {
        attack = GetComponentInParent<WeebleAttack>();
        sounds = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        hands.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Attack()
    {
        GameObject cb = GameObject.Instantiate(cannonball, releasePoint.position, releasePoint.rotation) as GameObject;
        Rigidbody rb = cb.GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * attack.cannonSpeed, ForceMode.Impulse);

        Rigidbody cannonRb = GetComponentInChildren<Rigidbody>();
        cannonRb.AddRelativeForce(Vector3.back * attack.cannonRecoil, ForceMode.Impulse);

        sounds.PlayCannonShot();
        StartCoroutine(waitThenDetach());

        GameObject.Instantiate(muzzleFlash, releasePoint.position, releasePoint.rotation);
        hands.SetActive(false);
        attack.PickUp(Weapon.None);
    }

    public void SetupCannon()
    {

        hands.SetActive(true);
        GameObject c = GameObject.Instantiate(cannon, spawnPoint.position, releasePoint.rotation) as GameObject;
        c.transform.SetParent(transform);

        FixedJoint fj = GetComponentInChildren<FixedJoint>();
        fj.connectedBody = attack.GetComponent<Rigidbody>();
        //Rigidbody crb = c.GetComponent<Rigidbody>();
    }

    public void DetachCannon()
    {
        FixedJoint fj = GetComponentInChildren<FixedJoint>();
        fj.transform.parent.SetParent(null);
        fj.gameObject.AddComponent<Despawner>();
        Destroy(fj);

    }

    IEnumerator waitThenDetach()
    {
        yield return new WaitForSeconds(.1f);
        DetachCannon();
    }
}
