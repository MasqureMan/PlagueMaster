using UnityEngine;
using System.Collections;

public class TurretHP : MonoBehaviour {

    // Enemy's health
    public int EnemyHealth = 2;

	
	
	


    private SpriteRenderer spriteColor;
	
	
	
	void Awake()
	{

	
	}

    // Use this for initialization
    void Start()
    {
	 

	 
	 spriteColor = GetComponent<SpriteRenderer>();
	 
	
	
	
    }
	
	

    // Update is called once per frame
    void Update()
    {

    }
	

	
	// Turret turns green after being hit. stays green to communicate to player that it's been hit before
	void DamageColor()
	{
	
	spriteColor.color = Color.green;


	
	
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

	void OnCollisionEnter2D(Collision2D hit)
    {
        //If a Bolt projectile hits an enemy, the enemy loses health, turns green, and checks for death
		if (hit.gameObject.tag =="Bolt")
        {
            
            EnemyHealth--;
			DamageColor();
            EnemyDeathCheck();
            
            
            
        }

     

    }
}

