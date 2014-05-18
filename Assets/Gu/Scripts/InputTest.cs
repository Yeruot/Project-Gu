using UnityEngine;
using System.Collections;

public class InputTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
            print("Right Trigger");

        if (Input.GetButton("Fire3"))
            print("Left Trigger");

        if (Input.GetButton("Fire3"))
            print("Right Bumper");

        if (Input.GetButton("Fire4"))
            print("Left Bumper");

        if (Input.GetButton("Interact"))
            print("Square");

        if (Input.GetButton("Attack"))
            print("Circle");
	}
}
