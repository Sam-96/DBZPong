using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ki_Ball_Controller : MonoBehaviour {

    //Reference to rigidbdy attached to Ki Ball
    Rigidbody rigbod;

	// Use this for initialization
	void Start () {

        rigbod = GetComponent<Rigidbody>();

        //Random x direction
        int xDir = Random.Range(0, 2);

        //Random y direction
        int yDir = Random.Range(0, 3);

        Vector3 launchDir = new Vector3();

        if (xDir == 0)
        {
            launchDir.x = -8f;
        }

        if (xDir == 1)
        {
            launchDir.x = 8f;
        }

        if (yDir == 0)
        {
            launchDir.y = -8f;
        }

        if (yDir == 1)
        {
            launchDir.y = 8f;
        }

        if (yDir == 2)
        {
            launchDir.y = 0f;
        }
        rigbod.velocity = launchDir;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision hit) {

        Debug.Log(hit.gameObject.name);
    }
}
