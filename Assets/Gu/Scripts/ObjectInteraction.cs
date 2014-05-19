using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GameObject target = Gu.Instance.targetObject;
        if ((Input.GetButton("Interact")) && (target != null))
            switch (target.tag) {
                case "Block":
                    if(!target.GetComponent<PushObject>())
                        target.AddComponent("PushObject");
                    break;
                default:
                    break;

            }
            return;
	}
}
