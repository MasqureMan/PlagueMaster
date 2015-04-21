using UnityEngine;
using System.Collections;

public class AmbientAudio : MonoBehaviour {

    AudioSource audioSourceAmbient;
    public AudioClip ambientClip;



	// Use this for initialization
	void Start () {
        audioSourceAmbient = this.gameObject.AddComponent<AudioSource>();
        audioSourceAmbient.clip = ambientClip;

        audioSourceAmbient.loop = true;
        audioSourceAmbient.PlayOneShot(ambientClip);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
