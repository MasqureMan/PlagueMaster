using UnityEngine;
using System.Collections;

public class BoltHP : MonoBehaviour {

    // Enemy's health
    public int BoltHealth = 1;

    //References to the audio source and clip
    AudioSource audioSourceHit;
    public AudioClip hitClip;

    // Use this for initialization
    void Start()
    {
        //Sets the reference to the audio source to target a new audio source that is made when the scene starts.
        audioSourceHit = this.gameObject.AddComponent<AudioSource>();

        //Sets the reference to the audio clip to target the audio source's current audio clip
        audioSourceHit.clip = hitClip;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Checks the EnemyHealth to see if the enemy is destroyed
    void EnemyDeathCheck()
    {
        if (BoltHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Enemy gameobject is destroyed before player's health can be affected, want to find out why. 

    void OnTriggerEnter2D (Collider2D other)
    {
        //If a Bolt projectile hits an enemy, the enemy loses health and checks for death
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Sound doesn't work because game object is destroyed too quick
            audioSourceHit.PlayOneShot(hitClip);
            Destroy(gameObject);
            EnemyDeathCheck();
            
        }

        //If a Player collides with an enemy, the enemy loses health and checks for death
        if (other.gameObject.CompareTag("Turret"))
        {
            //Sound doesn't work because game object is destroyed too quick
            audioSourceHit.PlayOneShot(hitClip);
            Destroy(gameObject);
            
            EnemyDeathCheck();
        }

    }
}