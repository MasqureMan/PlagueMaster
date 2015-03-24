using UnityEngine;
using System.Collections;

public class Attack_Script : MonoBehaviour
{




    public GameObject Character;
    private Animator anim;

    // Use this for initialization
    void Awake()
    {
        anim = Character.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {



    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}


	/*	if (other.gameObject.CompareTag("Enemy") && anim.GetBool("IsAttacking"))
		    {
     */
        
			

