using UnityEngine;
using System.Collections;

public class VerticalMoveScript : MonoBehaviour {


    public bool IsDead;

    //Got code from pixelnest
    // 1 - Designer variables

    /// <summary>
    /// Object speed
    /// </summary>
    public Vector2 speed = new Vector2(10, 10);

    /// <summary>
    /// Moving direction
    /// </summary>
    public Vector2 direction = new Vector2(0, -1);

    private Vector2 movement;

    void Awake()
    {


    }

    void Update()
    {

        if (IsDead == false)
        {
            // 2 - Movement
            movement = new Vector2(
                speed.x * direction.x,
                speed.y * direction.y);
        }



    }

    void FixedUpdate()
    {
        if (IsDead == false)
        {
            // Apply movement to the rigidbody
            rigidbody2D.velocity = movement;


        }
    }

}




