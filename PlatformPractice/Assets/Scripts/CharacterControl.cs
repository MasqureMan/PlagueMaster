using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour
{
	//Audio sources and the jumpClip
	AudioSource audioSource;
	public AudioClip jumpClip;
	
	
	//Movement variables
    public float maxSpeed = 10f;
    public bool facingRight = true;

	//Initializing the animator
    Animator anim;

    // Checks if the player is on the ground or not, used for jumping and animations
    bool grounded = false; 
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 700f; 


  //Attack finished being false allows the player to attack, and prevents it when true. 
   public bool AttackFinished = false;
   

    

    // Use this for initialization
    void Start()
    {
		//Adds an audio source to the player which houses the jumpClip. 
		audioSource = this.gameObject.AddComponent<AudioSource>();
		audioSource.clip = jumpClip;

		//Initializes the player's animator, mainly to get to the IsAttacking bool
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Physics to check if the player is on the ground (Where is the circle, where it's generated, all it will collide with)
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
       

        // How fast the character is moving up and how fast they are moving down
        anim.SetFloat("vSpeed", rigidbody2D.velocity.y);


        // Moves the character according to speed and their input
        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

        // Turns the character 
        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        //Sets the attack input and "IsAttacking" bool (which triggers the attack animation when true) if the player has not recently attacked (AttackFinished is false). This serves as a short cooldown period to prevent spamming. 
		//After 1 second through the AttackTimer Invoke, both the IsAttacking bool and AttackFinished are returned to their false states so the player can attack again.
        if (Input.GetButtonDown("Attack") && AttackFinished == false)
        {
            
            anim.SetBool("IsAttacking", true);
            AttackFinished = true;
			Invoke ("AttackTimer", 1);
            
            

        }

    
		
    }

	
    void AttackTimer()
    {
		
		anim.SetBool ("IsAttacking", false);
		AttackFinished = false;
	
	
    }

    void Update()
    {
       
        // Player will jump if grounded and pressing space, which also plays the jumpClip.
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            rigidbody2D.AddForce(new Vector2(0, jumpForce));

			audioSource.PlayOneShot(jumpClip);

        }
		}
		
		    //if (anim.GetBool("Grounded")) {
                        //Moving platform logic
                        //Check what platform we are on
						/*
                        List<Transform> platforms = new List<Transform> ();
                        bool onSamePlatform = false;
                        foreach (Transform groundCheck in groundChecks) {
                                RaycastHit2D hit = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
                                if (hit.transform != null) {
                                        platforms.Add (hit.transform);
                                        if (currentPlatform == hit.transform) {
                                                onSamePlatform = true;
                                        }
                                }
                        }
               
 
                        if (!onSamePlatform) {
                                foreach (Transform platform in platforms) {
                                        currentPlatform = platform;
                                        lastPlatformPosition = currentPlatform.position;
                                }
                        }
 
                        if (currentPlatform != null) {
                                //Determine how far platform has moved
                                currentPlatformDelta = currentPlatform.position - lastPlatformPosition;
 
                                lastPlatformPosition = currentPlatform.position;
                        }
                //}
    }
 
    void LateUpdate()
    {
        if (anim.GetBool ("Grounded")) {
                        if (currentPlatform != null) {
                                //Move with the platform
                                transform.position += currentPlatformDelta;
                        }
                }
    }
		

        

    
	/*
	 void OnTriggerStay2D(Collider2D other){
             
             if(other.gameObject.tag == "Platform"){
			 
		
             player.transform.parent = other.transform;
			 Debug.Log("Platform parent");
			 
			 //Vector2 Ox = other.rigidbody2D.velocity;
			 //Ox.x = this.rigidbody2D.velocity.x;
 
         }
     }
 
	void OnTriggerExit2D(Collider2D other){
     if(other.gameObject.tag == "Platform"){
             transform.parent = null;
             
         }
     }    
*/
    //Turns the player around
    void Flip()
    {

        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
	
	
    

 
 
	
} //End of line
