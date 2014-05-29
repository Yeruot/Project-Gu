using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        Gu gu = Gu.Instance;
        if (gu.targetObject != null) {
            GameObject target = Gu.Instance.targetObject;
            if ((Input.GetButton("Interact")) && ((target != null) || (target != gu.holdingObject))) {
                startAction(true, target.tag);
            } else {
                if (Gu.Instance.targetObject != null)
                    startAction(false, target.tag);
            }
        }
	}

    void startAction(bool start, string tag) {
        Gu gu = Gu.Instance;
        if (start) {
            switch (tag) {
                case "Large Object":
                    gu.StartPush();
                    break;
                case "Small Object":
                    gu.PickUp();
                    break;
                default:
                    break;
            }
        } else {
            switch (tag) {
                case "Large Object":
                    gu.EndPush();
                    break;
                case "Small Object":
                    gu.PutDown();
                    break;
                default:
                    break;
            }
        }
    }
}
