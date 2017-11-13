using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Controller : MonoBehaviour {

    public GameObject leftPaddle;
    public GameObject rightPaddle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //VEGETA LEFT PADDLE
        //Sets velocity to 0
        leftPaddle.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);

        //Moves left paddle (Vegeta) with Q key
        if (Input.GetKey(KeyCode.Q))
        {
            //Sets velocity to move up 1
            leftPaddle.GetComponent<Rigidbody>().velocity = new Vector3(0f, 5f, 0f);
            //Debug.Log("Vegeta is ascending.");
        }

        //Moves left paddle (Vegeta) with A key
       else if (Input.GetKey(KeyCode.A))
        {
            //Sets velocity to move down -1
            leftPaddle.GetComponent<Rigidbody>().velocity = new Vector3(0f, -5f, 0f);

            // Debug.Log("Vegeta is descending.");
        }

        //GOKU RIGHT PADDLE
        //Sets velocity to 0
        rightPaddle.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);

        //Moves right paddle (Vegeta) with up key
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Sets velocity to move up 1
            rightPaddle.GetComponent<Rigidbody>().velocity = new Vector3(0f, 5f, 0f);
            //Debug.Log("Goku is ascending.");
        }

        //Moves right paddle (Goku) with down key
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //Sets velocity to move down -1
            rightPaddle.GetComponent<Rigidbody>().velocity = new Vector3(0f, -5f, 0f);

            // Debug.Log("Goku is descending.");
        }
    }
}
