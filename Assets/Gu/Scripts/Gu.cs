using UnityEngine;
using System.Collections;

public class Gu : MonoBehaviour {
    private static Gu instance = null;

    public static Gu Instance {
        get {return instance;}
    }

    void Awake(){
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        
        //Don't destroy the object when loading new scenes.
        //This will allow our object to persist between scenes.
        DontDestroyOnLoad(this.gameObject);
    }

	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {

	}
}


