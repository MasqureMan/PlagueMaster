using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour {

public Texture2D Background;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void OnGUI() {
		//Uses the background if it's not null
		if (Background != null)
		{
			GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), Background); 
		}
}
}
