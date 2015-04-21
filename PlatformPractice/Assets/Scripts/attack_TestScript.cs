using UnityEngine;
using System.Collections;

public class attack_TestScript : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip audioClip;


    void Start ()
    {
        audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        
    }

    //If object is collided with, level restarts.
    void OnTriggerEnter2D (Collider2D other)
    {
       Debug.Log("Object entered the trigger");
       audioSource.PlayOneShot(audioClip);
       Application.LoadLevel(Application.loadedLevel);
       
    }

    void OnTriggerStay2D (Collider2D other)
    {
        Debug.Log("Object is within trigger");
    }

    void OnTriggerExit2D (Collider2D other)
    {
        Debug.Log("Object exited the trigger");
    }
}
