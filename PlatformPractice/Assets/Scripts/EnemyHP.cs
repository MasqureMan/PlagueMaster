using UnityEngine;
using System.Collections;

public class EnemyHP : MonoBehaviour {



    //References to the audio source and clip
    AudioSource audioSourceHit;
    public AudioClip hitClip;



 //Enemy projectile is destroyed after 2 seonds
    void Awake()
    {
        Destroy(gameObject, 2);
    }

	// Use this for initialization
	void Start () {

        //Sets the reference to the audio source to target a new audio source that is made when the scene starts.
        audioSourceHit = this.gameObject.AddComponent<AudioSource>();

        //Sets the reference to the audio clip to target the audio source's current audio clip
        audioSourceHit.clip = hitClip;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	


     
    
	IEnumerator OnCollisionEnter2D(Collision2D hit)
    {
        //If a Bolt projectile hits an enemy projectile, they are both destroyed
		if  (hit.gameObject.tag =="Bolt")
        {
		
            //Audio clip plays when the enemy projectile hits a player projectile
			//yield to make sure audio clip gets to play before projectile is destroyed
			
			audioSourceHit.PlayOneShot(hitClip);
			
			yield return new WaitForSeconds (.01f);    
			
			Destroy(gameObject);
			Destroy(hit.gameObject);
            

             
        }

        //If a Player collides with an enemy projectile, it is destroyed and plays a clip
		if (hit.gameObject.tag =="Player")
        {
           //Audio clip plays when the enemy projectile hits the player
		
		  
            audioSourceHit.PlayOneShot(hitClip);
			
          //Waits .01f, then destroys the enemy projectile
		    yield return new WaitForSeconds (.01f); 
			
			Destroy(gameObject);
        }

    }
}
