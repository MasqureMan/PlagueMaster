using UnityEngine;
using System.Collections;

public class UImanager : MonoBehaviour {

	public GUISkin myGUISkin;

	//Allows you to choose which texture will serve as the background and which as the logo
	public Texture2D Background;
	public Texture2D Logo;

	//Used for the credit text
	public string[] CreditsTextLines = new string[0];

	//Sets the parameters for the window menus
	private Rect WindowRect = new Rect((Screen.width / 2) - 100, Screen.height / 2, 200, 200);

	//Creates the menu state strings
	private string menuState;

	private string main = "main";
	private string options = "options";
	private string credits = "credits";

	private float volume = 1.0f;
	
	//Used for the credit text

	private string textToDisplay = "Credits \n";

	// Use this for initialization
	void Start () {
		//Sets the menustate to main
		menuState = main;

		//Creates the list of credit names
		for( int x = 0; x < CreditsTextLines.Length; x++)
		{
			textToDisplay += CreditsTextLines[x] + " \n";
		}

		textToDisplay += "Press Esc To Go Back";
	}

	private void OnGUI() {
		//Uses the background if it's not null
		if (Background != null)
		{
			GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), Background); 
		}
		//Uses the logo if it's not null
		if(Logo !=null)
		{
			GUI.DrawTexture(new Rect((Screen.width / 2) - 100, 30, 200, 200), Logo);
		}

		GUI.skin = myGUISkin;
		//Opens the main menu if the menuState is main
		if(menuState == main)
		{
			WindowRect = GUI.Window(0, WindowRect, menuFunc, "Main Menu");
		}
		//Opens the options window is the menuState is options
		if(menuState == options)
		{
			WindowRect = GUI.Window (1,WindowRect, optionsFunc, "Options");
		}
		//Opens the credits window is the menuState is credits
		if(menuState == credits)
		{
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), textToDisplay);
		}


	}
//The layout of the main menu
	private void menuFunc(int id) {

		// Starts the game
		if(GUILayout.Button("Play Game"))
		{
			Application.LoadLevel("Level 1");
		}
		//Opens the  options window
		if(GUILayout.Button ("Options"))
		{
			menuState = options;
		}
		//Opens the credits page
		if(GUILayout.Button ("Credits"))
		{
			menuState = credits;
		}
		//Closes the application
		if(GUILayout.Button ("Quit Game"))
		{
			Application.Quit();
		
		}
	}
	//Layout of the options menu
	private void optionsFunc(int id)
	//Creates a volume slider that the player can adjust
	{
		GUILayout.Box("Volume");

		volume = GUILayout.HorizontalSlider(volume, 0.0f, 1.0f);

		AudioListener.volume = volume;
		
		//Returns to the main menu
		if(GUILayout.Button ("Back"))
		{
			menuState = main;
		}
	}

	// Update is called once per frame
	void Update () {
		//If the menuState is credits and the player presses escape, they will return to the main menu
		if (menuState == credits && Input.GetKey(KeyCode.Escape))
		{
			menuState = main;
		}
	}
}
