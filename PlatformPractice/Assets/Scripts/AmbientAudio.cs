using UnityEngine;
using System.Collections;

public class AmbientAudio : MonoBehaviour {

    //References to the audio sources and clips
    AudioSource audioSourceAmbient;
	AudioSource audioSourceTimeAmbient;
	
    public AudioClip ambientClip;
	public AudioClip timerClip;
	
	//References



	// Use this for initialization
	void Start () {
	

        //Sets the reference to the audio sources to target a new audio source that is made when the scene starts.
        audioSourceAmbient = this.gameObject.AddComponent<AudioSource>();
		audioSourceTimeAmbient = this.gameObject.AddComponent<AudioSource>();

        //Sets the reference to the audio clip to target the audio source's current audio clip
        audioSourceAmbient.clip = ambientClip;
		audioSourceTimeAmbient.clip = timerClip;
	

        //Sets the audio clip in the audio source to  play and loop
     
        audioSourceAmbient.PlayOneShot(ambientClip);
		
		//Two Coroutines start: The first plays the Time running out sound, the second stops the original music from playing. They both trigger after 69 (plus the 1 from the delay, so when 30 seconds are left) 
		StartCoroutine(PlaySoundAfterDelay(audioSourceTimeAmbient, 39.0f) );
		StartCoroutine(StopSoundAfterDelay(audioSourceAmbient, 39.0f) );
	}
	
	// Update is called once per frame
	void Update () {
	

	}
	//The coroutines, both start 1 second after they are called (after the initial 69)
	IEnumerator StopSoundAfterDelay(AudioSource audioSource, float delay = 1f)
	{
	if (audioSource == null)
		yield break;
		
		yield return new WaitForSeconds(delay);
		audioSource.Stop();
		}
	
	IEnumerator PlaySoundAfterDelay( AudioSource audioSource, float delay = 1f)
	{
	if (audioSource == null)
		yield break;
	
	yield return new WaitForSeconds(delay);
	audioSource.loop = true;
	audioSource.Play();
	


}
}
