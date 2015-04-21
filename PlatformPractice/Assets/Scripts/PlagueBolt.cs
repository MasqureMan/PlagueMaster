using UnityEngine;
using System.Collections;

public class PlagueBolt : MonoBehaviour {

    //work on destroying bolts and moving them independent of enemies/obstacles
    public GameObject BoltPrefab;
    public float BoltSpeed = 20f;

    //PlagueEnergy manages the amount of bolts that can be fired
    public int PlagueEnergy = 10;


	private MoveScript moveScript;

	private CharacterControl characterControl;

    //References to the audio source and clip
    AudioSource audioSource;
    public AudioClip audioClip;

    


    
	void Awake()

	{
		moveScript = GetComponent<MoveScript>();
		characterControl = GetComponent<CharacterControl>();

     
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
        // Projectile moves in one direction, currently positive on the horizontal axis (Right). Receiving the error in-game: "Cannot cast from source type to destination type" when I fire projectiles, but they still fire. Would prefer for projectile to fire the direction the player is facing, but currently gameplay will be based on progressing to the right of the screen like in Mario.

        // When the Bolt button is pressed and PlagueEnergy is above 0, a projectile bolt is fired,the PlagueEnergy variable is reduced by 1, and the audio clip plays. The bolt is destroyed in 5 seconds. 

        if (Input.GetButtonDown("Bolt") && PlagueEnergy > 0)
        {
            PlagueEnergy--;
            audioSource.PlayOneShot(audioClip);
			
            Rigidbody2D clone;
            clone = (Rigidbody2D)Instantiate(BoltPrefab, transform.position + transform.forward, transform.rotation) as Rigidbody2D;
            Destroy(clone, 2);

		/*
            if (Input.GetButtonDown("Bolt") && PlagueEnergy > 0 && characterControl.facingRight)
			/*
            clone.rigidbody2D.AddForce(clone.transform.forward.normalized * BoltSpeed);

            
            
            /*

            clone.rigidbody2D.AddForce(Vector3.forward * 10); 
           
            /* AddForce */

           

        }

        /*

		if (Input.GetButtonDown("Bolt") && PlagueEnergy > 0 && characterControl.facingRight == false)
		{
			PlagueEnergy--;
			
			moveScript.direction.x = -1;
			Rigidbody2D clone;
			clone = (Rigidbody2D)Instantiate(BoltPrefab, transform.position + transform.forward, transform.rotation) as Rigidbody2D;
			
			
			
			/*
            clone.rigidbody2D.AddForce(clone.transform.forward.normalized * BoltSpeed);

            
            
            /*

            clone.rigidbody2D.AddForce(Vector3.forward * 10); 
           
            /* AddForce
			
			
			
		}
    */

    }

    //Displays the PlagueEnergy variable to the GUI
    void OnGUI()
    {
        GUI.Label(new Rect(50, 25, 100, 30), PlagueEnergy.ToString());  
    }

    void FixedUpdate()
    {

            
    }
}
