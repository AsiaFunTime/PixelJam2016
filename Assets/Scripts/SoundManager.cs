using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioClip cannonExplode;
    public AudioClip cannonShot;
    public AudioClip hammerHit;
    public AudioClip helmetCharge;
    public AudioClip hit;
    public AudioClip arrowHit;
    public AudioClip arrowShoot;
    public AudioClip winner;
    public AudioClip pickup;
    // Use this for initialization
    private AudioSource audioSource;
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();

    }

    public void PlayCannonExplode()
    {
        audioSource.PlayOneShot(cannonExplode);
    }


    public void PlayCannonShot()
    {
        audioSource.PlayOneShot(cannonShot);
    }
    public void PlayHammerHit()
    {
        audioSource.PlayOneShot(hammerHit);
    }
    public void PlayHelmetCharge()
    {
        audioSource.PlayOneShot(helmetCharge);
    }
    public void PlayHit()
    {
        audioSource.PlayOneShot(hit);
    }
    public void PlayArrowHit()
    {
        audioSource.PlayOneShot(arrowHit);
    }
    public void PlayArrowShoot()
    {
        audioSource.PlayOneShot(arrowShoot);
    }

    public void PlayWinner()
    {
        audioSource.PlayOneShot(winner);
    }
    public void PlayPickup()
    {
        audioSource.PlayOneShot(pickup);
    }
}
