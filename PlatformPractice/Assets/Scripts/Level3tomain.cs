using UnityEngine;
using System.Collections;

public class Level3toMain : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip audioClip;


    void Start ()
    {
	//Puts the audioClip in the audioSource
        audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        
    }

    //If object is collided with, takes the player back to the main menu.
    void OnTriggerEnter2D (Collider2D other)
    {
      
       audioSource.PlayOneShot(audioClip);
       Application.LoadLevel("Main");
       
    }

}
