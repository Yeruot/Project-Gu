using UnityEngine;
using System.Collections;

public class PressurePad : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision){
        print("On Enter");
    }
 
    void OnCollisionExit(Collision collision){
        print("On Enter");
    }
}
