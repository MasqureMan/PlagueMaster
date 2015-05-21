using UnityEngine;
using System.Collections;

public class HpScript : MonoBehaviour {

	//The amount of health the player has
    public int Health = 10;

    //Audio sources and clips for being hit and on death
    AudioSource audioSourceHurt;
    AudioSource audioSourceDeath;

    public AudioClip deathClip;
    public AudioClip hurtClip;
	
	
	//The original color of the player that we want to come back to
	private Color originalColor;
	

	// Use this for initialization
	void Start () {


        //Assigning AudioSource references as an AudioSource on the game object that will be added at the start of the level
        audioSourceHurt = this.gameObject.AddComponent<AudioSource>();
        audioSourceDeath = this.gameObject.AddComponent<AudioSource>();
       
        audioSourceHurt.clip = hurtClip;
        audioSourceDeath.clip = deathClip;
		
		//The originalColor is set to the color of the player at the start of the game
		originalColor = renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
       
        
	}

    //Displays the Health variable to the GUI
    void OnGUI()
    {
        GUI.Label(new Rect(50, 37, 100, 30), "Health:" + Health.ToString());
    }

    // When Enemy collides with player, the player loses health and checks if it needs to die and reload the level. They also turn red briefly before returning to normal.
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            Health--;
			DamageColor();
            Respawn();
        }

    }

    //Reloads the level if the player's health is at 0 or below. Invokes the LoadLevel function after a second so that the deathClip can play before it. 
    void Respawn()
    {
        if (Health <= 0)
        {
            audioSourceDeath.PlayOneShot(deathClip);
            Invoke("LoadLevel", 1);
           
        }
    }

    void LoadLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
	
	
	
	//Player turns red. Starts a Coroutine to get back tot he originalColor.
	void DamageColor()
	{
	
	renderer.material.color = Color.red;
	
	StartCoroutine(ReturnColor());
	
	
	}
	
	//After 1 second, returns the player to their originalColor
	IEnumerator ReturnColor()
	{
	  yield return new WaitForSeconds(1);
	
	  renderer.material.color = originalColor;
	}

	
	
	
	
}
