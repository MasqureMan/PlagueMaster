using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

	//Sets the parameters of the menu rectangle
	private Rect WindowRect = new Rect((Screen.width / 2) - 100, Screen.height / 2, 375, 200);


	//Creates the menuState string and it's corresponding state strings
    public string menuState;
	public string play = "play";
	public string pause = "pause";
	public string timeout = "timeout";
	
	
	
	// Use this for initialization
	void Start () {
	//Game starts in the play state
        menuState = play;

	}
	
	// Update is called once per frame
	void Update () {
	
	 //If the player presses the pause button and the game is in the play state, state switches to pause 
        if (Input.GetButtonDown("pause") && menuState == "play")
        {
           
            menuState = pause;
			
        }

         
	}
	
	private void OnGUI()
    {
        

        //Brings up the pause menu if the menu state is pause and sets the timeScale to 0 so the game stops. 
        if (menuState == pause)
        {
            
            WindowRect = GUI.Window(0, WindowRect, pauseFunc, "Paused");
			Time.timeScale = 0;
        }
		
		//Brings up the timeout (from when the timer runs out) menu and sets the timeScale to 0 so the game stops.
		if (menuState == timeout)
        {
            
            WindowRect = GUI.Window(0, WindowRect, NotimeFunc, "Paused");
			Time.timeScale = 0;
        }
		
		//This is the default menuState that the game starts in. Timescale is set to 1 during this time, so the game progresses normally and resumes when it returns to this state.
		if (menuState == play)
		{
		  Time.timeScale = 1;
		}
		
		
         


    }
	//The pause menu: allows the player to continue unpause and continue playing, return to the main menu, or quit the game.
	 private void pauseFunc(int id)
    {
       
            GUILayout.Box("Game Is Paused");

            if (GUILayout.Button("Continue?"))
            {
                menuState = play;
             
            }

            if (GUILayout.Button("Return to Map?"))
            {
                Application.LoadLevel("Main");
            }

            if (GUILayout.Button("Quit the game?"))
            {
                Application.Quit();
            }
        }
		//This is the timeover menu that comes up when the timer runs out. The player can restart the level, return to the main menu, or quit the game.
		 private void NotimeFunc(int id)
    {
        GUILayout.Box("You ran out of time! Would you like to try again?");

        if (GUILayout.Button("Retry"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (GUILayout.Button("Main Menu"))
        {
            Application.LoadLevel("Main");
        }

        if (GUILayout.Button("Quit the game?"))
        {
            Application.Quit();
        }

    }
}
