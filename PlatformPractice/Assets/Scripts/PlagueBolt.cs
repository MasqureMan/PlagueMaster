using UnityEngine;
using System.Collections;

public class PlagueBolt : MonoBehaviour {


    public GameObject BoltPrefab;
    public float BoltSpeed = 500f;

    public int PlagueEnergy = 10;

    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Can't get Projectile to actually move. Receiving the error in-game: "Cannot cast from source type to destination type" when I fire projectiles, which instead are instnatiated at the character's location and just sit there.

        if (Input.GetButtonDown("Bolt") && PlagueEnergy > 0)
        {
            PlagueEnergy--;

            /*
            Rigidbody2D clone;
            clone = (Rigidbody2D)Instantiate(BoltPrefab, transform.position, transform.rotation) as Rigidbody2D;

            clone.rigidbody2D.AddForce(clone.transform.forward.normalized * BoltSpeed);

            
            
            /*

           /* clone.rigidbody2D.AddForce(Vector3.forward * 10); /*
           
            /* AddForce */

        }


    }

    void OnGUI()
    {
        GUI.Label(new Rect(50, 25, 100, 30), PlagueEnergy.ToString());  
    }

    void FixedUpdate()
    {
       
            
    }
}
