using UnityEngine;
using System.Collections;

public class Level2to3Script : MonoBehaviour {


    AudioSource audioSource;
    public AudioClip audioClip;


    void Start()
    {
	//Puts the audioClip in the audioSource
        audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;

    }

    //If object is collided with, level restarts.
    void OnTriggerEnter2D(Collider2D other)
    {
        
        audioSource.PlayOneShot(audioClip);
        Application.LoadLevel("Level 3");

    }

}
