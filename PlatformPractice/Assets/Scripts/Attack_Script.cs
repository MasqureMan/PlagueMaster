using UnityEngine;
using System.Collections;

public class Attack_Script : MonoBehaviour
{


//Attack_Script is on the player;  animator, PlagueBolt, and HpScript need to be referenced.
    public GameObject Character;

    private Animator anim;

    private PlagueBolt plagueScript;

    private HpScript hpScript;



 

    // Use this for initialization
    void Awake()
    {
	//Initializing the animator for reference
       
    }

    void Start()
    {
	//Initializing the plague and hp scripts for reference
	 anim = Character.GetComponent<Animator>();
        plagueScript = Character.GetComponent<PlagueBolt>();
        hpScript = Character.GetComponent<HpScript>();
      
    }

    // Update is called once per frame
    void Update()
    {




    }

    void OnCollisionEnter2D(Collision2D hit)
    {
	//Player restores health when attacking an enemy projectile. This destroys the projectile. 2 health is added because of a struggle with restoring health as the player collides and takes damage from the projectile. In practice, it ends up being one health.
        if (hit.gameObject.tag == "Enemy" && anim.GetBool("IsAttacking"))
        {
          
            Destroy(hit.gameObject);
            
            hpScript.Health = hpScript.Health + 2;

        }
		//When turret gets hit by the player's attack, they restore energy
        if (hit.gameObject.tag == "Turret" && anim.GetBool("IsAttacking"))
        {
            plagueScript.PlagueEnergy++;
        }




    }
}

		
        
			

