using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	//Timer will be where we count down from, TimeLeft is the amount of time left on the timer. This is the actual time displayed to the player.
    public float timer = 100;
    public float TimeLeft;

	//references the pause script
    private PauseScript pauseScript;

   
    
	
    // Use this for initialization
	//initializes the pause script
    void Start()
    {
        pauseScript = GetComponent<PauseScript>();
    }

    // Update is called once per frame
    void Update()
    {
		
      
        //If the timer is above 0, it continues to count down. When it reaches 0, the menuState changes to timeout and its menu comes up.
        if (timer > 0)
        {
            TimeLeft = timer -= Time.deltaTime;
        }

        else
        {
            
            pauseScript.menuState = pauseScript.timeout;
           

        }

    }
	
	//Displays the timer to the player
	void OnGUI()
	{
	  GUI.Label(new Rect(50, 50, 100, 30), "Time:" + timer.ToString());
	}
}
