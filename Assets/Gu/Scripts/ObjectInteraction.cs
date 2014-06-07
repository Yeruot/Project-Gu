using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour
{

    // Update handles the interaction button being pressed
    // and checks what state Gu is in
    void Update() {
        Gu gu = Gu.Instance;
        if (Input.GetButtonDown("Interact")) {
            if (gu.IsCarrying())
                performAction(gu.holdingObject.tag);
            else if (gu.validObjectFound())
                performAction(gu.targetObject.tag);
        } else if (Input.GetButtonUp("Interact")) {
            if (gu.targetObject != null)
                endConcurrentAction(gu.targetObject.tag);
        }
    }

    //This is where we perform the actual action based on
    // the given tag
    void performAction(string tag) {
        Gu gu = Gu.Instance;
        switch (tag) {
            case "Large Object":
                gu.StartPush();
                break;
            case "Small Object":
                if (gu.IsCarrying()) {
                    print("butts");
                    gu.PutDown();
                } else {
                    print("dicks");
                    gu.PickUp();
                }
                break;
            default:
                break;
        }
    }

    // If the action was a continuous action that we want to
    // make sure that when it is over that everything is
    // reset and set back to normal
    void endConcurrentAction(string tag) {
        Gu gu = Gu.Instance;
        switch (tag) {
            case "Large Object":
                gu.EndPush();
                break;
            default:
                break;
        }
    }
}
