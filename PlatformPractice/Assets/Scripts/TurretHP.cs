using UnityEngine;
using System.Collections;

public class TurretHP : MonoBehaviour {

    // Enemy's health
    public int EnemyHealth = 2;

	private PlagueBolt plagueScript;
	
	


    private SpriteRenderer spriteColor;
	
	
	
	void Awake()
	{

	plagueScript = GetComponent<PlagueBolt>();
	}

    // Use this for initialization
    void Start()
    {
	 

	 
	 spriteColor = GetComponent<SpriteRenderer>();
	 
	
	
	 
      //originalColor = renderer.material.color;
    }
	
	

    // Update is called once per frame
    void Update()
    {

    }
	

	
	// Turret turns green after being hit. stays green to communicate to player that it's been hit before
	void DamageColor()
	{
	
	spriteColor.color = Color.green;
	/*
	if (renderer.material.HasProperty("_TintColor"))
renderer.material.SetColor("_TintColor", Color.green);
	else {
	 Debug.Log("No _Color property!");
	 }
	*/

	
	
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
        //If a Bolt projectile hits an enemy, the enemy loses health and checks for death
		if (hit.gameObject.tag =="Bolt")
        {
            
            EnemyHealth--;
			DamageColor();
            EnemyDeathCheck();
            
            
            
        }

     

    }
}

