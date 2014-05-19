using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        Gu gu = Gu.Instance;
        if (gu.targetObject != null) {
            GameObject target = Gu.Instance.targetObject;
            if ((Input.GetButton("Interact")) && (target != null))
                switch (target.tag) {
                    case "Block":
                        if (!target.GetComponent<PushObject>())
                            target.AddComponent("PushObject");
                        break;
                    default:
                        break;
                }
        }
	}
}
