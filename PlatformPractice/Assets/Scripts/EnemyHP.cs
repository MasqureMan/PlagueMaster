using UnityEngine;
using System.Collections;

public class EnemyHP : MonoBehaviour {

    // Enemy's health
    public int EnemyHealth = 1;

    AudioSource audioSourceHit;

    public AudioClip hitClip;


    void Awake()
    {
        Destroy(gameObject, 2);
    }

	// Use this for initialization
	void Start () {

        audioSourceHit = this.gameObject.AddComponent<AudioSource>();
        audioSourceHit.clip = hitClip;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Checks the EnemyHealth to see if the enemy is destroyed
    void EnemyDeathCheck()
    {
        if (EnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Enemy gameobject is destroyed before player's health can be affected, want to find out why. 
    
    void OnTriggerEnter2D (Collider2D other)
    {
        //If a Bolt projectile hits an enemy, the enemy loses health and checks for death
        if (other.gameObject.CompareTag("Bolt"))
        {
            
            EnemyHealth--;
            audioSourceHit.PlayOneShot(hitClip);
            EnemyDeathCheck();
             
        }

        //If a Player collides with an enemy, the enemy loses health and checks for death
        if (other.gameObject.CompareTag("Player"))
        {
           
            EnemyHealth--;
            audioSourceHit.PlayOneShot(hitClip);
            EnemyDeathCheck();
        }

    }
}
