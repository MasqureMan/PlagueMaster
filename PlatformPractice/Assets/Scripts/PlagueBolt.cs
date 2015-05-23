using UnityEngine;
using System.Collections;

public class PlagueBolt : MonoBehaviour {

   //The bolt prefab that will be instatiated and how fast it will move
    public GameObject BoltPrefab;
    public float BoltSpeed = 20f; 
	


    //PlagueEnergy manages the amount of bolts that can be fired
    public int PlagueEnergy = 10;


	

	
    //References to the audio source and clip
    AudioSource audioSource;
    public AudioClip audioClip;

    


    
	void Awake()

	{
		

     
	}
	 //Displays the PlagueEnergy variable to the GUI
    void OnGUI()
    {
        GUI.Label(new Rect(50, 25, 100, 30), "Energy:" + PlagueEnergy.ToString());  
    }

    // Use this for initialization
    void Start()
    {
	
        
        //Sets the reference to the audio source to target a new audio source that is made when the scene starts.
        audioSource = this.gameObject.AddComponent<AudioSource>();
        //Sets the reference to the audio clip to target the audio source's current audio clip
        audioSource.clip = audioClip;
    }

  

    // Update is called once per frame
    void Update()
    {
        
		// If the player presses the bolt button and have any energy, they will lose one energy and fire a projectile with an audio clip. This projectile is destroyed after 2 seconds. 
        if (Input.GetButtonDown("Bolt") && PlagueEnergy > 0)
        {
            PlagueEnergy--;
            audioSource.PlayOneShot(audioClip);
			
            Rigidbody2D clone;
            clone = (Rigidbody2D)Instantiate(BoltPrefab, transform.position + transform.forward, transform.rotation) as Rigidbody2D;
            Destroy(clone, 2);

	

           

        }
		
		}
   

}

     