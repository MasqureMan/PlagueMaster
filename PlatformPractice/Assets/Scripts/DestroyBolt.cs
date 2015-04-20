using UnityEngine;
using System.Collections;

public class DestroyBolt : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Destroys the projectile after 6 seconds.
    void Awake()
    {
        Destroy(gameObject, 4);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
