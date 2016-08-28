using UnityEngine;
using System.Collections;

public enum Weapon { None, Hammer, BowAndArrow, Bow, Cannon, Helmet }
public class WeebleAttack : MonoBehaviour
{
    private WeebleBottom bottom;
    private Rigidbody rb;
    private PlayerModelManager playerManager;
    public Weapon currentWeapon = Weapon.None;

    public GameObject hammerObject;
    public GameObject bowAndArrow;
    public GameObject cannon;
    public GameObject helmet;
    public GameObject hands;

    // scripts
    private WeaponHammer hammerScript;
    private WeebleCannon cannonScript;
    private WeebleHelmet helmetScript;

    // hammer stats
    public float hammerSwingSpeed;
    public float hammerExplosionForce;
    public float hammerSwingCooldown;
    public bool hammerImpactActive = false;

    // cannon stats
    public float cannonSpeed;
    public float cannonDestroyDelay;
    public float cannonRecoil;

    //helmet stats
    public float helmetChargeSpeed;
    public float helmetImpactForce;
    public float helmetCooldown;


    public string player;

    public SoundManager sounds;
    // Use this for initialization
    void Start()
    {
        bottom = GetComponentInChildren<WeebleBottom>();
        rb = bottom.GetComponent<Rigidbody>();
        playerManager = GetComponent<PlayerModelManager>();

        //init scripts
        hammerScript = GetComponentInChildren<WeaponHammer>();
        cannonScript = GetComponentInChildren<WeebleCannon>(); 
        helmetScript = GetComponentInChildren<WeebleHelmet>();

        player = playerManager.player.ToString();
        PickUp(currentWeapon);
        sounds = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Attack_" + player))
        {
            Debug.Log(playerManager.player + " performed an attack");
            Attack();
        }
    }

    void FixedUpdate()
    {
    }

    void Attack()
    {
        switch (currentWeapon)
        {
            case Weapon.Hammer:
                hammerScript.Attack();
                break;
            case Weapon.Cannon:
                cannonScript.Attack();
                currentWeapon = Weapon.None;
                break;
            case Weapon.Helmet:
                helmetScript.Attack();
                break;
        }
    }

    public void PickUp(Weapon weapon)
    {
        currentWeapon = weapon;
        hammerObject.SetActive(false);
        helmet.SetActive(false);
        hands.SetActive(false);

        if (weapon != Weapon.None)
        {
            if (sounds)
            {
                sounds.PlayPickup();
            }
        }
        //bowAndArrow.SetActive(false);
        switch (weapon)
        {
            case Weapon.Hammer:
                hammerObject.SetActive(true);
                hammerScript.SetupHammer();
                break;
            case Weapon.Cannon:
                cannonScript.SetupCannon();
                break;
            case Weapon.Helmet:
                helmet.SetActive(true);
                helmetScript.SetupHelmet();
                break;
            case Weapon.None:
                hands.SetActive(true);
                break;

        }

    }


}
