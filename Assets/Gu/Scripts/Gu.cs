using UnityEngine;
using System.Collections;

//always on my mind
public class Gu : MonoBehaviour {

    private enum ActionState
    {
        None = 0,
        Pushing = 1,
        Carrying = 2,
    }

    private ActionState actionState;
    private static Gu instance = null;

    public GameObject targetObject { get; set; }
    public GameObject holdingObject { get; set; }

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

    void Start() {
        targetObject = null;
    }

    public bool validObjectFound() {
        if (targetObject != null)
            return true;
        else
            return false;
    }

    public void StartPush(){
        actionState = ActionState.Pushing;
        if (!targetObject.GetComponent<PushObject>())
            targetObject.AddComponent("PushObject");
    }

    public void EndPush() {
        actionState = ActionState.None;
        Destroy(targetObject.GetComponent<PushObject>());
    }

    public void PickUp() {
        actionState = ActionState.Carrying;
        holdingObject = targetObject;
        Destroy(holdingObject.transform.rigidbody);
        holdingObject.transform.parent = transform;
        holdingObject.transform.localPosition = new Vector3(0, 2.0f, 2.0f);
    }

    public void PutDown() {
        actionState = ActionState.None;
        holdingObject.AddComponent(typeof(Rigidbody));
        holdingObject.transform.parent = null;
        holdingObject = null;
    }

    public bool IsCarrying() {
        if (holdingObject != null)
            return true;
        else
            return false;
    }
}


