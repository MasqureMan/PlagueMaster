using UnityEngine;
using System.Collections;

public class HpScript : MonoBehaviour {

    public int Health = 5;

	// Use this for initialization
	void Start () {
	
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
            Debug.Log("Enemy hits player!");
            Respawn();
        }

    }

    //Reloads the level if the player's health is at 0 or below. 
    void Respawn()
    {
        if (Health <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
            Debug.Log("Player died! Respawning!");
        }
    }
}
