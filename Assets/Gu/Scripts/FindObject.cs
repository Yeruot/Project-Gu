using UnityEngine;
using System.Collections;

public class FindObject : MonoBehaviour {
    private RaycastHit hitObject;
    private Rect labelRect = new Rect((Screen.width / 2 - 50), ((Screen.height * 3) / 4 - 50), 100, 100);
    private ToolTipType toolTipType;

    public Vector3 contactPoint { get; set; }
    public Vector3 normal { get; set; }
    public GUIStyle tooltipStyle;

    // Different types for the tooltip
    enum ToolTipType
    {
        None = 0,
        Push = 1,
        PickUp = 2,
    }

	// Use this for initialization
	void Start () {
        toolTipType = ToolTipType.None;

        //Setup tooltip label properties for display
        tooltipStyle = new GUIStyle();
        tooltipStyle.alignment = TextAnchor.MiddleCenter;
        tooltipStyle.fontSize = 16;
        tooltipStyle.normal.textColor = Color.black;
	}
	
	// Here we shoot a raycast from the player to find any interactable
    // objects if an object is found the tag determines the tooltip
    // displayed to the player we also set Gu's target object to be
    // the object that he is looking at. This ensures that if we want to
    // interact with the target object we will easily have reference to it
	void Update () {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hitObject, 3f)) {
            switch (hitObject.transform.gameObject.tag) {
                case "Large Object":
                    toolTipType = ToolTipType.Push;
                    break;
                case "Small Object":
                    toolTipType = ToolTipType.PickUp;
                    break;
                default:
                    print ("Invalid Object Tag for Tooltip");
                    break;
            }
            contactPoint = hitObject.point;
            normal = hitObject.normal;
            Gu.Instance.targetObject = hitObject.transform.gameObject;
        } else {
            toolTipType = ToolTipType.None;
            Gu.Instance.targetObject = null;
        }
	}

    // Here is where we display the actual tooltip. The Tooltip
    // is a GUI label and therefore must be displayed in the OnGUI
    // function ensuring that it is displayed during GUI draws.
    void OnGUI() {
            switch(toolTipType){
                case ToolTipType.Push:
                    GUI.Label(labelRect, "Press E to push", tooltipStyle);                    
                    break;
                case ToolTipType.PickUp:
                    GUI.Label(labelRect, "Press E to pick up", tooltipStyle);
                    break;
                case ToolTipType.None:
                    break;
                default:
                    print("Invalid tool tip type");
                    break;
            }
    }
}
