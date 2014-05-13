﻿using UnityEngine;
using System.Collections;

public class FindObject : MonoBehaviour {
    private RaycastHit hitObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hitObject, 3f)) {
            print(hitObject.transform.name);
            Gu.Instance.targetObject = hitObject.transform.gameObject;
        }
	}
}
