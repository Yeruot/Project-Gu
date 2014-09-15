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

    //determines whether a valid object is within
    //Gu's sight
    public bool validObjectFound() {
        if (targetObject != null)
            return true;
        else
            return false;
    }

    //begins the pushing action on the target object
    //by attaching the PushObject script to the target
    //object
    public void StartPush(){
        actionState = ActionState.Pushing;
        if (!targetObject.GetComponent<PushObject>())
            targetObject.AddComponent("PushObject");
    }

    //stop the pushing action.
    public void EndPush() {
        actionState = ActionState.None;
        Destroy(targetObject.GetComponent<PushObject>());
    }

    //picks up the target object. Destroys rigidbody and collider
    //orients the block with the player and make it a child
    //of the player
    public void PickUp() {
        actionState = ActionState.Carrying;
        holdingObject = targetObject;
        Destroy(holdingObject.transform.rigidbody);
        Destroy(holdingObject.transform.collider);
        holdingObject.transform.parent = transform;
        holdingObject.transform.localPosition = new Vector3(0, 2.0f, 2.0f);
        holdingObject.transform.rotation = transform.rotation;
    }

    //drops the object Gu is currently holding. Accomplishes this
    //by setting the objects parent to null and reapplying all
    //destroyed components
    public void PutDown() {
        print("Put down");
        actionState = ActionState.None;
        holdingObject.AddComponent(typeof(Rigidbody));
        holdingObject.AddComponent(typeof(BoxCollider));
        holdingObject.transform.parent = null;
        holdingObject = null;
    }

    public bool IsCarrying() {
        return actionState == ActionState.Carrying ? true : false;
    }

    public bool IsPushing() {
        return actionState == ActionState.Pushing ? true : false;
    }
}


