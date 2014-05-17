using UnityEngine;
using System.Collections;

//always on my mind
public class Gu : MonoBehaviour {
    private static Gu instance = null;
    public GameObject targetObject { get; set; }

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
}


