using UnityEngine;
using System.Collections;

public class WeaponHammer : MonoBehaviour {
    private WeebleAttack weapon;
    private float radius = 1;
    public float upwardsForce = 0f;

    private bool canAttack = false;
    private bool isHammerActive = false;
    private bool destroyAfterSwing = false;
    public SoundManager sounds;
    // Use this for initialization
    void Start () {
        weapon = GetComponentInParent<WeebleAttack>();
        sounds = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void Attack()
    {
        Debug.Log("Attacking with hammer...");
        if (canAttack)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddRelativeForce(Vector3.forward * weapon.hammerSwingSpeed, ForceMode.Impulse);
            }
            //Animator anim = weapon.GetComponentInParent<Animator>();

            //anim.SetTrigger("HammerSwing");

            StartCoroutine(StartAttack());
        }
        else
        {
            Debug.Log("failed to attack with hammer...");
        }
    }

    IEnumerator StartAttack()
    {
        canAttack = false;
        isHammerActive = true;
        yield return new WaitForSeconds(weapon.hammerSwingCooldown);
        if (destroyAfterSwing)
        {
            //StartCoroutine(UnequipHammer());
            UnequipHammer();
        }
        canAttack = true;
        isHammerActive = false;
    }

    void UnequipHammer()
    {
        //yield return new WaitForSeconds(0.1f);
        weapon.PickUp(Weapon.None);
    }
    void OnCollisionEnter(Collision other)
    {
        //Debug.Log("BOOM!");
        if (isHammerActive)
        {
            Vector3 explosionPos = other.contacts[0].point;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                if (hit.name == other.collider.name)
                {
                    Rigidbody rb = hit.GetComponent<Rigidbody>();

                    if (rb != null)
                    {
                        rb.AddForceAtPosition(transform.forward * weapon.hammerExplosionForce, explosionPos, ForceMode.Impulse);
                        //rb.AddExplosionForce(weapon.hammerExplosionForce, explosionPos, radius, upwardsForce, ForceMode.Impulse);
                        destroyAfterSwing = true;
                        sounds.PlayHammerHit();
                        sounds.PlayHit();
                        Debug.Log("BOOM");
                    }
                }

            }
        }
    }

    public void SetupHammer()
    {
        destroyAfterSwing = false;
        canAttack = true;
    }

}
