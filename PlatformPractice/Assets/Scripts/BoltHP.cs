using UnityEngine;
using System.Collections;

public class BoltHP : MonoBehaviour {

  

    //References to the audio source and clip
    AudioSource audioSourceHit;
    public AudioClip hitClip;

	//Destroys the bolt after 1.5 seconds
	void Awake ()
	{
		Destroy (gameObject, 1.5f);
	}
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

	//Destroys the player's projectile
	void DestroyBolt()
	{
		Destroy(gameObject);
	}



 

    // Enemy gameobject is destroyed before player's health can be affected, want to find out why. 

	void OnCollisionEnter2D(Collision2D hit)
    {
        //If a Bolt projectile hits an enemy, the enemy loses health and checks for death.
		if (hit.gameObject.tag =="Enemy")
        {
            //Sound doesn't work because game object is destroyed too quick

			audioSourceHit.PlayOneShot(hitClip);
           
            
        }

        //If a Player collides with a Turret, the enemy loses health and checks for death. DestroyBolt is invoked after .01 seconds so the audio clip can go off first.
		if (hit.gameObject.tag =="Turret")
        {
            //Sound doesn't work because game object is destroyed too quick
            audioSourceHit.PlayOneShot(hitClip);
			Invoke ("DestroyBolt", .01f);
			
          
        }

    }
}