using UnityEngine;
using System.Collections;

public class attack_TestScript : MonoBehaviour {

    void OnTriggerEnter2D (Collider2D other)
    {
       Debug.Log("Object entered the trigger");
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
