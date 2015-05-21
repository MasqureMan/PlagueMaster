using UnityEngine;
using System.Collections;

public class AmbientAudio : MonoBehaviour {

    //References to the audio source and clip
    AudioSource audioSourceAmbient;
    public AudioClip ambientClip;



	// Use this for initialization
	void Start () {
        //Sets the reference to the audio source to target a new audio source that is made when the scene starts.
        audioSourceAmbient = this.gameObject.AddComponent<AudioSource>();

        //Sets the reference to the audio clip to target the audio source's current audio clip
        audioSourceAmbient.clip = ambientClip;

        //Sets the audio clip in the audio source to  play and loop
        audioSourceAmbient.loop = true;
        audioSourceAmbient.PlayOneShot(ambientClip);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
