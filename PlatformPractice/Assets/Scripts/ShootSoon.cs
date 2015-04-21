using UnityEngine;
using System.Collections;

public class ShootSoon : MonoBehaviour {

    public GameObject shootPrefab;

    AudioSource audioSource;
    public AudioClip audioClip;

	// Use this for initialization

    //Calls the turret shooting function
	void Start () {
        audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        

        TurretShoot();

	}
	
	// Update is called once per frame
	void Update () {
        
	}

    //Turret shoots the projectile
    void Shoot()
    {
        Rigidbody2D clone;
        audioSource.PlayOneShot(audioClip);
        clone = (Rigidbody2D)Instantiate(shootPrefab, transform.position + transform.forward, transform.rotation) as Rigidbody2D;
    }

    //The turret shoots every 3 seconds
    void TurretShoot()
    {
        InvokeRepeating("Shoot", 3, 3F);
    }
}

