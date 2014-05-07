using UnityEngine;
using System.Collections;

public class Gu : MonoBehaviour {
    private static Gu instance = null;
    private CharacterController charController;
    private float verticalSpeed;
    private Vector3 movementVector;

    public float gravity;
    public float speed;
    public float turnSpeed;
    private float jumpSpeed;


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
        charController = this.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
        movementVector = transform.forward * Input.GetAxis("Vertical") * speed;
        if (charController.isGrounded) {
            //No need to apply gravity
            verticalSpeed = 0;
            if (Input.GetKey("space")) {
                verticalSpeed = jumpSpeed;
            }
        }

        verticalSpeed -= gravity * Time.deltaTime;
        movementVector.y = verticalSpeed;
        charController.Move(movementVector * Time.deltaTime);
	}
}
