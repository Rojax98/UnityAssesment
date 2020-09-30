using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkDoorTouch : MonoBehaviour
{

    DoorToggle DoorParentScriptReference;

    // Start is called before the first frame update
    void Start()
    {
        DoorParentScriptReference = transform.parent.transform.parent.GetComponent<DoorToggle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (DoorParentScriptReference.currentState == DoorToggle.State.CLOSED)
           DoorParentScriptReference.currentState = DoorToggle.State.OPEN;
        else
            DoorParentScriptReference.currentState = DoorToggle.State.CLOSED;
    }
}
