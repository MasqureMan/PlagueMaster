using UnityEngine;
using System.Collections;

public class attack_TestScript : MonoBehaviour {


    //If object is collided with, level restarts.
    void OnTriggerEnter2D (Collider2D other)
    {
       Debug.Log("Object entered the trigger");
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
