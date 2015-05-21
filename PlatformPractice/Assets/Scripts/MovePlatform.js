#pragma strict
// Code from Sunrise Kingdom's Unity 2D Moving Platform tutorial https://www.youtube.com/watch?v=2yloqMkjTBk

var what : boolean = false;
var speed: int = 3;

var whatway : int = 0; //0 is left and right, 1 is up and down

//Timer will go up while Maxtimer basically determines how far the platforms travel before reversing their course.
var timer : int = 0;
var Maxtimer : int = 50;

function Start () {

}

//The whatway bool determines if the platforms velocity is on the x or y axis, which serves to differentiate the behaviors of moving platforms easily.
function Update () {

if (what == false)
{
	if (whatway == 0)
	{
	rigidbody2D.velocity.x = -speed;
	}
	
	if (whatway ==1)
	{
	rigidbody2D.velocity.y = -speed;
	}
}

if (what == true)
{
   if (whatway == 0)
   {
   rigidbody2D.velocity.x = speed;
   }
   
   if (whatway == 1)
   {
   rigidbody2D.velocity.y = speed;
   }
 }
  
  
  //Timer increases quickly, then when the timer reaches the Maxtimer, what changes from either true to false or vice versa. This reverses the platoforms' directions and serves as their source of a pattern. Maxtimer essentially determines how far/long a platform moves in its cosen direction before returning in the opposite direction
  timer += 1;
  
  if (timer >= Maxtimer)
  {
	timer = 0;
	
	if (what == false)
	{
	what = true;
	timer = 0;
	return;
	}
	
	if (what == true)
	{
	what = false;
	timer = 0;
	return;
	}
}
}
