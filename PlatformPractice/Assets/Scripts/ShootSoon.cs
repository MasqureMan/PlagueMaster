using UnityEngine;
using System.Collections;

public class ShootSoon : MonoBehaviour {

	//The bullet prefab we will be instantiating
    public GameObject shootPrefab;

    //References to the audio source and clip
    AudioSource audioSource;
    public AudioClip audioClip;

	// Use this for initialization

    //Calls the turret shooting function
	void Start () {
        //Sets the reference to the audio source to target a new audio source that is made when the scene starts.
        audioSource = this.gameObject.AddComponent<AudioSource>();

        //Sets the reference to the audio clip to target the audio source's current audio clip
        audioSource.clip = audioClip;
        
		//Starts shooting from the start, which will first happen 3 seconds after the game has started. 
        TurretShoot();

	}
	
	// Update is called once per frame
	void Update () {
        
	}

    //Turret shoots the projectile and plays the audio clip
    void Shoot()
    {
        GameObject clone;
        audioSource.PlayOneShot(audioClip);
		clone = (GameObject)Instantiate(shootPrefab, transform.position + transform.forward, transform.rotation);
    }

    //The turret shoots every 3 seconds
    void TurretShoot()
    {
        InvokeRepeating("Shoot", 3, 3F);
    }
}

