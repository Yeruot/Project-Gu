using UnityEngine;
using System.Collections;

public class PressurePad : MonoBehaviour {
    public gameObject triggerObject { get; set; }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //when the player stands on the pressure pad
    // this is where the script will enter
    void OnCollisionEnter(Collision collision){
        print("On Enter");
        //trigger animations and whatever the script
        //is linked to
    }

    //when the player leaves pressure pad
    // this is where the script will enter
    void OnCollisionExit(Collision collision){
        print("On Enter");
        //trigger animations and whatever the script
        //is linked to
    }
}
