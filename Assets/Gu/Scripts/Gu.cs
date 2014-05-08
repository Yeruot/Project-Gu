using UnityEngine;
using System.Collections;

public class Gu : MonoBehaviour {
    private static Gu instance = null;
    private CharacterController charController;
    private float verticalSpeed;
    private Vector3 movementVector;

    public float gravity;
    public float forwardSpeed;
    public float backwardSpeed;
    public float turnSpeed;
    public float jumpSpeed;
    public float pushPower;


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

        //forward and backward speeds are different
        if (Input.GetAxis("Vertical") > 0)
            movementVector = transform.forward * Input.GetAxis("Vertical") * forwardSpeed;
        else if (Input.GetAxis("Vertical") < 0)
            movementVector = transform.forward * Input.GetAxis("Vertical") * backwardSpeed;
        else
            movementVector = transform.forward * 0;
        
        
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

    void OnControllerColliderHit(ControllerColliderHit hit) {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
            return;

        if (hit.moveDirection.y < -0.3f)
            return;

        Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDirection * pushPower;
    }
}


