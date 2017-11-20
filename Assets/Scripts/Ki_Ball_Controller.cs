using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ki_Ball_Controller : MonoBehaviour {

    //Reference to rigidbdy attached to Ki Ball
    Rigidbody rigbod;

    // Use this for initialization
    void Start()
    {
        //Gets the shortcut to a rigidbody component
        rigbod = GetComponent<Rigidbody>();

        //Pause ball logic for 2.5 seconds to delay launch
        StartCoroutine(Pause());
    }

	// Update is called once per frame
	void Update () {
		
        //If the ball goes too far to the left
        if(transform.position.x < -25f) {

            transform.position = Vector3.zero;
            rigbod.velocity = Vector3.zero;

            //Gives player2 (Goku) a point
            Scoreboard_Controller.instance.GivePlayerTwoAPoint();

            StartCoroutine(Pause());

        }

        //If the ball goes to far to the right
        if (transform.position.x > 25f) {

            transform.position = Vector3.zero;
            rigbod.velocity = Vector3.zero;

            //Gives player1 (Vegeta) a point
            Scoreboard_Controller.instance.GivePlayerOneAPoint();

            StartCoroutine(Pause());

        }
	}

    IEnumerator Pause()
    {

        transform.position = Vector3.zero;

        //Waits for 2.5 seconds
        yield return new WaitForSeconds(2.5f);

        //Calls function that launches ball
        BallLaunch();
    }

    void BallLaunch()
    {
        //Puts ball back into the center of the screen
        transform.position = Vector3.zero;

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

    //Hit something else
    void OnCollisionEnter(Collision hit) {

        //If it was the top or bottom of the screen...
        if (hit.gameObject.name == "BoundsTop")
        {

            float speedInXDir = 0f;

            if (rigbod.velocity.x > 0f)
                speedInXDir = 8f;

            if(rigbod.velocity.x < 0f)
                speedInXDir = -8f;

            rigbod.velocity = new Vector3(speedInXDir,-8f, 0f);
            //Debug.Log("Hit one of the ends of the screen.");
        }

        if (hit.gameObject.name == "BoundsBottom")
        {
            float speedInXDir = 0f;

            if (rigbod.velocity.x > 0f)
                speedInXDir = 8f;

            if (rigbod.velocity.x < 0f)
                speedInXDir = -8f;

            rigbod.velocity = new Vector3(speedInXDir, 8f, 0f);
        }



        //If it was Goku or Vegeta
        if (hit.gameObject.name == "Vegeta")
        {
            rigbod.velocity = new Vector3(12f, 0f, 0f);

            //If we hit the lower half of the bat
            if (transform.position.y - hit.gameObject.transform.position.y < -0.5)
            {
                rigbod.velocity = new Vector3(8f, -8f, 0f);
            }

            if (transform.position.y - hit.gameObject.transform.position.y > 0.5)
            {
                rigbod.velocity = new Vector3(8f, 8f, 0f);
            }
        }

        if (hit.gameObject.name == "Goku")
        {
            rigbod.velocity = new Vector3(-12f, -8f, 0f);

            //If we hit the lower half of the bat
            if (transform.position.y - hit.gameObject.transform.position.y < -0.5)
            {
                rigbod.velocity = new Vector3(-8f, -8f, 0f);
            }
            if (transform.position.y - hit.gameObject.transform.position.y > 0.5)
            {
                rigbod.velocity = new Vector3(-8f, 8f, 0f);
            }
        }




    }
}
