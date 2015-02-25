using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{
   
    public float maxSpeed = 10f;
    bool facingRight = true;

    Animator anim;

    // Checks if the player is on the ground or not, used for jumping and animations
    bool grounded = false; 
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    public float jumpForce = 700f; 

    

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Physics to check if the player is on the ground (Where is the circle, where it's generated, all it will collide with)
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
       

        // How fast the character is moving up and how fast they are moving down
        anim.SetFloat("vSpeed", rigidbody2D.velocity.y);


        // Moves the character according to speed and their input
        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

        // Turns the character 
        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();


        if (Input.GetButtonDown("Attack"))
            anim.SetBool("IsAttacking", true);
           

       /* anim.SetBool("IsAttacking", */

        /* idle animation unity */
    }

    void Update()
    {
        // Player will jump if grounded and pressing space.
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            rigidbody2D.AddForce(new Vector2(0, jumpForce));

        }


    }


    void Flip()
    {

        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
