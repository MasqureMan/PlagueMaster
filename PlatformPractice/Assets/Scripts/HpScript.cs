using UnityEngine;
using System.Collections;

public class HpScript : MonoBehaviour {

    public int Health = 5;

    //Audio sourches and clips for being hit and on death
    AudioSource audioSourceHurt;
    AudioSource audioSourceDeath;

    public AudioClip deathClip;
    public AudioClip hurtClip;

	// Use this for initialization
	void Start () {


        //Assigning AudioSource references as an AudioSource on the game object that will be added at the start of the level
        audioSourceHurt = this.gameObject.AddComponent<AudioSource>();
        audioSourceDeath = this.gameObject.AddComponent<AudioSource>();
       
        audioSourceHurt.clip = hurtClip;
        audioSourceDeath.clip = deathClip;
        
	}
	
	// Update is called once per frame
	void Update () {
       
        
	}

    //Displays the Health variable to the GUI
    void OnGUI()
    {
        GUI.Label(new Rect(50, 37, 100, 30), Health.ToString());
    }

    // When Enemy collides with player, the player loses health and checks if it needs to die and reload the level.
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            Health--;
            audioSourceHurt.PlayOneShot(hurtClip);
            Debug.Log("Enemy hits player!");
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
            Debug.Log("Player died! Respawning!");
        }
    }

    void LoadLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
