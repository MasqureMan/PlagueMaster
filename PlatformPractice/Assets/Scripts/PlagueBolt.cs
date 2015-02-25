using UnityEngine;
using System.Collections;

public class PlagueBolt : MonoBehaviour {


    public GameObject BoltPrefab;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Bolt"))
        {
            Rigidbody clone;
            clone = Instantiate(BoltPrefab, transform.position, transform.rotation) as Rigidbody;
            clone.velocity = transform.TransformDirection(Vector3.forward * 10);
            
            /* AddForce */

        }
    }
}
